using System;

namespace TheShop
{
    public interface ISupplier
    {
        Article GetArticle(int itemId);
    }
}