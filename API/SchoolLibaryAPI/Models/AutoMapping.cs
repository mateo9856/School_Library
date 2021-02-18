using AutoMapper;
using SchoolLibaryAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Library, LibraryDto>()
                .ReverseMap();

            CreateMap<Loans, LoanDto>()
                .ReverseMap();
        }
    }
}
