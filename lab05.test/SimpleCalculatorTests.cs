using lab05.calculator_app;

namespace lab05.test;

public class SimpleCalculatorTests
{
    [Test]
    public void Test()
    {
        SimpleCalculator calculator = new SimpleCalculator();
        Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
        Assert.That(calculator.Divide(4, 2), Is.EqualTo(2));
        Assert.That(calculator.Multiply(2, 3), Is.EqualTo(6));
        Assert.That(calculator.Subtract(5, 2), Is.EqualTo(3));
        Assert.Catch<DivideByZeroException>(() => calculator.Divide(1, 0));
    }
}