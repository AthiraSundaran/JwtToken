using System;
using JwtTocken1.Model;

namespace JwtTocken1.Services
{
	public class ProductService:IproductService
	{
		public List<Products> MyProducts = new List<Products>()//creating a product list
		{
			new Products{ProductId=1,ProductName="Smart Home Speaker",ProductDescription="A versatile smart home speaker equipped with voice recognition technology. It can play music, control smart home devices, answer questions, set reminders, and provide weather updates. "},
			new Products{ProductId=2,ProductName="Wireless Noise-Canceling Headphones",ProductDescription="Premium over-ear headphones featuring advanced noise-canceling technology to block out external sounds."},
			new Products{ProductId=3,ProductName="Fitness Tracker",ProductDescription="A sleek and lightweight fitness tracker that monitors your daily activity, heart rate, sleep patterns, and more. "}
		};
        public IEnumerable<Products> ViewProducts()//implementing the method that defined in the interface class 
		{
			return MyProducts;
		}			
        public IEnumerable<Products> AddProducts(Products products)//implementing the method that defined in the interface class 
        {
			MyProducts.Add(new Products { ProductId = MyProducts.Count+1, ProductName = products.ProductName, ProductDescription = products.ProductDescription });
			return MyProducts;
		}
    }
}

