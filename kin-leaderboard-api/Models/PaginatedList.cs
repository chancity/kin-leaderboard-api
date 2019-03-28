﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace kin_leaderboard_api.Models
{
    public class PaginatedList<T> : List<T>
    {
        [JsonProperty]
        public int PageIndex { get; set; }

        [JsonProperty]
        public int TotalPages { get; set; }

        [JsonProperty]
        public int TotalCount { get; set; }

        [JsonProperty]
        public bool HasPreviousPage => PageIndex > 1;

        [JsonProperty]
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            TotalCount = count;

            AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync<TEntity>(IQueryable<TEntity> source, IMapper mapper,
            int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            List<TEntity> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            List<T> mappedItems = mapper.Map<List<TEntity>, List<T>>(items);
            return new PaginatedList<T>(mappedItems, count, pageIndex, pageSize);
        }
    }
}