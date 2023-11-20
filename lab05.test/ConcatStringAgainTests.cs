using lab05.concat_app;

namespace lab05.test;

public class ConcatStringAgainTests
{
    [Test]
    public void Test()
    {
        ConcatStringsAgain concatStringsAgain = new();
        Assert.That(concatStringsAgain.Concat("Hello, ", "World!"), Is.EqualTo("Hello, World!"));
        Assert.That(concatStringsAgain.Concat("Hello", ""), Is.EqualTo("Hello"));
        Assert.That(concatStringsAgain.Concat("", "Hello"), Is.EqualTo("Hello"));
    }
    
    [Test]
    public void NullTest()
    {
        ConcatStringsAgain concatStringsAgain = new();
        Assert.Throws<NullReferenceException>(() => concatStringsAgain.Concat(null, "Hello, World!"));
        Assert.Throws<NullReferenceException>(() => concatStringsAgain.Concat("Hello, World!", null));
        Assert.Throws<NullReferenceException>(() => concatStringsAgain.Concat(null, null));
    }
}