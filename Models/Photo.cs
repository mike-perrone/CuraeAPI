using System;

namespace FiralApiReal.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public DateTime PhotoAdded { get; set; }
        public bool IsMainPhoto { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}