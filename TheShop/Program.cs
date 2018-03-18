﻿using System;
using System.Reflection;
using Ninject;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
		    var kernel = new StandardKernel();
		    new Bindings(kernel).Load();
		    kernel.Load(Assembly.GetExecutingAssembly());
            var articleBroker = kernel.Get<IArticleBroker>();
            var shopService = new ShopService(articleBroker);

			try
			{
				//order and sell
				shopService.OrderAndSellArticle(1, 20, 10);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			try
			{
				//print article on console
				var article = shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			try
			{
				//print article on console				
				var article = shopService.GetById(12);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}

			Console.ReadKey();
		}
	}
}