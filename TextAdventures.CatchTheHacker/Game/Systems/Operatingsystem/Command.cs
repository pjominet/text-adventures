using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventures.CatchTheHacker.Game.Systems.OperatingSystem
{
    public class Command : IEquatable<Command>
    {
        public string Name { get; }
        public IEnumerable<string> Params { get; }
        public string Description { get; }
        public string OSName { get; }

        public Command(string name, IEnumerable<string> @params, string description, string osName)
        {
            Name = name;
            Params = @params;
            Description = description;
            OSName = osName;
        }

        public override string ToString()
        {
            if (Params == null || !Params.Any())
                return $"\t{Name}\n\t{Description}";

            var sb = new StringBuilder();
            foreach (var param in Params) {
                sb.Append($" <{param}>");
            }
            var paramValues = sb.ToString();
            return $"\t{Name}{paramValues}\n\t{Description}";
        }

        public bool Equals(Command other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name
                   && OSName == other.OSName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Command) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, OSName);
        }

        public static bool operator ==(Command left, Command right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Command left, Command right)
        {
            return !Equals(left, right);
        }
    }
}
