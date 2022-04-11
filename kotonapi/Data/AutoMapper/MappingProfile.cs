using AutoMapper;
using koton.api.Data.Models;
using Koton.api.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.api.Data.AutoMapper
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Product, ProductDto>().ReverseMap();
         
        }
    }
}
