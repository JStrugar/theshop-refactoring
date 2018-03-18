using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class ArticleBroker
    {
        private IEnumerable<ISupplier> suppliers;

        public ArticleBroker()
        {
            suppliers = new List<ISupplier>
            {
                new Supplier1(),
                new Supplier2(),
                new Supplier3()
            };
        }

        public Article GetArticle(int articleId, int maxExpectedPrice, int buyerId)
        {
            Article tempArticle = null;
            Article article = null;
            var supplier1 = suppliers.Take(1).FirstOrDefault();
            var supplier2 = suppliers.Skip(1).Take(1).FirstOrDefault();
            var supplier3 = suppliers.Skip(2).Take(1).FirstOrDefault();
            var articleExists = supplier1.ArticleInInventory(articleId);
            if (articleExists)
            {
                tempArticle = supplier1.GetArticle(articleId);
                if (maxExpectedPrice < tempArticle.ArticlePrice)
                {
                    articleExists = supplier2.ArticleInInventory(articleId);
                    if (articleExists)
                    {
                        tempArticle = supplier2.GetArticle(articleId);
                        if (maxExpectedPrice < tempArticle.ArticlePrice)
                        {
                            articleExists = supplier3.ArticleInInventory(articleId);
                            if (articleExists)
                            {
                                tempArticle = supplier3.GetArticle(articleId);
                                if (maxExpectedPrice < tempArticle.ArticlePrice)
                                {
                                    article = tempArticle;
                                }
                            }
                        }
                    }
                }
            }

            article = tempArticle;

            return article;
        }


    }
}
