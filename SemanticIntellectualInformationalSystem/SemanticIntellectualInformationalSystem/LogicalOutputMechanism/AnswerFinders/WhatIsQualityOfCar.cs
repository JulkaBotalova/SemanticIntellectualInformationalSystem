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
    public class WhatIsQualityOfCar : AnswerFinder
    {
        private string result = "";
        public WhatIsQualityOfCar(WM wm) : base(wm) { }
        public string Answer(string carName)
        {
            IObj start = Wm.Objects.First(e => e.Name == carName);
            IObj goal = Wm.Objects.First(e => e.Name == "Качество автомобиля");

            searcher.MakeDepthSearch(start, goal, DoWhithElementOnPath);

            string res = result;
            result = "";
            return res;
        }

        protected override void DoWhithElementOnPath(IObj obj)
        {
            if (checkExistanceOfReferent(obj, "is_a", "Качество автомобиля"))
            {
                result = obj.Name;
            }
        }
    }
}
