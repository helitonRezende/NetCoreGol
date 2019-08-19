using Microsoft.EntityFrameworkCore;
using GOL.EntityFrameWork.Repositorio.Models;

namespace GOL.EntityFrameWork.Repositorio.Repositorio
{

    public class Contexto : DbContext
    {
        public Contexto() : base(){}

        public DbSet<AIRPLANE> AIRPLANE { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ControleConexao.ConexaoSQL.ToString());
        }

    }

    public class ControleConexao
    {
        public static string ConexaoSQL;
        public static string erroSQL;
    }

}
