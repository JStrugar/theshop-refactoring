﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class ArticleBroker :IArticleBroker
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

        public Article GetArticle(int articleId, int maxExpectedPrice)
        {
            var article = suppliers.FirstOrDefault(supplier => supplier.ArticleInInventory(articleId) &&
                                                                   maxExpectedPrice < supplier.GetArticle(articleId).ArticlePrice)
                ?.GetArticle(articleId);

            if (article == null)
            {
                article = suppliers.Last().GetArticle(articleId);
            }

            return article;
        }


    }
}
