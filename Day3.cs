using System.Numerics;

namespace AdventOfCode;
internal static class Day3 {
    public static int CharToScore(char c) {
        if (char.IsLower(c)) {
            return (int)c - 96;
        }
        else {
            return (int)c - 38;
        }
    }

    public static int GetRucksackScore(string filePath) {
        int value = 0;
        var lines = File.ReadAllLines(filePath);
        var group = new List<string>();
        for(int i = 1; i <= lines.Length; i++) {
            group.Add(lines[i - 1]);
            if(i % 3 == 0) {
                var dups = group[0].Intersect(group[1]).Intersect(group[2]).ToList();
                value += CharToScore(dups[0]);
                group.Clear();
            }
        }

        return value;
    }
}
