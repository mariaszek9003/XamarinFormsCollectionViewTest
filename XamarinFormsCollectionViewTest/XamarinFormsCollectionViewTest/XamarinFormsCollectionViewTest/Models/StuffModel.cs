using System;
using Prism.Mvvm;

namespace XamarinFormsCollectionViewTest.Models
{
    public class StuffModel : BindableBase
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Uri ImageUri { get => new Uri(ImageUrl); }
        public bool HasImage { get => !string.IsNullOrEmpty(ImageUrl); }
    }
}
