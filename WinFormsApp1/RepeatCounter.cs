using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class RepeatCounter
    {
        public static string readFile(string fileName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return File.ReadAllText("C:\\Users\\imold\\source\\repos\\Task2\\WinFormsApp1\\" + fileName + ".txt", Encoding.GetEncoding("windows-1251"));
        }

        public static Dictionary<char, int> getRepeatsByCode(string inputText)
        {
            int charCount;
            Dictionary<char, int> repeatsDict = new Dictionary<char, int> ();
            SortedSet<char> sortedSet = new SortedSet<char>();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (char.IsLower(inputText[i]))
                {
                    sortedSet.Add(inputText[i]);
                }
            }

            var chars = sortedSet.ToArray();
            Array.Sort(chars, StringComparer.Ordinal);

            foreach (char val in chars)
            {
                charCount = inputText.Where(c => c == val).Count();
                if (charCount > 0)
                {
                    repeatsDict.Add(val, charCount);
                }
            }
            return repeatsDict;
        }

        public static Dictionary<char, int> getRepeatsByOccurrence(string inputText)
        {
            int charCount;
            Dictionary<char, int> repeatsDict = new Dictionary<char, int>();
            SortedSet<char> sortedSet = new SortedSet<char>();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (char.IsLower(inputText[i]))
                {
                    sortedSet.Add(inputText[i]);
                }
            }

            var chars = sortedSet.ToArray();

            foreach (char val in chars)
            {
                charCount = inputText.Where(c => c == val).Count();
                if (charCount > 0)
                {
                    repeatsDict.Add(val, charCount);
                }
            }

            return sortDict(repeatsDict);
        }

        public static void writeFile(Dictionary<char, int> dict)
        {
            File.WriteAllLines("C:\\Users\\imold\\source\\repos\\Task2\\WinFormsApp1\\nameS.txt",
                dict.Select(x => x.Key + " - " + x.Value).ToArray());
        }

        public static string dictToString(Dictionary<char, int> dict)
        {
            return string.Join("", dict.Select(kv => kv.Key + " - " + kv.Value + "\n").ToArray());
        }

        public static string dictToString(SortedDictionary<char, int> dict)
        {
            return string.Join("", dict.Select(kv => kv.Key + " - " + kv.Value + "\n").ToArray());
        }

        private static Dictionary<char, int> sortDict(Dictionary<char, int> dict)
        {
            List<KeyValuePair<char, int>> tempList = dict.ToList();
            //List<KeyValuePair<char, int>> sortedList = new List<KeyValuePair<char, int>>();
            Dictionary<char, int> tempDict = new Dictionary<char, int>();
            Dictionary<char, int> sortedDict = new Dictionary<char, int>();

            tempList.Sort(
                delegate (KeyValuePair<char, int> pair1,
                KeyValuePair<char, int> pair2)
                {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            foreach (var pair in tempList)
            {
                tempDict.Add(pair.Key, pair.Value);
            }

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                if (tempList[i].Value == tempList[i + 1].Value)
                {
                    if ((int)tempList[i].Key < (int)tempList[i + 1].Key)
                    {
                        swap(tempList, i, i + 1);
                    }
                }
            }

            for (int i = tempDict.Count - 1; i >= 0; i--)
            {
                sortedDict.Add(tempList[i].Key, tempList[i].Value); 
            }

            return sortedDict;
        }

        private static void swap(List<KeyValuePair<char, int>> list, int indexA, int indexB)
        {
            KeyValuePair<char, int> tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

    }
}
