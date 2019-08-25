namespace Corporate.Services.FizzBuzz.Interfaces
{
    using Enums;

    public interface ITranslationService
    {
        string Translate(TranslationKey key);
    }
}