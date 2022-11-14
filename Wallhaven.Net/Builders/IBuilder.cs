namespace Wallhaven.Net.Builders;

public interface IBuilder<out T>
{
    bool Validate();

    bool Validate(out IEnumerable<Exception> errors);

    T Build();
}
