namespace Weather.Application.Utils;

using AutoMapper;
using Weather.Application.Measures.Responses;
using Weather.Domain;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Measure, MeasureResponse>();
    }
}