using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day08Tests
{
    private Day08 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"30373
25512
65332
33549
35390".Split(Environment.NewLine);
        _sut = A.Fake<Day08>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(21);
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(8);
    }
}