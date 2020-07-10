using Xamarin.Forms;
using XamarinFormsCollectionViewTest.Models;

namespace XamarinFormsCollectionViewTest.Templates
{
    public class StuffTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GoodStuffTemplate { get; set; }
        public DataTemplate BetterStuffTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is StuffModel model)
            {
                if (model.HasImage)
                {
                    return BetterStuffTemplate;
                }
                else
                {
                    return GoodStuffTemplate;
                }
            }

            return null;
        }
    }
}
