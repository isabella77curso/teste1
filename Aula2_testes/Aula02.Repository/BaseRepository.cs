using Aula02.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Aula02.Repository
{
    public abstract class BaseRepository<T> where T: Entity
    {
        private List<T> _lista;

        protected List<T> Lista
        {
            get
            {
                if (_lista == null)
                {
                    _lista = new List<T>();
                    PopularLista();
                }
                return _lista;
            }
        }

        protected abstract void PopularLista();

        public IEnumerable<T> GetAll()
        {
            return Lista;
        }

        public T GetById(int id)
        {
            return Lista.FirstOrDefault(x => x.Id == id);
        }

        public void Save(T entity)
        {
            var p = Lista.Max(x => x.Id);
            entity.Id = p + 1;

            Lista.Add(entity);
        }

        public void Update(T entity)
        {
            var p = GetById(entity.Id);
            if (p == null) return;

            var index = Lista.IndexOf(p);
            Lista[index] = entity;
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            if (p == null) return;

            Lista.Remove(p);
        }
    }
}
