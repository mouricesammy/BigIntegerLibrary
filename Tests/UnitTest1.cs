using System;
using Xunit;
using Exercise01;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        IntegerToString integerToString = new IntegerToString();
        Assert.Throws<Exception>(() =>  integerToString.ConvertToWords("555000"));
    }
}
