using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using BLLSipBiteUnite;
using BLLSipBiteUnite.Services;
using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.DbContext;
using DALSipBiteUnite.Repositories;

namespace WPFSipBiteUnite.ViewModel
{
    public class DishesExploreViewModel : ViewModelBase
    {
        private IFoodRepository foodRepository;

        public DishesExploreViewModel()
        {
            foodRepository = new FoodRepository(new ApplicationDbContext());
            Dishes = new ObservableCollection<Food>(foodRepository.GetAllFoods());
        }

        private ObservableCollection<Food> _dishes;
        public ObservableCollection<Food> Dishes
        {
            get { return _dishes; }
            set
            {
                _dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }
    }
}
