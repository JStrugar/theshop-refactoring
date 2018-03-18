using System;

namespace TheShop
{
	public class ShopService
	{
		private DatabaseDriver DatabaseDriver;
		private Logger logger;
	    private IArticleBroker articleBroker;
		private ISupplier Supplier1;
		private ISupplier Supplier2;
		private ISupplier Supplier3;
		
		public ShopService()
		{
			DatabaseDriver = new DatabaseDriver();
			logger = new Logger();
			Supplier1 = new Supplier1();
			Supplier2 = new Supplier2();
			Supplier3 = new Supplier3();
            articleBroker = new ArticleBroker();
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
