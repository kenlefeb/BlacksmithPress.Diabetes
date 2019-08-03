using System;
using System.Text;

namespace Diabetes.Models
{
    public class Name
    {
        private string _first = string.Empty;
        private string _last = string.Empty;
        private string _middle = string.Empty;

        public string First
        {
            get => _first;
            set => _first = Normalize(value);
        }

        public string Last
        {
            get => _last;
            set => _last = Normalize(value);
        }

        public string Middle
        {
            get => _middle;
            set => _middle = Normalize(value);
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

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Name that))
                return false;

            return string.Equals(this.First, that.First, StringComparison.CurrentCultureIgnoreCase)
                   && string.Equals(this.Middle, that.Middle, StringComparison.CurrentCultureIgnoreCase)
                   && string.Equals(this.Last, that.Last, StringComparison.CurrentCultureIgnoreCase);
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

        private string Normalize(string name)
        {
            name = name?.Trim() ?? string.Empty;
            if (name.Length == 1)
                name += ".";
            return name;
        }
    }
}