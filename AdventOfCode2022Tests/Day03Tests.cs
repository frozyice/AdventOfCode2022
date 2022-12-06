using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day03Tests
{
    private Day03 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);
        _sut = A.Fake<Day03>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(157);
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(70);
    }
}