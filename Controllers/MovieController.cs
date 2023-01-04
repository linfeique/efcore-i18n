using I18N.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace I18N.Controllers;

[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly Db db;

	public MovieController(Db db)
	{
		this.db = db;
	}

	[HttpGet]
	public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
	{
		var movies = await db.Movies
			.Where(d => d.Translations.Select(d => d.Language).Contains("pt-br"))
			.ToListAsync(cancellationToken);

		return Ok(movies);
	}

	[HttpPost]
	public IActionResult CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
	{
		var movie = db.Movies.Add(new Entities.Movie
		{
			CinemaId = Guid.Parse("da144bc4-fbf0-4fd8-ced3-08dae901acfb"),
			OriginalDescription = request.OriginalInfo.Description,
			OriginalSubtitle = request.OriginalInfo.Subtitle,
			OriginalTitle = request.OriginalInfo.Title,
			Translations = request.Tranlations.Select(d => new Entities.MovieTranslated
			{
				Title = d.Title,
				Subtitle = d.Subtitle,
				Description = d.Description,
				Language = d.Language,
			}).ToList()
		});

		db.SaveChanges();

		return Ok();
	}
}

public class CreateMovieRequest
{
	public class Info
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public string Subtitle { get; set; }
    }

	public class InfoWithLanguage : Info
	{
        public string Language { get; set; }
    }

	public Info OriginalInfo { get; set; }

	public IEnumerable<InfoWithLanguage> Tranlations { get; set; }
}
