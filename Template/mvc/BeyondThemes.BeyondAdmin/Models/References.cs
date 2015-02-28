using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace BeyondThemes.BeyondAdmin.Models
{

    public class References
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public List<SyndicationItem> GetReferences()
        {
            List<SyndicationItem> lastNews = new List<SyndicationItem>();
            lastNews.AddRange(this.GetItemsFromUrl("https://sandbox.jiveon.com/groups/heisenberg/view-browse-feed.jspa?browseSite=place-content&browseViewID=placeContent&userID=4492&containerType=700&containerID=2777&filterID=contentstatus%5Bpublished%5D~objecttype~objecttype%5Bdocument%5D"));
            lastNews.Sort(delegate(SyndicationItem x, SyndicationItem y) { return y.PublishDate.CompareTo(x.PublishDate); });

            return lastNews;
        }

        private List<SyndicationItem> GetItemsFromUrl(string sURL)
        {
            XmlUrlResolver resolver = new XmlUrlResolver();
            List<SyndicationItem> lista = new List<SyndicationItem>();
            resolver.Credentials = new NetworkCredential("TeamHeisenberg", "zebra13", "");
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = resolver;

            XmlReader reader = XmlReader.Create(sURL, settings);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                item.Copyright = (feed.Copyright == null) ? new TextSyndicationContent(feed.Generator) : new TextSyndicationContent(feed.Copyright.Text);
                item.Id = (item.Id == null) ? item.Links[0].Uri.ToString() : item.Id;
                lista.Add(item);
            }

            return lista;
        }
    }
}