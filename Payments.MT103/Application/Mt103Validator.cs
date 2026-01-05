namespace Payments.MT103.Application
{
    public class Mt103Validator
    {
        public List<string> Validate(Dictionary<string, string> fields)
        {
            var errors = new List<string>();

            if (!fields.ContainsKey("20"))
                errors.Add("Missing :20: Transaction Reference");

            if (!fields.ContainsKey("32A"))
                errors.Add("Missing :32A: Value Date / Currency / Amount");
            else if (!IsValid32A(fields["32A"]))
                errors.Add("Invalid :32A: format");

            if (!fields.ContainsKey("50K"))
                errors.Add("Missing :50K: Ordering Customer");

            if (!fields.ContainsKey("59"))
                errors.Add("Missing :59: Beneficiary");

            return errors;
        }

        private bool IsValid32A(string value)
        {
            // YYMMDDCCCAMOUNT
            if (value.Length < 10) return false;

            var currency = value.Substring(6, 3);
            return currency.All(char.IsLetter);
        }
    }
}
