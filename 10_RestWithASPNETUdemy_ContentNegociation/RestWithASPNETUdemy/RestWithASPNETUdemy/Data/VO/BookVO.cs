using System;

namespace RestWithASPNETUdemy.Data.VO
{
    public class BookVO
    {
        public int Id { get; set; }
        public string Author { get; set;} 
        public DateTime LaunchDate { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }

    }
}
