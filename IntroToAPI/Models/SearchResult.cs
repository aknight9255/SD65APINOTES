using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI.Models
{
    public class SearchResult<T>
    {
        public int Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
