using AutoMapper;
using Idealeware.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Idealeware.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoModel>();
            CreateMap<Categoria, CategoriaModel>();
            CreateMap<ProdutoModel, Produto>();
            CreateMap<CategoriaModel, Categoria>();
        }
    }
}
