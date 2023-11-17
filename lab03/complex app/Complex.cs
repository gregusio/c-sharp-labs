namespace lab03.complex_app;

public class Complex<T> where T : IComparable, IFormattable
{
    private readonly T _real;
    private readonly T _abstract;

    public Complex(T real, T @abstract)
    {
        _real = real;
        _abstract = @abstract;
    }

    public T GetRealPart()
    {
        return _real;
    }

    public T GetAbstractPart()
    {
        return _abstract;
    }
}