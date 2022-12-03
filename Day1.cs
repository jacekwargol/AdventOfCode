namespace AdventOfCode;

internal static class Day1 {
    public static int Solve() {
        var values = new List<int>();
        var current = 0;
        foreach (var line in System.IO.File.ReadLines("input_011.txt")) {
            if (int.TryParse(line, out int lineVal)) {
                current += lineVal;
            }
            else {
                values.Add(current);
                current = 0;
            }
        }
        values.Sort();
        values.Reverse();
        return values[0] + values[1] + values[2];
    }
}
