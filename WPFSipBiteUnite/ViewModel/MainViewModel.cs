// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.ViewModel
{
    // Make sure to remove any unused using directives
    using System.Windows.Input;

    /// <summary>
    /// ViewModel for the MainView.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView = null!;
        private string _caption = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.ShowBeersExploreViewCommand = new ViewModelCommand(this.ExecuteShowBeersExploreViewCommand);
            this.ShowFoodsExploreViewCommand = new ViewModelCommand(this.ExecuteShowBeersExploreViewCommand);
            this.ShowDishesExploreViewCommand = new ViewModelCommand(this.ExecuteShowDishesExploreViewCommand);
            this.ShowUnsignedProfileViewCommand = new ViewModelCommand(this.ExecuteShowUnsignedProfileViewCommand);

            this.ExecuteShowBeersExploreViewCommand(null);
        }

        /// <summary>
        /// Gets or sets the current child view model.
        /// </summary>
        public ViewModelBase CurrentChildView
        {
            get => this._currentChildView;
            set
            {
                this._currentChildView = value;
                this.OnPropertyChanged(nameof(this.CurrentChildView));
            }
        }

        /// <summary>
        /// Gets or sets the caption of the current view.
        /// </summary>
        public string Caption
        {
            get => this._caption;
            set
            {
                this._caption = value;
                this.OnPropertyChanged(nameof(this.Caption));
            }
        }

        /// <summary>
        /// Gets the command to show the BeersExploreView.
        /// </summary>
        public ICommand ShowBeersExploreViewCommand { get; private set; }

        /// <summary>
        /// Gets the command to show the FoodsExploreView.
        /// </summary>
        public ICommand ShowFoodsExploreViewCommand { get; private set; }

        /// <summary>
        /// Gets the command to show the DishesExploreView.
        /// </summary>
        public ICommand ShowDishesExploreViewCommand { get; private set; }

        /// <summary>
        /// Gets the command to show the UnsignedProfileView.
        /// </summary>
        public ICommand ShowUnsignedProfileViewCommand { get; private set; }

        private void ExecuteShowDishesExploreViewCommand(object obj)
        {
            this.CurrentChildView = new DishesExploreViewModel();
            this.Caption = "Страви";
        }

        private void ExecuteShowBeersExploreViewCommand(object? obj)
        {
            this.CurrentChildView = new BeersExploreViewModel();
            this.Caption = "Пиво";
        }

        private void ExecuteShowUnsignedProfileViewCommand(object obj)
        {
            this.CurrentChildView = new UnsignedProfileViewModel();
            this.Caption = "Профіль";
        }
    }
}