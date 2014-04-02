using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Books.Models
{
	public class BookService : IBookService
	{

		private string _xmlPath;

		public BookService(string xmlPath)
		{
			_xmlPath = xmlPath;
		}

		public List<Book> GetAll()
		{
			FileStream fs = null;
			try
			{
				fs = new FileStream(_xmlPath, FileMode.Open);
				var serializer = new XmlSerializer(typeof (Catalog));
				var catalog = (Catalog) serializer.Deserialize(fs);
				return catalog.Books;
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
				}
			}
		}

		public List<Book> GetByGenre(string genre)
		{
			throw new NotImplementedException();
		}

		public List<Book> GetByFilter(string titleFilter, string genre = null)
		{
			throw new NotImplementedException();
		}
	}
}