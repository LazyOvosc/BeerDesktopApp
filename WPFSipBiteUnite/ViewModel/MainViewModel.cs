
using BLLSipBiteUnite.Services;
using DALSipBiteUnite.Repositories;
using System.Windows.Input;
using WPFSipBiteUnite.ViewModel;

namespace WPFSipBiteUnite.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// Fields
        // private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;


        // private IUserRepository userRepository;


        /// Properties
        // public UserAccountModel CurrentUserAccount
        // {
        //     get { return _currentUserAccount; }
        //
        //     set
        //     {
        //         _currentUserAccount = value;
        //         OnPropertyChanged(nameof(CurrentUserAccount));
        //     }
        // }

        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get { return _caption; }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        

        /// --> Commands - to show the beersexploreview...
        public ICommand ShowBeersExploreViewCommand { get; }
        public ICommand ShowFoodsExploreViewCommand { get; }
        public ICommand ShowDishesExploreViewCommand { get; }
        public ICommand ShowUnsignedProfileViewCommand { get; }

        public MainViewModel()
        {
            // userRepository = new UserRepository();
            // Initialize commands
            ShowBeersExploreViewCommand = new ViewModelCommand(ExecuteShowBeersExploreViewCommand);
            ShowFoodsExploreViewCommand = new ViewModelCommand(ExecuteShowBeersExploreViewCommand);
            ShowDishesExploreViewCommand = new ViewModelCommand(ExecuteShowDishesExploreViewCommand);
            ShowUnsignedProfileViewCommand = new ViewModelCommand(ExecuteShowUnsignedProfileViewCommand);

            //Default view
            ExecuteShowBeersExploreViewCommand(null);

            // LoadCurrentUserData();
        }

        private void ExecuteShowDishesExploreViewCommand(object obj)
        {
            CurrentChildView = new DishesExploreViewModel();
            Caption = "Страви";
        }


        private void ExecuteShowBeersExploreViewCommand(object obj)
        {
            CurrentChildView = new BeersExploreViewModel();
            Caption = "Пиво";
        }

        private void ExecuteShowUnsignedProfileViewCommand(object obj)
        {
            CurrentChildView = new UnsignedProfileViewModel();
            Caption = "Профіль";
        }
    }
}

