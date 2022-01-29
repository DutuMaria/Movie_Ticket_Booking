using MovieTicketBooking.BLL.Interfaces;
using MovieTicketBooking.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieTicketBooking.DAL;
using MovieTicketBooking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            // ii dam contextul din startup
            _context = context;
        }

        // task -> creeaza un proces in care se va apela acest endpoint 
        // async -> pentru metoda aia se va crea un proces separat (se deschide un thread separat 
        // si se va rula acel proces pe acest thread)
        // await -> ne spune sa asteptam rularea acelui thread
        [HttpPost("AddMovie")]
        [Authorize("admin")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            // primim filmul din body
            // recomandat: punem check-uri pe componentele 
            // (campurile din tabel) pe care le primim
            // asa evitam SQL Injection

            // cineva trimite un script de sql din front-end intr-un 
            // camp nesecurizat din back-end si il ruleaza -> afecteaza bd

            if (string.IsNullOrEmpty(movie.Title))
            {
                return BadRequest("Tile is null!");
            }

            if (string.IsNullOrEmpty(movie.Description))
            {
                return BadRequest("Description is null!");
            }

            if (string.IsNullOrEmpty(movie.Duration.ToString()))
            {
                return BadRequest("Duration is null!");
            }

            if (string.IsNullOrEmpty(movie.Genre))
            {
                return BadRequest("Genre is null!");
            }

            // am adaugat filmul la DBSet care se numeste Movies
            await _context.Movies.AddAsync(movie);
            // spune contextului nostru ca poate sa salveze modificarile pe
            // care le-a facut si adauga obiectul in tabela
            await _context.SaveChangesAsync();

            // nu dorim sa aratam nimic la finalul endpointului
            // NoContent = successful, dar nu zice nimic
            return NoContent();

        }

        [HttpGet("GetMovieById/{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is 0!");
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(movie);

        }

        [HttpGet("GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpGet("GetMoviesByGenre/{genre}")]
        public async Task<IActionResult> GetMoviesByGenre([FromRoute] string genre)
        {
            var movies = await _context
                .Movies
                .Where(x => x.Genre.Contains(genre))
                .Select(x => new { Title = x.Title, Desciption = x.Description, Duration = x.Duration })
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("GetMovieScreenings/{title}")]
        public async Task<IActionResult> GetMovieScreenings([FromRoute] string title)
        {
            try
            {
                var movies = _context.Movies;
                var join = _context.Screenings.Join(movies, s => s.MovieId, m => m.Id, (s, m) => new
                {
                    m.Title,
                    s.StartDate,
                    m.Duration
                }).Where(x => x.Title == title).ToList();

                return Ok(join);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("GetAllMoviesScreenings")]
        public async Task<IActionResult> GetAllMoviesScreenings()
        {

            var screenings = await _context.Screenings.ToListAsync();
            return Ok(screenings);
        }

        [HttpPut("UpdateMovie/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            var _movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if(_movie != null)
            {
                _movie.Title = movie.Title;
                _movie.Description = movie.Description;
                _movie.Duration = movie.Duration;
                _movie.Genre = movie.Genre;
                _movie.Image = movie.Image;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("DeleteMovie/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("MovieId is 0!");
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
