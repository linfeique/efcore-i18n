namespace I18N.Infra;

public interface ITranslated<T> where T : ITranslation
{
    public IEnumerable<T> Translations { get; set; }
}
