using SemanticIntellectualInformationalSystem.KnowledgeBase;
using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.LogicalOutputMechanism
{
    public class DepthSearch
    {
        private HashSet<IObj> visited;
        private IObj start;
        private IObj goal;
        private DoWhithElementOnPath action;

        public bool MakeDepthSearch(IObj start, IObj goal,
            DoWhithElementOnPath action)
        {
            visited = new HashSet<IObj>();
            this.start = start;
            this.goal = goal;
            this.action = action;
            return MakeDepthSearch(start);
        }

        private bool MakeDepthSearch(IObj obj)
        {
            if (obj == goal)
            {
                return true;
            }
            visited.Add(obj);
            List<IObj> referentialObjs = GetReferentialObjs(obj);
            foreach (var referent in referentialObjs.Where(x => !visited.Contains(x)))
            {
                if (MakeDepthSearch(referent))
                {
                    action(obj);
                    return true;
                }
            }
            return false;
        }

        private List<IObj> GetReferentialObjs(IObj target)
        {
            List<IObj> result = new List<IObj>();
            foreach (Reference reference in target.References)
            {
                IObj refObj = reference.From;
                if (refObj == target)
                {
                    result.Add(reference.To);
                }
            }
            return result;
        }
    }
}
