using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{
    public class ReviewBook
    {
        private readonly Review[] _reviews;

        public readonly IEnumerable<Category> Categories;
        
        public int Count => _reviews.Length;

        public ReviewBook(CsvFileAdapter adapter, ReviewsFormatter formatter)
        {
            Categories = formatter.Format(adapter.Read());
            _reviews = Categories.SelectMany(c => c.Reviews).ToArray();
        }

        public string this[int index] => _reviews[index].Description;
    }
}
