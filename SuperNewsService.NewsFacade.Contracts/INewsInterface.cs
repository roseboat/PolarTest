
using SuperNewsService.NewsFacade.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Polar.SuperNewsService.NewsFacade.Contracts
{     
    public interface INewsInterface
    {
        Task<List<Newsitem>> GetPolarNews(string query, string preferences);
    }
}
