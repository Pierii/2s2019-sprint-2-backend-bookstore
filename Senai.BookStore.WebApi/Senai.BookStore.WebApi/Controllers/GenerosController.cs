using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            return GeneroRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }
    }
}