using Payments.MT103.Application;
using Payments.MT103.Domain;

namespace Payments.MT103.Endpoints
{
    public static class PaymentsEndpoints
    {
        public static void MapPayments(this WebApplication app)
        {
            app.MapPost("/payments/mt103", async (HttpRequest request) =>
            {
                using var reader = new StreamReader(request.Body);
                var rawMessage = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(rawMessage))
                {
                    return Results.BadRequest("MT103 message is empty");
                }

                var parser = new Mt103Parser();
                var validator = new Mt103Validator();

                var fields = parser.Parse(rawMessage);
                var errors = validator.Validate(fields);

                if (errors.Any())
                {
                    return Results.BadRequest(new
                    {
                        Status = "Rejected",
                        Errors = errors
                    });
                }

                var payment = new Payment
                {
                    TransactionReference = fields["20"],
                    Currency = fields["32A"].Substring(6, 3),
                    Amount = decimal.Parse(fields["32A"].Substring(9).Replace(",", ".")),
                    OrderingCustomer = fields["50K"],
                    Beneficiary = fields["59"],
                    RemittanceInformation = fields.GetValueOrDefault("70"),
                    Status = PaymentStatus.Validated,
                    RawMessage = rawMessage
                };

                return Results.Ok(payment);
            });
        }
    }

}
