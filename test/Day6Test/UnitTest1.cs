using Day6;

namespace Day6Test;

public class Tests
{
    [TestCase("../../../ExampleInput.txt", 288)]
    [TestCase("../../../Input.txt", 505494)]
    public void Test1(string inputPath, int result)
    {
        inputPath = Path.GetFullPath(inputPath);
        Assert.That(BoatDriveDistanceCalculator.Part1(inputPath), Is.EqualTo(result));
    }
    [TestCase("../../../ExampleInput.txt", 71503)]
    [TestCase("../../../Input.txt", 23632299)]
    public void Test2(string inputPath, int result)
    {
        inputPath = Path.GetFullPath(inputPath);
        Assert.That(BoatDriveDistanceCalculator.Part2(inputPath), Is.EqualTo(result));
    }
}
