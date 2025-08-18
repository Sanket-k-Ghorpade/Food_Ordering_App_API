using AutoMapper;
using Food_Ordering_App_API.DTOs.Delivery_Partner_DTOs;
using Food_Ordering_App_API.DTOs.Discount_Rule_DTOs;
using Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs;
using Food_Ordering_App_API.DTOs.Menu_Item_DTOs;
using Food_Ordering_App_API.DTOs.Order_DTOs;
using Food_Ordering_App_API.DTOs.User_DTOs;
using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.AutoMapper
{


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // AutoMapper will automatically map properties with the same name.
            // It's smart enough to handle the nested list mapping as well.
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuItem, MenuItemDtoForMenu>();
            CreateMap<MenuItemCreateDtoForMenu, MenuItem>();
            CreateMap<MenuUpdateDto, Menu>();
            CreateMap<MenuCreateDto, Menu>();

            // MenuItem Mapping
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItemCreateDto, MenuItem>();
            CreateMap<MenuItemUpdateDto, MenuItem>();

            // Delivery Partner Mapping
            CreateMap<DeliveryPartner, DeliveryPartnerDto>();
            CreateMap<DeliveryPartnerCreateDto, DeliveryPartner>();
            CreateMap<DeliveryPartnerUpdateDto, DeliveryPartner>();

            // Discount Rule Mapping
            CreateMap<DiscountRule, DiscountRuleDto>();
            CreateMap<DiscountRuleCreateDto, DiscountRule>();
            CreateMap<DiscountRuleUpdateDto, DiscountRule>();


            // Order Mappings
            CreateMap<Order, OrderDto>()
                // Convert the enum to a string for clean JSON
                .ForMember(dest => dest.PaymentMode, opt => opt.MapFrom(src => src.PaymentMode.ToString()));

            CreateMap<OrderItem, OrderItemDto>()
                // Get the name from the related MenuItem navigation property
                .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem.MenuItemName))
                // Calculate the total for this line item
                .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.Quantity * src.Price));

            CreateMap<OrderUpdateDto, Order>();
            CreateMap<DeliveryPartner, OrderDeliveryPartnerDto>();

            // User Mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRole.Role.ToString()));

            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
