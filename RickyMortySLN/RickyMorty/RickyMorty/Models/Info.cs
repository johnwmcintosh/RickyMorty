using System;

namespace RickyMorty.Models
{
    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public Uri NextPage { get; set; }
        public Uri PrevPage { get; set; }
    }
}
