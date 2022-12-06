using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day01Tests
{
    private Day01 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Split(Environment.NewLine);
        _sut = A.Fake<Day01>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(24000);
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(45000);
    }
}