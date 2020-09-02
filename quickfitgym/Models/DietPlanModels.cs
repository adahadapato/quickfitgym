using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace quickfitgym.Models
{
    public class Diet
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Hour { get; set; }
        public List<Features> Features { get; set; }
    }

    public class Features
    {
        public string Name { get; set; }
        public Color BGColor { get; set; }
        public Color TxColor { get; set; }
    }
}
