using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSGenBDev.Common;
using RSSGenBDev.Model;
using RSSGenBDev.Util;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace RSSGenBDev.ViewModel
{
    public class RssMainViewModel : BindableBase
    {
        private ArticleList _articles;

        public ArticleList Articles
        {
            get { return _articles; }
            set { SetProperty(ref _articles, value); }
        }

        private string _feedUrlString;

        public string FeedUrlString
        {
            get { return _feedUrlString; }
            set { SetProperty(ref _feedUrlString, value); }
        }

        public async Task Initialize()
        {
            Articles = await RSSHelper.GetArticleListFromFeedAsync(this.FeedUrlString);
        }

        public async void ViewLoadHandler(object o, RoutedEventArgs e)
        {
            var tmpView = o as FrameworkElement;
            if (tmpView!=null)
            {
                tmpView.DataContext = this;
            }
            
            if (!string.IsNullOrWhiteSpace(FeedUrlString))
                await Initialize();
        }



        public static string GetHtmlString(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlStringProperty);
        }

        public static void SetHtmlString(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlStringProperty, value);
        }

        // Using a DependencyProperty as the backing store for HtmlString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HtmlStringProperty =
            DependencyProperty.RegisterAttached("HtmlString",
                                    typeof(string), typeof(RssMainViewModel),
                                    new PropertyMetadata("", HtmlStringChanged));

        public static void HtmlStringChanged(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
        {
            var wb = sender as WebView;
            if (wb != null)
                wb.NavigateToString((string)arg.NewValue);
        }
    }
}
