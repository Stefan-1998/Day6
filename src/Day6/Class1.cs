using System.Text.RegularExpressions;

namespace Day6;

static public class BoatDriveDistanceCalculator
{
    static public int Part1(string raceRecordsPath)
    {
        if (!Path.Exists(raceRecordsPath)) { throw new FileNotFoundException($"The path {raceRecordsPath} can not be found!"); }
        var raceRecords = ReadOutRaceRecords(raceRecordsPath);
        return CalculateAmountOfFasterTimes(raceRecords);
    }
    static public int Part2(string raceRecordsPath)
    {
        if (!Path.Exists(raceRecordsPath)) { throw new FileNotFoundException($"The path {raceRecordsPath} can not be found!"); }
        var raceRecords = ReadOutRaceRecords(raceRecordsPath, true);
        return CalculateAmountOfFasterTimes(raceRecords);
    }
    static private IEnumerable<(long Time, long Duration)> ReadOutRaceRecords(string raceRecordsPath, bool combineEntries = false)
    {
        var raceRecords = File.ReadLines(Path.GetFullPath(raceRecordsPath)).ToList();
        if (combineEntries)
        {
            raceRecords[0] = raceRecords[0].Replace(" ", "");
            raceRecords[1] = raceRecords[1].Replace(" ", "");
        }
        var times = new Regex(@"\d+").Matches(raceRecords[0]).Select(time => Int64.Parse(time.Value));
        var duration = new Regex(@"\d+").Matches(raceRecords[1]).Select(time => Int64.Parse(time.Value));
        return times.Zip(duration, (times, duration) => (times, duration));
    }
    static private int CalculateAmountOfFasterTimes(IEnumerable<(long Time, long Duration)> records)
    {
        int amountOfWinningTimes = 1;
        foreach (var record in records)
        {
            var firstTime = CalculateFirstRunTimeOfRecordHolder(record.Time, record.Duration);
            var secondTime = CalculateSecondRunTimeOfRecordHolder(record.Time, record.Duration);

            // -1 is needed, because only the times in between are needed
            amountOfWinningTimes *= Math.Abs((int)firstTime - (int)secondTime) - 1;
        }

        return amountOfWinningTimes;
    }
    static private double CalculateFirstRunTimeOfRecordHolder(long recordtime, long distance) => Math.Floor((recordtime - Math.Sqrt(Math.Pow(recordtime, 2) - 4 * distance)) / 2);
    static private double CalculateSecondRunTimeOfRecordHolder(long recordtime, long distance) => Math.Ceiling((recordtime + Math.Sqrt(Math.Pow(recordtime, 2) - 4 * distance)) / 2);
}
