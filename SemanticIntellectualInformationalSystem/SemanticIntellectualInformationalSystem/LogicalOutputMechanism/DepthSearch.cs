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
        List<string> whenMakeRefRevert = null;
        private bool findSeveralPaths;
        private DoWhithElementOnPath action;

        public bool MakeDepthSearch(IObj start, IObj goal, bool findSeveralPaths,
            DoWhithElementOnPath action, List<string> whenMakeRefRevert = null)
        {
            visited = new HashSet<IObj>();
            this.start = start;
            this.goal = goal;
            this.findSeveralPaths = findSeveralPaths;
            this.action = action;
            this.whenMakeRefRevert = whenMakeRefRevert;
            return MakeDepthSearch(start);
        }

        private bool checkOfFindingSevPathsNeed(IObj obj)
        {
            if (findSeveralPaths)
                return obj != start;
            return true;
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
                    if (checkOfFindingSevPathsNeed(obj))
                    {
                        action(obj);
                        return true;
                    }
                }
            }
            return false;
        }

        private List<IObj> GetReferentialObjs(IObj target)
        {
            List<IObj> result = new List<IObj>();
            foreach (Reference reference in target.References)
            {
                bool makeRevert = false;
                if (whenMakeRefRevert != null)
                {
                    makeRevert = whenMakeRefRevert.Count(e => e == reference.Name) > 0;
                }

                Obj refObj = null;
                if (makeRevert)
                {
                    refObj = reference.To;
                    if (refObj == target)
                    {
                        result.Add(reference.From);
                    }
                    continue;
                }

                refObj = reference.From;
                if (refObj == target)
                {
                    result.Add(reference.To);
                }
            }
            return result;
        }
    }
}
