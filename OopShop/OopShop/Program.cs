using System;

namespace OopShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start here");
            ShopBuilder sb = new ShopBuilder();
            sb.SetName("Cartier");
            sb.SetAddress("Moyka Quay, 5");

            ProductBuilder pb = new ProductBuilder();
            pb.SetName("Watch s1");
            pb.SetPrice(30000);
            Product Watch1 = pb.GetResult();
            pb.Reset();

            pb.SetName("Bracelet v1");
            pb.SetPrice(40000);
            Product Bracelet1 = pb.GetResult();
            pb.Reset();

            pb.SetName("Watch s2");
            pb.SetPrice(50000);
            Product Watch2 = pb.GetResult();
            pb.Reset();

            sb.SetProduct(Watch1);
            sb.SetProduct(Bracelet1);
            sb.SetProduct(Watch2, 8, 200);
            Shop Cartier = sb.GetResult();
            sb.Reset();


            Cartier.PrintAllProducts();



            sb.SetName("Tissot");
            sb.SetAddress("Nevsky ave., 49");

            pb.SetName("Watch s1");
            pb.SetPrice(25000);
            Product Watch3 = pb.GetResult();
            pb.Reset();


            pb.SetName("Bracelet v1");
            pb.SetPrice(45000);
            Product Bracelet2 = pb.GetResult();
            pb.Reset();

            sb.SetProduct(Watch3);
            sb.SetProduct(Bracelet2);
            Shop Tissot = sb.GetResult();
            sb.Reset();

            Tissot.PrintAllProducts();

            sb.SetName("Hublot");
            sb.SetAddress("Ligovsky ave., 1");

            pb.SetName("Bracelet v1");
            pb.SetPrice(55000);
            Product Bracelet3 = pb.GetResult();
            pb.Reset();

            pb.SetName("Watch s1");
            pb.SetPrice(60000);
            Product Watch4 = pb.GetResult();
            pb.Reset();

            sb.SetProduct(Bracelet3);
            sb.SetProduct(Watch4);
            Shop Hublot = sb.GetResult();
            sb.Reset();

            Hublot.PrintAllProducts();


            ShopAnalyzer sa = new ShopAnalyzer();

            sa.AddShop(Cartier);
            sa.AddShop(Tissot);
            sa.AddShop(Hublot);
            sa.PrintShopWithMinProdPrice("Watch s1"); // task 4
            sa.PrintShopWithMinProdPrice("Bracelet v1");

            sa.WhatCanBuy(Tissot, 50000); // task 5

            sa.BuyManyProducts(Cartier, "Watch s2", 5); // task 6
            sa.BuyManyProducts(Cartier, "Watch s2", 9);

            sa.WhichShopHasCheaperProducts("Watch s2", 5); // task 7



        }
    }
}
