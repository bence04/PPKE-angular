using System.Collections.Generic;

namespace TanulmanyiRendszer.BLL.ViewModels
{
    public class ItemsViewModel<T>
        where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}