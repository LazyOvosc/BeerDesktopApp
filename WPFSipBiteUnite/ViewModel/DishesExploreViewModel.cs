// <copyright file="DishesExploreViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using BLLSipBiteUnite;
    using BLLSipBiteUnite.Services;
    using DALSipBiteUnite.DataBaseClasses;
    using DALSipBiteUnite.DbContext;
    using DALSipBiteUnite.Repositories;

    /// <summary>
    /// ViewModel for the DishesExploreView.
    /// </summary>
    public class DishesExploreViewModel : ViewModelBase
    {
        private IFoodRepository foodRepository;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="DishesExploreViewModel"/> class.
        /// </summary>
        // private ObservableCollection<Food>? _dishes;
        private ObservableCollection<Food> _dishes = new ObservableCollection<Food>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DishesExploreViewModel"/> class.
        /// </summary>
        public DishesExploreViewModel()
        {
            this.foodRepository = new FoodRepository(new ApplicationDbContext());
            this.Dishes = new ObservableCollection<Food>(this.foodRepository.GetAllFoods());
            logger.Info("Користувач перейшов на сторінку DishesExploreView");
        }

        /// <summary>
        /// Gets or sets the collection of dishes.
        /// </summary>
        public ObservableCollection<Food> Dishes
        {
            get
            {
                return this._dishes;
            }

            set
            {
                this._dishes = value;
                this.OnPropertyChanged(nameof(this.Dishes));
            }
        }
    }
}
