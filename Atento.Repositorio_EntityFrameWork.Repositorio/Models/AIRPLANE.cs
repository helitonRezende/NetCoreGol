using System;
using System.ComponentModel.DataAnnotations;

namespace GOL.EntityFrameWork.Repositorio.Models
{
    public class AIRPLANE
    {
        [Key]
        public int ID { get; set; }
        public string MODELO { get; set; }
        public int QTDEPASSAGEIRO { get; set; }
        public DateTime DATACRIACAO { get; set; }
    }
}
