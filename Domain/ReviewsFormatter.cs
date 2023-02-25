using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{
    public class ReviewsFormatter : IDataFormatter<IEnumerable<(string, string)>, IEnumerable<Category>>
    {
        public IEnumerable<Category> Format(IEnumerable<(string, string)> input)
        {
            string name = input.First().Item1;
            var reviews = new Queue<Review>();
            
            foreach (var pair in input.Skip(1))
            {
                if (pair.Item2 == string.Empty)
                {
                    yield return new Category(name, Parse());
                    name = pair.Item1;
                    continue;
                }

                reviews.Enqueue(new Review(pair.Item1, pair.Item2));
            }

            Review[] Parse()
            {
                var result = new Review[reviews.Count];
                for (int i = 0; i < result.Length; i++)
                    result[i] = reviews.Dequeue();
                return result;
            }
        }

        public IEnumerable<(string, string)> Unformat(IEnumerable<Category> input)
        {
            throw new NotSupportedException();
        }
    }
}
