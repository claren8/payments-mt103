namespace Payments.MT103.Domain
{
    public class Payment
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string TransactionReference { get; init; } = default!;
        public DateTime ValueDate { get; init; }
        public string Currency { get; init; } = default!;
        public decimal Amount { get; init; }
        public string OrderingCustomer { get; init; } = default!;
        public string Beneficiary { get; init; } = default!;
        public string? RemittanceInformation { get; init; }
        public PaymentStatus Status { get; set; }
        public string RawMessage { get; init; } = default!;
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
