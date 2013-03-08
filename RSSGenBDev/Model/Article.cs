using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSSGenBDev.Common;

namespace RSSGenBDev.Model
{
    public class Article:BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary,value); }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content,value); }
        }

        private Uri _imgUri;
        public Uri ImgUri
        {
            get { return _imgUri; }
            set { SetProperty(ref _imgUri, value); }
        }
    }
}
