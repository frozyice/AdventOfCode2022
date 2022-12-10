using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day09Tests
{
    private Day09 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".Split(Environment.NewLine);
        _sut = A.Fake<Day09>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(13);
    }

    [Test]
    [TestCase("R 4\nU 4\nL 3\nD 1\nR 4\nD 1\nL 5\nR 2", 1)]
    [TestCase("R 5\nU 8\nL 8\nD 3\nR 17\nD 10\nL 25\nU 20", 36)]
    public void TestPartTwo(string testData, int expected)
    {
        A.CallTo(() => _sut.Input).Returns(testData.Split("\n"));

        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(expected);
    }
}