namespace DatingApp.Infrastructure.Repositories.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using Models.DTOs;
    using Models.Entities;

    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DatingDbContext context;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        public UserRepository(DatingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Update(AppUser user)
        {
            this.context.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
          return await this.context.Users
              .Include(p => p.Photos)
              .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await this.context.Users
                .Where(x => x.Id == id)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<MemberDto> GetMemberByUserName(string userName)
        {
            return await this.context.Users
                .Where(x => x.UserName == userName)
                .ProjectTo<MemberDto>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<AppUser> GetUserByUserName(string userName)
        {
            return await this.context.Users.Where(x => x.UserName == userName)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUserAsync(AppUser user)
        {
            await this.context.Users.AddAsync(user);
        }
    }
}