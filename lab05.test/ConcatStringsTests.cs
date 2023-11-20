using lab05.concat_app;

namespace lab05.test;

public class ConcatStringsTests
{
    [Test]
    public void Test()
    {
        ConcatStrings concatStrings = new();
        Assert.That(concatStrings.Concat("Hello, ", "World!"), Is.EqualTo("Hello, World!"));
        Assert.That(concatStrings.Concat("Hello", ""), Is.EqualTo("Hello"));
        Assert.That(concatStrings.Concat("", "Hello"), Is.EqualTo("Hello"));
    }
    
    [Test]
    public void NullTest()
    {
        ConcatStrings concatStrings = new();
        Assert.IsNull(concatStrings.Concat(null, "Hello, World!"));
        Assert.IsNull(concatStrings.Concat("Hello, World!", null));
        Assert.IsNull(concatStrings.Concat(null, null));
    }
}