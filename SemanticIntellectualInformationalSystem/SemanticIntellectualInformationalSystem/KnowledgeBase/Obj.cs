using SemanticIntellectualInformationalSystem.KnowledgeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticIntellectualInformationalSystem.KnowledgeBase
{
    public class Obj : IObj
    {
        public string Name { get; }
        public string Id { get; }
        private List<Reference> _references;
        public Obj(string id, string name)
        {
            Id = id;
            Name = name;
            _references = new List<Reference>();
        }
        public void AddReference(Reference reference)
        {
            //Для быстрой проверки наличия ссылки
            //можно хранить их упорядоченно (например по id) 
            bool makeAdding = !_references.Exists(e => e.Id == reference.Id);
            if (makeAdding)
            {
                _references.Add(reference);
            }
        }
        public IEnumerable<Reference> References
        {
            get
            {
                return _references.AsEnumerable();
            }
        }
    }
}

