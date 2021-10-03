using System;
using System.Collections.Generic;
using System.Text;

namespace Gymate.Api.ViewModels.General
{
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; }
        public int CurentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        public bool IsFirstPage => CurentPage == 1;
        public bool IsLastPage => NoOfPages == CurentPage;
        public int NoOfPages => (int)Math.Ceiling((double)Count / PageSize);
    }
}
