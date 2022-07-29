using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{
    public class ReviewBook
    {
        private readonly Review[] _reviews;

        public IEnumerable<string> Names => _reviews.Select(review => review.Name);

        public int Count => _reviews.Length;

        public ReviewBook(CsvFileAdapter adapter, ReviewsFormatter formatter) =>
            _reviews = formatter.Format(adapter.Read());

        public string this[int index] => _reviews[index].Description;
    }
}
