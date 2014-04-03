using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Books.Models;
using Books.Models.ViewModels;

namespace Books.Controllers
{
	public class HomeController : Controller
	{
		private IBookService _service;

        public HomeController(IBookService service)
        {
            this._service = service;
		}

		public ActionResult Index()
		{
			var books = _service.GetAll();
			var genres = books
				.Select(t => t.Genre)
				.Distinct()
				.OrderBy(t => t)
				.AsEnumerable();
			var model = new BookModel(books, genres);
			return View(model);
		}

		public ActionResult ByFilter(string genre, string titleFilter)
		{
			var books = _service.GetAll();
			var filteredByGenre =
				string.IsNullOrEmpty(genre)
					? books
					: books
					  	.Where(b => string.Compare(b.Genre, genre, true, CultureInfo.InvariantCulture) == 0);
			var filteredByTitle =
				string.IsNullOrEmpty(titleFilter)
					? filteredByGenre
					: filteredByGenre
					  	.Where(b => b.Title.IndexOf(titleFilter, StringComparison.InvariantCultureIgnoreCase) >= 0);
			return PartialView("Books", filteredByTitle);
		} 
	}
}
