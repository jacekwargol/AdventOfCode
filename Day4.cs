namespace AdventOfCode;
internal static class Day4 {
    public static int GetFullyOverlapingPairs(string inputPath) {
        int overlapingPairs = 0;
        foreach (var line in File.ReadLines(inputPath)) {
            var pair = line.Split(',');
            var firstRange = pair[0].Split('-').Select(s => int.Parse(s)).ToArray();
            var secondRange = pair[1].Split('-').Select(s => int.Parse(s)).ToArray();
            if ((firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[1])
                || (secondRange[0] <= firstRange[0] && secondRange[1] >= firstRange[1])) {
                overlapingPairs++;
            }
        }

        return overlapingPairs;
    }

    public static int GetOverlapingPairs(string inputPath) {
        int overlapingPairs = 0;
        foreach (var line in File.ReadLines(inputPath)) {
            var pair = line.Split(',');
            var firstRange = pair[0].Split('-').Select(s => int.Parse(s)).ToArray();
            var secondRange = pair[1].Split('-').Select(s => int.Parse(s)).ToArray();

            if (firstRange[0] <= secondRange[1]
                && secondRange[0] <= firstRange[1]) {
                overlapingPairs++;
            }
        }

        return overlapingPairs;
    }
}
