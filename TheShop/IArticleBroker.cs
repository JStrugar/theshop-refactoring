using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public interface IArticleBroker
    {
        Article GetArticle(int articleId, int maxExpectedPrice);
    }
}
