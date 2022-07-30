using AutoMapper;

namespace CartingApi.Profiles;

public class CartingServiceProfile : Profile
{
    public CartingServiceProfile()
    {
        CreateMap<Persistence.Models.Cart, DAL.Models.Cart>().ReverseMap();
        CreateMap<Persistence.Models.Item, DAL.Models.Item>().ReverseMap();
        CreateMap<Persistence.Models.Image, DAL.Models.Image>().ReverseMap();
    }
}
