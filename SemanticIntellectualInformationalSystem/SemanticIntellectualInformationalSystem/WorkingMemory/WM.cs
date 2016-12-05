using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.WorkingMemory
{
    public class WM
    {
        public IEnumerable<IObj> Objects;
        public WM(IEnumerable<IObj> objects)
        {
            Objects = objects;
        }
    }
}