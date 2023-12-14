// <copyright file="BeersExploreViewModel.cs" company="PlaceholderCompany">
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
    /// ViewModel for the BeersExploreView.
    /// </summary>
    public class BeersExploreViewModel : ViewModelBase
    {
        private IBeerRepository beerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BeersExploreViewModel"/> class.
        /// </summary>
        #pragma warning disable
        public BeersExploreViewModel()
        {
            this.beerRepository = new BeerRepository(new ApplicationDbContext());
            /// <summary>
            /// Gets the collection of beers.
            /// </summary>
            this.Beers = new ObservableCollection<Beer>(list: this.beerRepository.GetAllBeers());
        }

        private ObservableCollection<Beer> _beers;

        public ObservableCollection<Beer> Beers
        {
            get => _beers;

            set
            {
                this._beers = value;
                this.OnPropertyChanged(nameof(this.Beers));
            }
        }
    }
}
