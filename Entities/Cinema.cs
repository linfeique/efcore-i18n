namespace I18N.Entities;

public class Cinema
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<Movie> Movies { get; set; }
}
