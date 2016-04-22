﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Os.Brain.Mvc.Pager
{
    public class PageList<T> : List<T>
    {
        public int PageSize { get; private set; }

        public int CurrPage { get; private set; }

        public int PageCount { get; private set; }

        public int RecordCount { get; private set; }

        public PageList(IQueryable<T> source, int currPage, int pageSize)
        {
            this.CurrPage = currPage;

            this.PageSize = pageSize;

            if (this.PageSize <= 0)
                this.PageSize = 10;

            if (this.CurrPage <= 0)
                this.CurrPage = 1;

            this.RecordCount = source.Count();

            int num = RecordCount / PageSize;

            this.PageCount = RecordCount % PageSize == 0 ? num : num + 1;

            this.AddRange(source.Skip((currPage - 1) * pageSize).Take(PageSize));
        }

    }
}
