using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Models
{
	interface IBookService
	{
		List<Book> GetAll();

		List<Book> GetByGenre(string genre);

		List<Book> GetByFilter(string titleFilter, string genre = null);
	}
}
