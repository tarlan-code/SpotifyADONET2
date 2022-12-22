using Spotifty.Abstractions;
using Spotifty.Models;
using Spotifty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Contexts
{
    internal class Context
    {
        IService<Musics> _musics;
        IService<Artists> _artists;
        IService<Users> _users;
        IService<Roles> _roles;
        IService<Categories> _categories;

        public IService<Musics> Musics { get
            {
                if (_musics == null) _musics = new MusicServices();
                return _musics;
            }
        }

        public IService<Artists> Artists { get 
            {
                if (_artists == null) _artists = new ArtistServices();
                return _artists;
            } 
        }

        public IService<Users> Users {
            get
            {
                if (_users == null) _users = new UsersServices();
                return _users;
            }
        }
        public IService<Roles> Roles {
            get
            {
                if (_roles == null) _roles = new RolesServices();
                return _roles;
            }
        }

        public IService<Categories> Categories {
            get
            {
                if (_categories == null) _categories = new CategoriesServices();
                return _categories;
            }
        }




    }
}
