using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using GOL.EntityFrameWork.Repositorio.Models;
using GOL.EntityFrameWork.Repositorio.Repositorio;

namespace GOL_NetCore_Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AirplaneController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AIRPLANE> Get()
        {
            return new RepositorioGenerico<AIRPLANE>().GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public AIRPLANE Get(int id)
        {
            return new RepositorioGenerico<AIRPLANE>().GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(AIRPLANE airplane)
        {
            airplane.DATACRIACAO = DateTime.Now;
            if (airplane.ID == 0)
            {
                new RepositorioGenerico<AIRPLANE>().Add(airplane);
            }
            else
            {
                new RepositorioGenerico<AIRPLANE>().Update(airplane);
            }
        }
    }
}
