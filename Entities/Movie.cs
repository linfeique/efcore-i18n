using I18N.Infra;

namespace I18N.Entities;

public class Movie : ITranslated<MovieTranslated>
{
    public Guid Id { get; set; }

    public string OriginalTitle { get; set; }

    public string OriginalDescription { get; set; }

    public string OriginalSubtitle { get; set; }

    public Guid CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; }

    public IEnumerable<MovieTranslated> Translations { get; set; }
}

public class MovieTranslated : ITranslation
{
    public string Language { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Subtitle { get; set; }
}