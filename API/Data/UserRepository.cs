

using API.DTO;
using API.Entity;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;

        public UserRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerAsync(string username)
        {
            return await _dataContext.Users
                    .Where(x => x.Username == username)
                    .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
        }

        public async Task<PagedList<CustomerDto>> GetCustomersAsync(UserParams userParams)
        {
            var query =  _dataContext.Users
                    .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                    .AsNoTracking();
            
            return await PagedList<CustomerDto>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users
                            .Include(u => u.ShoppingCart)
                                .ThenInclude(sc => sc.CartItems)
                            .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void Update(AppUser appUser)
        {
            _dataContext.Entry(appUser).State = EntityState.Modified;
        }
    }
}