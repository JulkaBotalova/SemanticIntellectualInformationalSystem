using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using SemanticIntellectualInformationalSystem.WorkingMemory;

namespace SemanticIntellectualInformationalSystem.LogicalOutputMechanism.AnswerFinders
{
    class WhichCarsMadeInCountry : AnswerFinder
    {
        private List<string> result = new List<string>();
        public WhichCarsMadeInCountry(WM wm) : base(wm) { }
        public List<string> Answer(string country)
        {
            IObj start = Wm.Objects.First(e => e.Name == country);
            IObj goal = Wm.Objects.First(e => e.Name == "Автомобиль");

            List<string> whenMakeRefRevert = new List<string> { "locative" };
            searcher.MakeDepthSearch(start, goal, true, DoWhithElementOnPath, whenMakeRefRevert);

            string[] res = new string[result.Count];
            result.CopyTo(res);
            result = new List<string>();
            return res.ToList();
        }
        protected override void DoWhithElementOnPath(IObj obj)
        {
            if (checkExistanceOfReferent(obj, "is_instance", "Автомобиль"))
            {
                result.Add(obj.Name);
            }
        }
    }
}
