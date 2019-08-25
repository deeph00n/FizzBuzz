namespace Corporate.Services.FizzBuzz.Interfaces
{
    using Models;

    public interface IModService
    {
        Mods GetMods(int value);
    }
}