using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Idealeware.Service.Interfaces;
using Idealeware.Service.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idealeware.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    [EnableCors("politica")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _produtoRepository.Select()) { StatusCode = 200 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new ObjectResult(await _produtoRepository.SelectById(id)) { StatusCode = 200 };
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> GetByCategoria(int id)
        {
            return new ObjectResult(await _produtoRepository.SelectByCategoriaId(id)) { StatusCode = 200 };
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody]ProdutoModel modelo)
        {
            if (ModelState.IsValid)
            {
                var produto = await _produtoRepository.Insert(_mapper.Map<Produto>(modelo));
                return new ObjectResult(produto) { StatusCode = 200 };
            }
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProdutoModel modelo)
        {
            if (ModelState.IsValid)
            {
                var produto = await _produtoRepository.Update(_mapper.Map<Produto>(modelo));
                return new ObjectResult(produto) { StatusCode = 200 };
            }
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            if(id != 0)
                return new ObjectResult(new { Id = await _produtoRepository.Remove(id) }) { StatusCode = 200 };
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };
        }
    }
}