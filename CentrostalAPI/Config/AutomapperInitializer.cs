using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DTOs;
using CentrostalAPI.Models;

namespace CentrostalAPI.Config {
    public class MapperInitializer : Profile {
        public MapperInitializer() {
            CreateMap<User, UserLoginRequestDTO>().ReverseMap();

            CreateMap<User, UserLoginResponseDTO>()
                .ForMember(a => a.userId,
                    s => s.MapFrom(b => b.id));


            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<User, UserPublicInfoDTO>().ReverseMap();


            CreateMap<ItemTemplate, ItemTemplateResponseDTO>()
                 .ForMember(a => a.currents,
                    s => s.MapFrom(x =>
                        x.currents.Select(a => a.current)))
                 .ForMember(a => a.steelTypes,
                    s => s.MapFrom(x =>
                        x.steelTypes.Select(a => a.steelType.typeName)));

            CreateMap<Item, ItemDTO>()
                .ForMember(a => a.steelType,
                    s => s.MapFrom(x => x.steelType.typeName))
                .ForMember(a => a.number,
                    s => s.MapFrom(x => x.itemTemplate.number))
                .ForMember(a => a.name,
                    s => s.MapFrom(x => x.itemTemplate.name));



            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<Order, OrderDTO>()
                .ForMember(a => a.orderingPerson,
                    s => s.MapFrom(x => x.orderingUser.ToString()))
                .ForMember(a => a.status,
                    s => s.MapFrom(x => x.status.name));
        }
    }
}
