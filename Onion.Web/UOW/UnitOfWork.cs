using Onion.Data.Access;
using Onion.Data.Account;
using Onion.Data.Music;
using Onion.Data.Site;
using Onion.Repository.ApplicationContext;
using Onion.Repository.DataTransfer;
using Onion.Service.Implementation;
using Onion.Service.Interfaces;

namespace Onion.Web.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnionContext context;

        public UnitOfWork(OnionContext context)
        {
            this.context = context;
        }


        private IUserService _userService;

        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new UserService(new Repository<User>(context), new Repository<UserRole>(context));
                }

                return _userService;
            }
        }


        private IRoleService _roleService;

        public IRoleService RoleService
        {
            get
            {
                if (_roleService == null)
                {
                    _roleService = new RoleService(new Repository<Role>(context));
                }

                return _roleService;
            }
        }


        private ISliderService _sliderService;

        public ISliderService SliderService
        {
            get
            {
                if (_sliderService == null)
                {
                    _sliderService = new SliderService(new Repository<Slider>(context));
                }

                return _sliderService;
            }
        }

        private ISingerService _singerService;

        public ISingerService SingerService
        {
            get
            {
                if (_singerService == null)
                {
                    _singerService = new SingerService(new Repository<Singer>(context));
                }

                return _singerService;
            }
        }

        private ISongService _songService;

        public ISongService SongService
        {
            get
            {
                if (_songService == null)
                {
                    _songService = new SongService(new Repository<Song>(context), new Repository<SongLike>(context), new Repository<SongVisit>(context));
                }

                return _songService;
            }
        }


        public void Dispose()
        {
            context?.Dispose();
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}