using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces
{
    public interface IObj
    {
        string Name { get; }
        string Id { get; }
        IEnumerable<Reference> References { get; }
    }
}
