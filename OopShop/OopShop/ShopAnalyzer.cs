using System;
using System.Collections.Generic;

namespace OopShop
{
    class ShopAnalyzer
    {
        private List<Shop> shops = new List<Shop>();

        public void AddShop(Shop shop)
        {
            shops.Add(shop);
        }

        public void PrintShopWithMinProdPrice(string name)
        {
            float FoundPrice = Int32.MaxValue;
            string FoundShop = null;
            string FoundID = null;
            foreach(var shop in shops)
            {
                foreach (var product in shop.products)
                {
                    if (product.Name == name)
                    {
                        if (product.Price < FoundPrice)
                        {
                            FoundPrice = product.Price;
                            FoundShop = shop.Name;
                            FoundID = Convert.ToString(shop.ID);
                        }
                    }
                }
            }
            if(FoundShop == null)
                Console.WriteLine($"Have not found shop with lowest price of this product: {name}");
            else
                Console.WriteLine($"Shop with minimum price of {name} is {FoundShop} (product id: {FoundID}), price: {FoundPrice}");
        }

        public void WhatCanBuy(Shop shop, float cost)
        {
            foreach(var product in shop.products)
            {
                int amount = (int)(cost / product.Price);
                if(!(amount <= 0))
                    Console.WriteLine($"You can buy {amount} of {product.Name}");
            }
        }

        public void BuyManyProducts(Shop shop, string productName, int productAmount)
        {
            int localProductAmount = 0;
            float price = 0;
            foreach(var product in shop.products)
            {
                if(product.Name == productName)
                {
                    localProductAmount++;
                    price = product.Price;
                }
            }

            if(localProductAmount >= productAmount)
                Console.WriteLine($"You have bought {productAmount} of {productName} for {price*productAmount}");
            else
                Console.WriteLine($"Not enough of product {productName} in the {shop.Name} shop");
        }

        public void WhichShopHasCheaperProducts(string productName, int productAmount)
        {
            string bestShop = null;
            float bestCost = Int32.MaxValue;
            foreach(var shop in shops)
            {
                string shopName = shop.Name;
                int localProductAmount = 0;
                float price = 0;
                foreach(var product in shop.products)
                {
                    if(product.Name == productName)
                    {
                        localProductAmount++;
                        price = product.Price;
                    }
                }
                float cost = price * localProductAmount;
                if (cost < bestCost && cost != 0 && localProductAmount >= productAmount)
                {
                    bestShop = shop.Name;
                    bestCost = cost;
                }
            }
            if(bestCost != Int32.MaxValue && bestShop != null)
                Console.WriteLine($"The best shop for you is {bestShop}, you need to pay {bestCost}");
            else
                Console.WriteLine("There is no suitable shops for you");
        }
    }
}