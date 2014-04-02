using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models.ViewModels
{
	public class BookModel
	{
		public IEnumerable<Book> Books;

		public IEnumerable<string> Genres;

		public BookModel(IEnumerable<Book> books, IEnumerable<string> genres)
		{
			Books = books;
			Genres = genres;
		}
	}
}