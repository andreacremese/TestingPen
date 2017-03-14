using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Cracking {
    public static class Chapter1 {
        public static Boolean AllUniqueCharacters(string s) {
            var CharactersMap = new Dictionary<Char, Boolean>();
            for (var i = 0; i < s.Length; i++) {
                var character = (Char)s[i];
                if (CharactersMap.ContainsKey(character)){
                    return false;
                }
                CharactersMap[character] = true;
            }
            return true;
        }


        public static Boolean AllUniqueCharacters1(string s) {
            Int64 charCounter = 0;
            for (var i = 0; i < s.Length; i++) {
                int current = (int)s[i] - 'a';
                if((charCounter & (1 << current)) > 0) return false;
                charCounter |= 1 << current;
            }
            return true;
        }

        public static String RemoveDuplicastes(String s) {
            Int32 charactersCount = 0;
            Int32 i = 0;
            while (i < s.Length) {
                if ((charactersCount & 1 << (int)s[i] -'a') > 0) {
                    // character i is repeated
                    if (i == s.Length) {
                        // this is the last character of the string
                        s = s.Substring(0, i);
                        break;
                    } else {
                        s = s.Substring(0, i) + s.Substring(i + 1, s.Length - 1 - i);
                    }
                    // the index should not be updated as the character that has just been shifted needs to be checked
                    continue;
                } else {
                    charactersCount |= 1 << (int)s[i] -'a';
                    i++;
                }
            }
            return s;
        }

        public static String ReplaceSpaces(String s) {
            var result = new StringBuilder();
            for (var i = 0; i < s.Length; i++) {
                if (s[i] == ' ') {
                    result.Append("%20");
                } else {
                    result.Append(s[i]);
                }
            }
            return result.ToString();
        }

        public static Int32[,] RotateNinetyClockwise(Int32[,] image) {
            var width = image.GetLength(0);
            var height = image.GetLength(1);
            var result = new Int32[height, width];
            for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
                    result[j, height - 1 - i] = image[i, j];
                }
            }
            return result;
        }
    }
}