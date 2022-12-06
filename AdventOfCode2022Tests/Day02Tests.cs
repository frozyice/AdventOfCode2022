using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day02Tests
{
    private Day02 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"A Y
B X
C Z".Split(Environment.NewLine);
        _sut = A.Fake<Day02>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(15);
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(12);
    }
}