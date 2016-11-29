using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemanticIntellectualInformationalSystem.KnowledgeBase
{
    public class KB
    {
        public IEnumerable<IObj> Objects { get; }
        public KB()
        {
            string filePath = "../../KnowledgeBaseFiles/KnowledgeBase.xml";
            //Dictionary<string, List<Reference>> ObjsWithIdsFromFile = new Dictionary<string, List<Reference>>();
            XDocument document = XDocument.Load(filePath);

            XElement objectsElem = document.Root.Element("objects");
            List<IObj> objects = new List<IObj>();
            foreach (XElement objElem in objectsElem.Elements("obj"))
            {
                string id = objElem.Element("id").Value;
                string name = objElem.Element("name").Value;
                objects.Add(new Obj(id, name));
            }

            XElement referencesElem = document.Root.Element("references");
            List<Reference> references = new List<Reference>();
            foreach(XElement referenceElem in referencesElem.Elements("reference"))
            {
                string id = referenceElem.Element("id").Value;
                string name = referenceElem.Element("name").Value;
                string fromId = referenceElem.Element("fromId").Value;
                Obj from = (Obj)objects.First(e => e.Id == fromId);
                string toId = referenceElem.Element("toId").Value;
                Obj to = (Obj)objects.First(e => e.Id == toId);
                Reference newReference = new Reference(id, name, from, to);
                from.AddReference(newReference);
                to.AddReference(newReference);
            }
            Objects = objects;
        }
    }
}
