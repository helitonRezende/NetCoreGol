using System;
using System.Collections.Generic;
using System.Linq;

namespace GOL.EntityFrameWork.Repositorio.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly Contexto db;

        public RepositorioGenerico()
        {
            db = new Contexto();
        }
        public T Add(T obj)
        {
            try
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch (Exception erro)
            {
                ControleConexao.erroSQL = erro.ToString();
            }
            return null;
        }
        public List<T> GetAll()
        {
            try
            {
                return db.Set<T>().ToList();
            }
            catch (Exception erro)
            {
                ControleConexao.erroSQL = erro.ToString();
            }
            return null;
        }
        public T GetById(int id)
        {
            try
            {
                return db.Set<T>().Find(id);
            }
            catch (Exception erro)
            {
                ControleConexao.erroSQL = erro.ToString();
            }
            return null;
        }
        public T Update(T obj)
        {
            try
            {
                db.Set<T>().Update(obj);
                db.SaveChanges();
                return obj;

            }
            catch (Exception erro)
            {
                ControleConexao.erroSQL = erro.ToString();
            }
            return null;
        }
    }
}