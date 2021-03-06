﻿using System;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		private ILogger logger;
	    private IArticleBroker articleBroker;
		
		public ShopService(IArticleBroker articleBroker, ILogger logger)
		{
			DatabaseDriver = new DatabaseDriver();
		    this.logger = logger;
            this.articleBroker = articleBroker;
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			Article article = articleBroker.GetArticle(id, maxExpectedPrice);
			
			#endregion

			#region selling article

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			logger.Debug("Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;
			
			try
			{
				DatabaseDriver.Save(article);
				logger.Info("Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				logger.Error("Could not save article with id=" + id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}

			#endregion
		}

		public Article GetById(int id)
		{
			return DatabaseDriver.GetById(id);
		}
	}
}
