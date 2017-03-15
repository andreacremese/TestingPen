using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Cracking {
    public static class BackTracking {
        public static List<String> PrintAllPermitations(String s) {
            var characters = new List<char>();
            for (var i = 0; i < s.Length; i++) {
                characters.Add(s[i]);
            }
            return BackTrack(String.Empty, characters);
        }



        public static List<String> BackTrack(String currentSolution, List<char> characters) {
            if (characters == null || characters.Count == 0) {
                return new List<String> { currentSolution };
            }

            var result = new List<String>();
            for (var i = 0; i < characters.Count; i++) {
                var newString = currentSolution + characters[i];
                var newCharacters = characters.GetRange(0, i);
                newCharacters.AddRange(characters.GetRange(i + 1, characters.Count - 1 - i));
                result.AddRange(BackTrack(newString, newCharacters));
            }
            return result;
        }


    }
}
