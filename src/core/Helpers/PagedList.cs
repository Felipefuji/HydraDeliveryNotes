﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        /// <summary>
        /// returns a paged type list PagedList<T>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        /// <summary>
        /// returns a non-paged type list PagedList<T>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<PagedList<T>> ToOnlyListAsync(IQueryable<T> source)
        {
            var count = source.Count();
            var items = await source.ToListAsync();
            var pageNumber = 1;
            var pageSize = 1;

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
