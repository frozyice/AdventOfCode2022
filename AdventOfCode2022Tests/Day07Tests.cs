using AdventOfCode2022;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class Day07Tests
{
    private Day07 _sut = null!;

    [SetUp]
    public void Setup()
    {
        var testData = @"$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k".Split(Environment.NewLine);
        _sut = A.Fake<Day07>(o => o.CallsBaseMethods());
        A.CallTo(() => _sut.Input).Returns(testData);
    }
    
    [Test]
    public void TestPartOne()
    {
        // act
        var result = _sut.PartOne();

        // assert
        result.Should().Be(95437);
    }

    [Test]
    public void TestPartTwo()
    {
        // act
        var result = _sut.PartTwo();

        // assert
        result.Should().Be(24933642);
    }
}