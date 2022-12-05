using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode;
internal static class Day5 {
    private static List<StringBuilder> GetStacks(string filePath) {
        var stacks = new List<StringBuilder>();
        foreach (var line in File.ReadLines(filePath)) {
            //Stacks description over, stacks numbers found 
            if (Regex.IsMatch(line, @" [0-9]")) {
                break;
            }

            var sLine = Regex.Replace(line, @"(\[)|(\]\s?)", "");
            var strippedLine = Regex.Replace(sLine, @"\s+", " ");
            for (int i = 0; i < strippedLine.Length; i++) {
                if (i > stacks.Count - 1) {
                    stacks.Add(new StringBuilder());
                }
                stacks[i].Append(strippedLine[i]);
            }
        }
        foreach (var item in stacks) {
            item.Replace(" ", "");
        }
        return stacks;
    }

    private static List<StringBuilder> MoveStacks(List<StringBuilder> stacks, string filePath) {
        foreach (var line in File.ReadLines(filePath)) {

            if (Regex.IsMatch(line, @"^((\s+)|(\[))")
                || line.Length == 0) {
                continue;
            }
            int amount, from, to;
            if (char.IsDigit(line[5]) && char.IsDigit(line[6])) {
                amount = int.Parse(line[5].ToString() + line[6].ToString());
                from = int.Parse(line[13].ToString()) - 1;
                to = int.Parse(line[18].ToString()) - 1;
            }
            else {
                amount = int.Parse(line[5].ToString());
                from = int.Parse(line[12].ToString()) - 1;
                to = int.Parse(line[17].ToString()) - 1;
            }

            for (int i = 0; i < amount; i++) {
                if (stacks[from].Length == 0) {
                    continue;
                }
                stacks[to].Insert(0, stacks[from][0]);
                stacks[from].Remove(0, 1);
            }
        }

        return stacks;
    }

    private static List<StringBuilder> MoveStacksMultiple(List<StringBuilder> stacks, string filePath) {
        foreach (var line in File.ReadLines(filePath)) {

            if (Regex.IsMatch(line, @"^((\s+)|(\[))")
                || line.Length == 0) {
                continue;
            }
            int amount, from, to;
            if (char.IsDigit(line[5]) && char.IsDigit(line[6])) {
                amount = int.Parse(line[5].ToString() + line[6].ToString());
                from = int.Parse(line[13].ToString()) - 1;
                to = int.Parse(line[18].ToString()) - 1;
            }
            else {
                amount = int.Parse(line[5].ToString());
                from = int.Parse(line[12].ToString()) - 1;
                to = int.Parse(line[17].ToString()) - 1;
            }

            for (int i = 0; i < stacks.Count; i++) {
                Console.WriteLine($"Stack {i}: {stacks[i]}");
            }
            Console.WriteLine($"move {amount} from {from} to {to}");
            Console.WriteLine("--------------------------");
            //from = int.Parse(line[12].ToString()) - 1;
            //to = int.Parse(line[17].ToString()) - 1;
            for (int i = 0; i < amount; i++) {
                if (stacks[from].Length == 0) {
                    continue;
                }
                stacks[to].Insert(0, stacks[from][0]);
                stacks[from].Remove(0, 1);
            }
        }

        return stacks;
    }

    public static string GetStacksTop(string filePath) {
        var startingStacks = GetStacks(filePath);
        var stacks = MoveStacks(startingStacks, filePath);
        var tops = new StringBuilder();

        foreach (var stack in stacks) {
            if (stack.Length > 0) {
                tops.Append(stack[0]);
            }
            else {
                tops.Append(" ");
            }
        }
        return tops.ToString();
    }
}
