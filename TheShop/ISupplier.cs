using System;

namespace TheShop
{
    public interface ISupplier
    {
        Article GetArticle(int itemId);
        bool ArticleInInventory(int id);
    }
}