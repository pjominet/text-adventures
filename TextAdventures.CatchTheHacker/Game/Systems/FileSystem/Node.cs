using System.Collections.Generic;
using System.Linq;

namespace TextAdventures.CatchTheHacker.Game.Systems.FileSystem
{
    public class Node
    {
        public Node Parent { get; set; }
        public IEnumerable<Node> Children { get; }
        public string Name { get; set; }
        public NodeType Type { get; set; }
        public char[] Permissions { get; set; }
        public string Content { get; set; }

        public Node()
        {
            Children = new LinkedList<Node>();
            Permissions = new char[3];
        }

        public Node(Node parent, string name, NodeType type, char[] permissions)
        {
            Parent = parent;
            Children = new LinkedList<Node>();
            Name = name;
            Type = type;
            Permissions = permissions;
        }

        public Node FindChildByName(string name)
        {
            return Children.FirstOrDefault(child => child.Name == name);
        }

        public bool HasPermission(char permission)
        {
            return Permissions.Any(p => p == permission);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
