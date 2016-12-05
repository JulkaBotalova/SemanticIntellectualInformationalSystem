using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using SemanticIntellectualInformationalSystem.LogicalOutputMechanism.AnswerFinders;
using SemanticIntellectualInformationalSystem.WorkingMemory;
using SemanticIntellectualInformationalSystem.WorkingMemoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemanticIntellectualInformationalSystem.LogicalOutputMechanism
{
    public class LOM
    {
        private WhatIsQualityOfCar whatIsQualityOfCarFinder;
        public LOM()
        {
            WM wm = WMFactory.CreateWM();
            whatIsQualityOfCarFinder = new WhatIsQualityOfCar(wm);

            List<IObj> cars = wm.Objects.Where(e => e.References.ElementAt(e.References.Count() - 1).To.Name == "Автомобиль").ToList();
            foreach (IObj car in cars)
            {
                if (car.Name == "Автомобиль")
                    continue;
                MessageBox.Show(car.Name + ": " + WhatIsQualityOfCar(car.Name));
            }
        }
        public string WhatIsQualityOfCar(string carName)
        {
            return whatIsQualityOfCarFinder.Answer(carName);
        }
    }
}
