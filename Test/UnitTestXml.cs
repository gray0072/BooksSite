using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class UnitTestXml
	{
        private const string XmlPath = @"Xml\books.xml";

	    [TestMethod]
		public void LoadXml()
		{
		    this.GetBooks();
		}

        [TestMethod]
		public void LoadXmlNotEmptyList()
		{
            var books = this.GetBooks();
            if (books.Count == 0)
			{
				throw new Exception();
			}
		}

        [TestMethod]
        public void LoadXmlLoadedFullList()
        {
            var books = this.GetBooks();
            if (books.Count != 12)
            {
                throw new Exception();
            }
        }

        private List<Book> GetBooks()
        {
            var service = new BookService(XmlPath);
            return service.GetAll();
        }
	}
}
