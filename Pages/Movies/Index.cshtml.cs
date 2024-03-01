using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie2.Data;
using RazorPageMovie2.Models;

namespace RazorPageMovie2.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie2.Data.RazorPageMovie2Context _context;

        public IndexModel(RazorPageMovie2.Data.RazorPageMovie2Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet =true)]
        public string? SearchString {  get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {

            //Movie = await  _context.Movie.ToListAsync();
            IQueryable<string> genreQuery =  from m in _context.Movie
                                             orderby m.Genre
                                             select m.Genre;    //como es un iqueryable es porque es un listado , tiene mas de un dato, entonces combinamos el genero y el nombre de la peli 

            var movies = from m in _context.Movie
                         select m;
            if(!string.IsNullOrEmpty(SearchString))//si search string no es nulo nos va a traer esta consulta de movies 
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));//el titulo esta en la variable search string
            }

            if(!string.IsNullOrEmpty(MovieGenre)) 
            {
            movies.Where( x=> x.Genre == MovieGenre);
            }

            if(_context.Movie != null)
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie=await movies.ToListAsync();
            }
        }


    }
}
