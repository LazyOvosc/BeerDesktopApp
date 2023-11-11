using DALSipBiteUnite.DataBaseClasses;
using DALSipBiteUnite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLSipBiteUnite.Services
{
    public interface IShopService
    {
        void AddShop(Shop shop);
        void UpdateShop(Shop shop);
        void DeleteShop(int shopId);
        Shop GetShopById(int shopId);
        List<Shop> GetAllShops();
    }

    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public void AddShop(Shop shop)
        {
            _shopRepository.AddShop(shop);
        }

        public void UpdateShop(Shop shop)
        {
            _shopRepository.UpdateShop(shop);
        }

        public void DeleteShop(int shopId)
        {
            _shopRepository.DeleteShop(shopId);
        }

        public Shop GetShopById(int shopId)
        {
            return _shopRepository.GetShopById(shopId);
        }

        public List<Shop> GetAllShops()
        {
            return _shopRepository.GetAllShops();
        }
    }
}
