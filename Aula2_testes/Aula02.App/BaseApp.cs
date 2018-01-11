using Aula02.Domain;
using Aula02.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula02.App
{
    public abstract class BaseApp<T> where T: Entity
    {
        protected BaseRepository<T> Repository;

        protected BaseApp(BaseRepository<T> repository)
        {
            Repository = repository;
        }

        protected abstract void ValidateSave(T entity, StringBuilder sb);
        protected abstract void ValidateUpdate(T entity, StringBuilder sb);
        protected abstract void ValidateDelete(int id, StringBuilder sb);

        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public void Save(T entity)
        {
            var ret = new StringBuilder();
            ValidateSave(entity, ret);

            if (ret.Length > 0)
                throw new Exception(ret.ToString());

            Repository.Save(entity);
        }

        public void Update(T entity)
        {
            var ret = new StringBuilder();
            ValidateUpdate(entity, ret);
            if (entity.Id <= 0)
                ret.Append("Id ser maior que zero!");

            if (ret.Length > 0)
                throw new Exception(ret.ToString());

            Repository.Update(entity);
        }

        public void Delete(int id)
        {
            var ret = new StringBuilder();
            ValidateDelete(id, ret);
            if (id <= 0)
                ret.Append("Id ser maior que zero!");


            if (ret.Length > 0)
                throw new Exception(ret.ToString());

            Repository.Delete(id);
        }




    }
}
