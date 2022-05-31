using System.Collections.Generic;
using System.Linq;
using MainProject.Contracts.Entities;
using MainProject.Contracts.Entities.ValueObjects;
using MainProject.Contracts.Externals;

namespace MainProject.Services
{
    internal sealed class ItemConverter
    {
        public Item[] ConvertItems(List<ItemDto> dtoItems)
        {
            var items = new Item[dtoItems.Count];

            for (int i = 0; i < dtoItems.Count; i++)
            {
                var sellers = new List<Seller>(dtoItems[i].SellerIds.Length);
                for (int j = 0; j < dtoItems[i].SellerIds.Length; j++)
                {
                    sellers.Add(new Seller(dtoItems[i].SellerIds[j], string.Empty));
                }
                
                var item = new Item
                {
                    Id = dtoItems[i].Id,
                    Price = new Price
                    {
                        Currency = dtoItems[i].PriceCurrency,
                        Value = dtoItems[i].PriceValue
                    },
                    Sellers = sellers,
                    VolumeWeight = new VolumeWeightData
                    {
                        Height = dtoItems[i].Height,
                        Length = dtoItems[i].Length,
                        Weight = dtoItems[i].Weight,
                        Width = dtoItems[i].Width,
                        PackagedHeight = dtoItems[i].PackagedHeight,
                        PackagedLength = dtoItems[i].PackagedLength,
                        PackagedWeight = dtoItems[i].PackagedWeight,
                        PackagedWidth = dtoItems[i].PackagedWidth
                    },
                    SaleInfo = new SaleInfo
                    {
                        Rating = dtoItems[i].Rating,
                        IsActive = dtoItems[i].IsActive,
                        IsBestSeller = dtoItems[i].IsBestSeller
                    }
                };

                items[i] = item;
            }

            return items;
        }
    }
}