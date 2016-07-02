namespace CustomLinksDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Xml.Linq;

    public class Link
    {
        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Url { get; set; }

        public Int32? ParentId { get; set; }

        public static IEnumerable<Link> Load(String xmlPath)
        {
            var fullPath = System.Web.HttpContext.Current.Server.MapPath(xmlPath);

            var links = new List<Link>();

            var doc = XDocument.Load(fullPath);
            foreach(var node in doc.Descendants("row"))
            {
                Int32 id = 0;
                Int32.TryParse(node.Attribute("id").Value, out id);

                Int32 parent = 0;
                Int32.TryParse(node.Attribute("parent").Value, out parent);

                links.Add(new Link
                {
                    Id = (id == 0 ? -1 : id),
                    Title = node.Attribute("title").Value,
                    Url = node.Attribute("url").Value,
                    ParentId = parent
                });
            }

            return links;
        }
    }
}