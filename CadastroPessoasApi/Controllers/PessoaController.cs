﻿using CadastroPessoasApi.Service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);
        }
        [HttpGet("GetByprimeiroNome/{primeiroNome}")]
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByprimeiroNome(primeiroNome);
        }
        [HttpPut("Update/{pessoaId}/{primeiroNome}")]
        public void Update(int pessoaId, string primeiroNome)
        {
            var service = new ServicePessoa();
            service.Update(pessoaId, primeiroNome);
        }
        [HttpPost("Create")]
        public IActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            if (resultado == null)
            {
                var result = new
                {
                    Success =true,
                    Data = "Cadastrado com sucesso",
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    Success = true,
                    Data = resultado,
                };
                return Ok(result);
            }

           
        }
    }
}