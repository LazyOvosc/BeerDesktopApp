using System;
using System.Threading;
using System.Windows.Forms;
using DALSipBiteUnite.DataBaseClasses;
using WPFSipBiteUnite.DbContext;
using WPFSipBiteUnite.Models;
using WPFSipBiteUnite.Repositories;
using IUserRepository = WPFSipBiteUnite.Repositories.IUserRepository;

namespace WPFSipBiteUnite.ViewModel
{
    public class ProfileViewModel:ViewModelBase
    {
        private ProfileModel _user;
        private IUserRepository userRepository;
        public ProfileModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ProfileViewModel()
        {
            userRepository = new UserRepository(new ApplicationDbContext());
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetUserByName(Thread.CurrentPrincipal.Identity.Name);
            if (user is not null)
            {
                User = new ProfileModel()
                {
                    Name = user.name,
                    DisplayName = $"Welcome {user.name};)"
                };
            }
            else
            {
                MessageBox.Show("Invalid User");
            }
        }
    }
}

