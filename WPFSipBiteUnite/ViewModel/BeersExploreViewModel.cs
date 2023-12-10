// BeersExploreViewModel.cs
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
    public class BeersExploreViewModel : ViewModelBase
    {
        private IBeerRepository beerRepository;
        public BeersExploreViewModel()
        {
            beerRepository = new BeerRepository(new ApplicationDbContext());
            Beers = new ObservableCollection<Beer>(beerRepository.GetAllBeers());
        }

        private ObservableCollection<Beer> _beers;
        public ObservableCollection<Beer> Beers
        {
            get { return _beers; }
            set
            {
                _beers = value;
                OnPropertyChanged(nameof(Beers));
            }
        }

    }
}
