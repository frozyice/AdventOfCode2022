using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day06Tests
{
    private Day06 _sut = null!;

    [SetUp]
    public void Setup()
    {

        _sut = A.Fake<Day06>(o => o.CallsBaseMethods());
    }
    
    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void TestPartOne(string testData, int expected)
    {
        A.CallTo(() => _sut.Input).Returns(testData);

        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(expected);
    }

    [Test]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void TestPartTwo(string testData, int expected)
    {
        A.CallTo(() => _sut.Input).Returns(testData);

        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(expected);
    }
}