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
    [Route("api/Categoria")]
    [EnableCors("politica")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._categoriaRepository = categoriaRepository;
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _categoriaRepository.Select()) { StatusCode = 200 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return new ObjectResult(await _categoriaRepository.SelectById(id)) { StatusCode = 200 };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaModel modelo)
        {
            if (ModelState.IsValid)
            {
                var categoria = await _categoriaRepository.Insert(_mapper.Map<Categoria>(modelo));
                return new ObjectResult(categoria) { StatusCode = 200 };
            }
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };           
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoriaModel modelo)
        {
            if (ModelState.IsValid)
            {
                var categoria = await _categoriaRepository.Update(_mapper.Map<Categoria>(modelo));
                return new ObjectResult(categoria) { StatusCode = 200 };
            }
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var produtos = await _produtoRepository.SelectByCategoriaId(id);
                if(produtos.Count() > 0)
                    return new ObjectResult(await _categoriaRepository.Inactivate(id)) { StatusCode = 200 };
                return new ObjectResult(await _categoriaRepository.Remove(id)) { StatusCode = 200 };

            }
            else
                return new ObjectResult(new { Erro = "Dados Invalidos" }) { StatusCode = 401 };
        }
    }
}