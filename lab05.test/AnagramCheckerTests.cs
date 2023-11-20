using lab05.anagram_app;

namespace lab05.test;

public class AnagramCheckerTests
{
    [Test]
    public void SimpleTest()
    {
        var anagramChecker = new AnagramChecker();
        Assert.IsTrue(anagramChecker.IsAnagram("listen", "silent"));
        Assert.IsTrue(anagramChecker.IsAnagram("LISTEN", "silent"));
        Assert.IsTrue(anagramChecker.IsAnagram("listen", "SILENT"));
        Assert.IsTrue(anagramChecker.IsAnagram("aaaaaa", "aaaaaa"));
    }

    [Test]
    public void NonAlphanumericTest()
    {
        var anagramChecker = new AnagramChecker();
        Assert.IsTrue(anagramChecker.IsAnagram("a!b@c#d$e%f^g&h*i(j)k", "k(j)i(h)g&f^e%d$c#b@a!"));
        Assert.IsTrue(anagramChecker.IsAnagram("a!b@c#d$e%f^g&h*i(j)k", "a!b@c#d$e%f^g&h*i(j)k"));
    }

    [Test]
    public void NonAnagramTest()
    {
        var anagramChecker = new AnagramChecker();
        Assert.IsFalse(anagramChecker.IsAnagram("listen", "silents"));
        Assert.IsFalse(anagramChecker.IsAnagram("listen", "sits"));
        Assert.IsFalse(anagramChecker.IsAnagram("listen", "SILENTS"));
        Assert.IsFalse(anagramChecker.IsAnagram("aaaaaa", "aaaaa"));
    }

    [Test]
    public void NullTest()
    {
        var anagramChecker = new AnagramChecker();
        Assert.Throws<NullReferenceException>(() => anagramChecker.IsAnagram(null, "silent"));
        Assert.Throws<NullReferenceException>(() => anagramChecker.IsAnagram("listen", null));
        Assert.Throws<NullReferenceException>(() => anagramChecker.IsAnagram(null, null));
    }
}