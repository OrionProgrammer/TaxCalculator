namespace Tax.API.Helpers;

using AutoMapper;
using Tax.Domain;
using Tax.Model;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaxResult, TaxResultModel>().ReverseMap();
        CreateMap<TaxResult, TaxResultModel>();
    }
}
