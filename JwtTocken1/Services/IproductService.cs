using System;
using JwtTocken1.Model;

namespace JwtTocken1.Services
{
	public interface IproductService
	{
		public IEnumerable<Products> ViewProducts();
		public IEnumerable<Products> AddProducts(Products products);

	}
}

