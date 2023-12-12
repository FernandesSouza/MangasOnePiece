using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using OnePiece.Domain.DTOs;
using OnePiece.Domain.Models;

namespace OnePiece.Applications.Mappings
{
    public class MappingDTOs : Profile
    {

        public MappingDTOs()
        {

            CreateMap<MangasModel, MangaDto>();                

        }


    }
}
