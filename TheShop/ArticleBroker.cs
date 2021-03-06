﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class ArticleBroker :IArticleBroker
    {
        private readonly List<ISupplier> suppliers = new List<ISupplier>();

        public Article GetArticle(int articleId, int maxExpectedPrice)
        {
            if (suppliers.Count == 0)
            {
                return null;
            }

            var article = suppliers.FirstOrDefault(supplier => supplier.ArticleInInventory(articleId) &&
                                                                   maxExpectedPrice < supplier.GetArticle(articleId).ArticlePrice)
                ?.GetArticle(articleId);

            if (article == null)
            {
                article = suppliers.Last().GetArticle(articleId);
            }

            return article;
        }

        public void RegisterSupplier(ISupplier supplier)
        {
            suppliers.Add(supplier);
        }

        public void RemoveSupplier(ISupplier supplier)
        {
            suppliers.Remove(supplier);
        }
    }
}
