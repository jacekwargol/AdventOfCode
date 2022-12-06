using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;
internal static class Day6 {
    public static int GetMarker(string filePath) {
        var input = File.ReadAllText(filePath);
         var uniques = new List<char>();

        for(int i = 0; i < input.Length; i++) {
            if(uniques.Count >= 14) {
                return i;
            }
            if (uniques.Contains(input[i])) {
                var duplicateIndex = uniques.IndexOf(input[i]);
                uniques.RemoveRange(0, duplicateIndex + 1);
            }
            uniques.Add(input[i]);
        }

        return 0;
    }
}
