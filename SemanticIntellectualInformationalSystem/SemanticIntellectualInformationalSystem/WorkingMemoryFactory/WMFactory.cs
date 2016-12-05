using SemanticIntellectualInformationalSystem.KnowledgeBase;
using SemanticIntellectualInformationalSystem.WorkingMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.WorkingMemoryFactory
{
    public static class WMFactory
    {
        public static WM CreateWM()
        {
            KB kb = new KB();
            return new WM(kb.Objects);
        }
    }
}

