namespace Payments.MT103.Application
{
    public class Mt103Parser
    {
        public Dictionary<string, string> Parse(string rawMessage)
        {
            var result = new Dictionary<string, string>();

            var lines = rawMessage.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (!line.StartsWith(":")) continue;

                var separatorIndex = line.IndexOf(':', 1);
                if (separatorIndex < 0) continue;

                var tag = line.Substring(1, separatorIndex - 1);
                var value = line.Substring(separatorIndex + 1).Trim();

                result[tag] = value;
            }

            return result;
        }
    }
    
}
