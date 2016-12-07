using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using SemanticIntellectualInformationalSystem.WorkingMemory;

namespace SemanticIntellectualInformationalSystem.LogicalOutputMechanism.AnswerFinders
{
    class IsEngineTypeAPartOfCar : AnswerFinder
    {
        private bool result = false;
        private string engineType;
        public IsEngineTypeAPartOfCar(WM wm) : base(wm) { }
        public bool Answer(string engineType, string car)
        {
            this.engineType = engineType;

            IObj start = Wm.Objects.First(e => e.Name == car);
            IObj goal = Wm.Objects.First(e => e.Name == "двигатель");
            List<string> whenMakeRefRevert = new List<string> { "part_of" };
            searcher.MakeDepthSearch(start, goal, false, DoWhithElementOnPath, whenMakeRefRevert);

            bool res = result;
            result = false;
            return res;
        }
        protected override void DoWhithElementOnPath(IObj obj)
        {
            bool checking = checkExistanceOfReferent(obj, "is_a", "двигатель") ||
                checkExistanceOfReferent(obj, "is_instance", "двигатель");
            if (checking)
            {
                if (obj.Name == engineType)
                {
                    result = true;
                }
            }
        }
    }
}
