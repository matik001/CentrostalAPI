using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DTOs;

namespace CentrostalAPI.Config {
    public class MapperInitializer : Profile {
        public MapperInitializer() {
            CreateMap<User, UserLoginRequestDTO>().ReverseMap();

            CreateMap<User, UserLoginResponseDTO>()
                .ForMember(a => a.userId,
                    s => s.MapFrom(b => b.id));


            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<User, UserPublicInfoDTO>().ReverseMap();


            CreateMap<Item, ItemDTO>()
                .ForMember(a => a.steelType,
                    s => s.MapFrom(x => x.steelType.typeName));
            CreateMap<CreateItemDTO, Item>()
                .ForMember(a => a.steelType, b => b.Ignore());
            CreateMap<UpdateItemDTO, Item>()
                .ForMember(a => a.steelType, b => b.Ignore());



            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<Status, StatusDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ForMember(a => a.orderingPerson,
                    s => s.MapFrom(x => x.orderingUser.ToString()))
                .ForMember(a => a.status,
                    s => s.MapFrom(x => x.status));
        }
    }
}
