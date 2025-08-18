using AutoMapper;
using Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;

namespace Food_Ordering_App_API.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public IEnumerable<MenuDto> GetAllMenus()
        {
            // 1. Get the IQueryable from the repository.
            var menusQuery = _menuRepository.GetAll();

            // 2. Use AutoMapper's ProjectTo to create an efficient query
            //    that selects only the needed columns, and then execute it.
            return _mapper.ProjectTo<MenuDto>(menusQuery).ToList();
        }

        public MenuDto GetMenuById(int id)
        {
            var menu = _menuRepository.GetById(id);
            return _mapper.Map<MenuDto>(menu);
        }

        public IEnumerable<MenuItem> GetMenuItems(int menuId) => _menuRepository.GetMenuItems(menuId);

        public MenuDto AddMenu(MenuCreateDto menuCreateDto)
        {
            // 1. Use AutoMapper to map the DTO to a new Menu entity
            var newMenu = _mapper.Map<Menu>(menuCreateDto);

            // 2. Tell the repository to add the new entity to the context
            _menuRepository.Add(newMenu);

            // 3. Commit the transaction to the database
            _menuRepository.SaveChanges();

            // 4. After saving, EF populates the 'newMenu' object with the generated ID.
            //    Now map it back to a MenuDto to return to the client.
            return _mapper.Map<MenuDto>(newMenu);
        }

        public MenuDto UpdateMenu(int id, MenuUpdateDto menuUpdateDto)
        {
            // 1. Fetch the existing entity from the database
            var menuFromRepo = _menuRepository.GetById(id);

            // 2. Check if it exists
            if (menuFromRepo == null)
            {
                return null; // Or throw an exception
            }

            // 3. Use AutoMapper to map the changes from the DTO onto the entity
            //    This updates the 'menuFromRepo' object in memory
            _mapper.Map(menuUpdateDto, menuFromRepo);

            // 4. Tell the repository to update the entity and save the changes
            _menuRepository.Update(menuFromRepo);
            _menuRepository.SaveChanges();

            // 5. Return the updated resource, mapped to a clean DTO
            return _mapper.Map<MenuDto>(menuFromRepo);
        }

        //public void DeleteMenu(int id) => _menuRepository.Delete(id);

        public bool DeleteMenu(int id)
        {
            var existing = _menuRepository.GetById(id);
            if (existing == null) return false;
            _menuRepository.Delete(existing);
            _menuRepository.SaveChanges();
            return true;
        }
    }

}
