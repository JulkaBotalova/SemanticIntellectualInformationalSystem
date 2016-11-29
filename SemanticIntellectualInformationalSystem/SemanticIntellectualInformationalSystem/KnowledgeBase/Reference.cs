using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.KnowledgeBase
{
    public class Reference
    {
        public string Id { get; }
        public string Name { get; }
        public Obj From { get; }
        public Obj To { get; }
        public Reference(string id, string name, Obj from, Obj to)
        {
            Id = id;
            Name = name;
            From = from;
            To = to;
        }
    }
}
