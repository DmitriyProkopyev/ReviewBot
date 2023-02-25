using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Category : IEnumerable<Review>
    {
        public readonly string Name;
        public readonly IEnumerable<Review> Reviews;

        public Category(string name, IEnumerable<Review> reviews)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException("Empty Name") : name;
            Reviews = reviews ?? throw new ArgumentException("No reviews available");
        }

        public IEnumerator<Review> GetEnumerator() => Reviews.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
