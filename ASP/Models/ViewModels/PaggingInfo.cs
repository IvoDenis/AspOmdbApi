using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public readonly int ItemsInPage = 10;

        public PagingInfo(int totalItems, int currentPage)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
        }

        public int TotalPages =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsInPage);
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
    }
}
