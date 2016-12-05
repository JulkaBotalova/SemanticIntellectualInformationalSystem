using SemanticIntellectualInformationalSystem.KnowledgeBase;
using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using SemanticIntellectualInformationalSystem.WorkingMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.LogicalOutputMechanism.AnswerFinders
{
    public abstract class AnswerFinder
    {
        protected WM Wm;
        protected DepthSearch searcher = new DepthSearch();
        public AnswerFinder(WM wm)
        {
            Wm = wm;
        }

        protected bool checkExistanceOfReferent(IObj obj, string referenceName, string referentName)
        {
            bool result = false;
            bool hasRef = obj.References.Count(e => e.Name == referenceName) > 0;
            if (hasRef)
            {
                List<Reference> neededObjRefs = obj.References.Where(e => e.Name == referenceName).ToList();
                if (neededObjRefs.Count >= 0)
                {
                    foreach (Reference reference in neededObjRefs)
                    {
                        Obj referent = reference.From;
                        if (referent == obj)
                        {
                            referent = reference.To;
                        }
                        if (referent.Name == referentName)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        abstract protected void DoWhithElementOnPath(IObj obj);
    }
}
