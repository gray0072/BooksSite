using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Books.Models
{
	public class Book
	{
		[XmlAttribute("id")]
		public string Id { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("author")]
		public string Author { get; set; }

		[XmlElement("genre")]
		public string Genre { get; set; }

		[XmlElement("price")]
		public double Price { get; set; }

		[XmlElement("publish_date")]
		public DateTime PublishDate { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }
	}

	[XmlRoot("catalog")]
	public class Catalog
	{
		[XmlElement("book")]
		public List<Book> Books;
	}
}