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
		[TestMethod]
		public void LoadXml()
		{
			var service = new BookService(@"G:\BooksSite\Books\App_Data\books.xml");
			var result = service.GetAll();
		}

		[TestMethod]
		public void LoadXmlNotEmptyList()
		{
			var service = new BookService(@"G:\BooksSite\Books\App_Data\books.xml");
			var result = service.GetAll();
			if (result.Count == 0)
			{
				throw new Exception();
			}
		}
	}
}
