using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kin_leaderboard_frontend.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace kin_leaderboard_api.Helper
{
    public static class PaginatedHelper
    {
        public static async Task<PaginatedList<TModel>> CreateAsync<TEntity, TModel>(this IQueryable<TEntity> source, IMapper mapper,
            int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            List<TEntity> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            List<TModel> mappedItems = mapper.Map<List<TEntity>, List<TModel>>(items);
            return new PaginatedList<TModel>(mappedItems, count, pageIndex, pageSize);
        }
    }
}
