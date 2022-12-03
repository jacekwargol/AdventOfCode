namespace AdventOfCode;
internal static class Day2 {
    private static readonly Dictionary<char, int> ShapeValue =
        new() {
            { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 }
        };
    private static readonly Dictionary<char, int> ShapeValue2 =
    new() {
            { 'A', 1 }, { 'B', 2 }, { 'C', 3 }
    };
    private static readonly Dictionary<char, char> ShapeTranslate =
        new() {
            { 'A', 'X' }, { 'B', 'Y' }, { 'C', 'Z' }
        };
    private static readonly Dictionary<string, int> RoundScore =
        new() {
            { "XY", 6 }, { "XZ", 0 }, { "YZ", 6 }, { "YX", 0 },
            { "ZX", 6 }, { "ZY", 0 }
        };

    public static int CalculateScore(string gameFile) {
        int score = 0;
        foreach (var line in File.ReadLines(gameFile)) {
            var round = line.Split(' ')
                .Select(s => char.Parse(s)).Take(2).ToArray();
            round[0] = ShapeTranslate[round[0]];
            var roundString = new string(round);
            score += ShapeValue[round[1]];
            score += round[0] == round[1] ? 3 : RoundScore[roundString];
        }

        return score;
    }

    public static int CalculateScore2(string gameFile) {
        int score = 0;
        foreach (var line in File.ReadLines(gameFile)) {
            var round = line.Split(' ')
                .Select(s => char.Parse(s)).Take(2).ToArray();
            switch (round[1]) {
                case 'X':
                    switch (round[0]) {
                        case 'A':
                            score += ShapeValue2['C'];
                            break;
                        case 'B':
                            score += ShapeValue2['A'];
                            break;
                        case 'C':
                            score += ShapeValue2['B'];
                            break;
                        default:
                            break;
                    }
                    break;
                case 'Y':
                    score += ShapeValue2[round[0]] + 3;
                    break;
                case 'Z':
                    switch (round[0]) {
                        case 'A':
                            score += ShapeValue2['B'];
                            break;
                        case 'B':
                            score += ShapeValue2['C'];
                            break;
                            case 'C':
                                score += ShapeValue2['A'];
                            break;
                        default:
                            break;
                    }
                    score += 6;
                    break;
                default:
                    break;
            }
        }

        return score;
    }
}
