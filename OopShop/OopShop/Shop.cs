using System;
using System.Collections.Generic;

namespace OopShop
{
    class ShopBuilder
    {
        private Shop shop = new Shop();

        public void SetName(string shopName)
        {
            shop.Name = shopName;
        }
        public void SetAddress(string shopAddress)
        {
            shop.Address = shopAddress;
        }

        public void SetProduct(Product product)
        {
            shop.products.Add(product);
        }

        public void SetProduct(Product product, int amount, float price)
        {
            for(int i = 0; i < amount; i++)
            {
                ProductBuilder pb = new ProductBuilder();
                pb.SetName(product.Name);
                pb.SetPrice(price);
                Product FinalProduct = pb.GetResult();
                shop.products.Add(FinalProduct);
                pb.Reset();
            }
        }

        public Shop GetResult()
        {
            return this.shop;
        }

        public void Reset()
        {
            shop = new Shop();
        }
    }

    class ProductBuilder
    {
        private Product prod = new Product();

        public void SetName(string prodName)
        {
            prod.Name = prodName;
        }

        public void SetPrice(float prodPrice)
        {
            prod.Price = prodPrice;
        }

        public Product GetResult()
        {
            return this.prod;
        }

        public void Reset()
        {
            prod = new Product();
        }
    }

    class Shop
    {
        public Shop()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Product> products = new List<Product>();

        public void PrintAllProducts()
        {
            Console.WriteLine($"=== ALL PRODUCTS IN {Name} ({Address}) ===");
            foreach (var product in products)
            {
                Console.WriteLine($"ProductID: {product.ID}, ProductName: {product.Name}, ProductPrice: {product.Price}");
            }
        }

        public bool ContainsProduct(Product product)
        {
            foreach (var prod in products)
            {
                if (prod.Name == product.Name)
                {
                    return true;
                }

            }
            return false;
        }
    }

    class Product
    {
        public Product()
        {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
