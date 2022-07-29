using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{
    public class ReviewsFormatter : IDataFormatter<IEnumerable<(string, string)>, Review[]>
    {
        public Review[] Format(IEnumerable<(string, string)> input)
        {
            string additional = string.Empty;
            var result = new List<Review>();

            foreach (var item in input)
            {
                if (item.Item2 == string.Empty)
                {
                    additional = item.Item1;

                    if (result.Count == 0)
                        continue;

                    var previous = result[result.Count - 1];
                    result[result.Count - 1] = new Review(previous.Name + "\n", previous.Description);
                    continue;
                }

                string name = additional + " " + item.Item1;
                result.Add(new Review(name, item.Item2));
            }

            return result.ToArray();
        }

        public IEnumerable<(string, string)> Unformat(Review[] input)
        {
            throw new NotSupportedException();
        }
    }
}
