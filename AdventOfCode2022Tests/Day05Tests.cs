using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day05Tests
{
    private Day05 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".Split(Environment.NewLine);
        var testStacks = new[] { "ZN", "MCD", "P" };
        _sut = A.Fake<Day05>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
        A.CallTo(() => _sut.Stacks).Returns(testStacks);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be("CMZ");
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be("MCD");
    }
}