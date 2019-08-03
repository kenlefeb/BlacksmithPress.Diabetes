using System.Text;

namespace Diabetes.Models
{
    public class Name
    {
        private string _first = string.Empty;
        private string _middle = string.Empty;
        private string _last = string.Empty;

        public string First
        {
            get => _first;
            set => _first = Normalize(value);
        }

        public string Middle
        {
            get => _middle;
            set => _middle = Normalize(value);
        }

        public string Last
        {
            get => _last;
            set => _last = Normalize(value);
        }

        private string Normalize(string name)
        {
            name = name?.Trim() ?? string.Empty;
            if (name.Length == 1)
                name += ".";
            return name;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(First))
                builder.Append(First);

            AppendName(builder, Middle);
            AppendName(builder, Last);

            return builder.ToString();
        }

        private void AppendName(StringBuilder builder, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (builder.Length > 0)
                    builder.Append(" ");

                builder.Append(name);

                if (name.Length == 1)
                    builder.Append(".");
            }
        }
    }
}