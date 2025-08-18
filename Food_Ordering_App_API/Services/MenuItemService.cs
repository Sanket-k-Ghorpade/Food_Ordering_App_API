using AutoMapper;
using Food_Ordering_App_API.DTOs.Menu_Item_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;

namespace Food_Ordering_App_API.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public IEnumerable<MenuItemDto> GetAllItems()
        {
            var itemsQuery = _menuItemRepository.GetAll();
            return _mapper.ProjectTo<MenuItemDto>(itemsQuery).ToList();
        }

        public MenuItemDto GetItemById(int id)
        {
            var item = _menuItemRepository.GetById(id);
            return _mapper.Map<MenuItemDto>(item);
        }

        public IEnumerable<MenuItemDto> SearchItems(string keyword)
        {
            var itemsQuery = _menuItemRepository.GetAll()
                .Where(mi => mi.MenuItemName.Contains(keyword));
            return _mapper.ProjectTo<MenuItemDto>(itemsQuery).ToList();
        }

        public MenuItemDto AddMenuItem(MenuItemCreateDto menuItemDto)
        {
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            _menuItemRepository.Add(menuItem);
            _menuItemRepository.SaveChanges();
            return _mapper.Map<MenuItemDto>(menuItem);
        }

        public MenuItemDto UpdateMenuItem(int id, MenuItemUpdateDto menuItemDto)
        {
            var itemFromRepo = _menuItemRepository.GetById(id);
            if (itemFromRepo == null) return null;

            _mapper.Map(menuItemDto, itemFromRepo);
            _menuItemRepository.Update(itemFromRepo);
            _menuItemRepository.SaveChanges();

            return _mapper.Map<MenuItemDto>(itemFromRepo);
        }

        public bool DeleteMenuItem(int id)
        {
            var itemFromRepo = _menuItemRepository.GetById(id);
            if (itemFromRepo == null) return false;

            _menuItemRepository.Delete(itemFromRepo);
            return _menuItemRepository.SaveChanges();
        }
    }
}
