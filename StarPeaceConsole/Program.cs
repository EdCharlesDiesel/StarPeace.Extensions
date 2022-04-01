using StarPeace.Extentions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace StarPeaceConsole
{
    class Program
    {
        static char[] symbols = new char[] { ',', '!', '.', '?', ':', '-', '/', ';' };
        const char space = ' ';
        static bool foundChar = false;

        static void Main(string[] args)
        {
            //SumAndAveragesOfPositiveIntegers();
            //StackReverseDemo();
            //SortSeqOfIntegers();
            //LongestSubseqOfEqualIntegers();
            //RemovesNegativeNumbers();
            //RemoveIfAppearsOddNumberOfTimes();
            //FindNumberOfTimesANumberAppears();
            //NumberOfTimes();

            #region StringAndText
            //ReversedString();
            //BracketChecker();
            //BackSlashCharacter();
            //SubstringsAppearancesCount();
            //ModifiedCasing();
            //AstericComplements();
            //StringToUnicode();
            //EncryptsText();
            //ExtractInSentences();
            //ForbiddenWords();
            //NumberInDifferentFormats();
            //URLSplitter();
            //ReverseSentenceOrder();
            //Dictionary();
            //HTMLParser();
            //DaysCountBetweenTwoDates();
            //DateAfter6HoursAnd30Minutes();
            //ExtractEmailAddresses();
            //DateFinder();
            //ExtractPalindromes();
            //LettersCountInText();
            //WordsCountInText();
            //RepetitionRemover();
            //SortWordsAlphabetically();
            //ExtractHTMLTags(); 
            #endregion

            #region Arrays
            //IndexMultipliedByFive();
            //CompareTwoArrays(); 
            //**CharLexicographicalComparison();
            //MaxSequenceEqualElements();
            //LongestIncreasingSequence();
            //LongestIncreasingSequenceNotConsecutively();
            //**MaxSumOfSequentialElements();
            //SelectionSort();
            //SubsequenceWithMaxSum();
            //MostFrequentNumber();
            //**FindSubsequenceOfGivenSum();
            //PrintMatrix();
            //Find3x3MatrixWithMaxSum();
            //**FindTheLongestSubsequeanceOfEqualElements();
            //**IndexOfLetters();
            //BinarySearch();
            //MergeSort();
            //QuickSort();
            //AllPrimeNumbers();
            //**SubSequenceWithGivenSum();
            //**SumSeqOfGivenSum();
            //SubsequenceOfIncreasingNumbers();
            //Permutations();
            //AllCombinations(); 
            #endregion
    	}

        /// <summary>
        /// The majorant of an array of size N is a value that occurs in it 
        /// at least N/2 + 1 times. Write a program that finds the 
        /// majorant of given array and prints it. If it does not 
        /// exist, print "The majorant does not exist!".
        /// Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
        /// </summary>
        private static void NumberOfTimes()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> seq = new List<int>();
            string[] nums = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in nums)
            {
                seq.Add(int.Parse(item));
            }

            List<NumberOfTimes> nt = new List<NumberOfTimes>();

            foreach (var num in seq)
            {
                bool flag = true;

                for (int i = 0; i < nt.Count; i++)
                {
                    if (num == nt[i].Number)
                    {
                        nt[i].Times++;
                        flag = false;
                    }
                }

                if (flag)
                {
                    nt.Add(new NumberOfTimes(num, 1));
                }
            }

            foreach (var item in nt)
            {
                if (item.Times >= n / 2 + 1)
                {
                    Console.WriteLine(item.Number);
                    break;
                }
            }


            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that finds in a given array of integers 
        /// (in the range [0…1000]) how many times each of them occurs.
        /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        /// 2  2 times
        /// 3  4 times
        /// 4  3 times
        /// </summary>
        private static void FindNumberOfTimesANumberAppears()
        {
            List<int> seq = new List<int>();
            string[] nums = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in nums)
            {
                seq.Add(int.Parse(item));
            }

            int[] numberOfTimes = new int[1001];

            foreach (int item in seq)
            {
                numberOfTimes[item]++;
            }

            for (int i = 0; i < numberOfTimes.Length; i++)
            {
                if (numberOfTimes[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, numberOfTimes[i]);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that removes from a given sequence 
        /// all numbers that appear an odd count of times.
        /// Example: array = {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}
        ///  {5, 3, 3, 5}
        /// </summary>
        private static void RemoveIfAppearsOddNumberOfTimes()
        {
            List<int> seq = new List<int>();
            string[] nums = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in nums)
            {
                seq.Add(int.Parse(item));
            }


            int[,] numbersTimes = new int[2, seq.Count];
            int count = 0;
            foreach (int num in seq)
            {
                bool didAppear = false;

                for (int j = 0; j < count; j++)
                {
                    if (num == numbersTimes[0, j])
                    {
                        numbersTimes[1, j] ^= 1;
                        didAppear = true;
                    }
                }

                if (!didAppear)
                {
                    numbersTimes[0, count] = num;
                    numbersTimes[1, count++] ^= 1;
                }
            }

            for (int i = 0; i < count; i++)
            {
                if (numbersTimes[1, i] == 1)
                {
                    while (seq.IndexOf(numbersTimes[0, i]) != -1)
                    {
                        seq.Remove(numbersTimes[0, i]);
                    }
                }
            }

            foreach (var item in seq)
            {
                Console.Write("{0} ", item);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which removes all negative numbers from a sequence.
        /// Example: array = {19, -10, 12, -6, -3, 34, -2, 5}  {19, 12, 34, 5}
        /// </summary>
        private static void RemovesNegativeNumbers()
        {
            string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<double> seq = new List<double>();
            for (int i = 0; i < numbers.Length; i++)
            {
                seq.Add(double.Parse(numbers[i]));
            }

            List<double> positiveSeq = new List<double>();
            foreach (var item in seq)
            {
                if (!(item < 0))
                {
                    positiveSeq.Add(item);
                }
            }

            foreach (var item in positiveSeq)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Write a method that finds the longest subsequence of equal
        /// numbers in a given List<int> and returns the result as 
        /// new List<int>. Write a program to test whether the method works correctly.
        /// </summary>
        private static void LongestSubseqOfEqualIntegers()
        {
            string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> longestSeq = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                longestSeq.Add(int.Parse(numbers[i]));
            }

            longestSeq = findLongestSeq(longestSeq);

            foreach (var item in longestSeq)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        static List<int> findLongestSeq(List<int> sequence)
        {
            List<int> currentSeq = new List<int>();
            List<int> bestSeq = new List<int>();


            bestSeq.Add(sequence[0]);
            currentSeq.Add(sequence[0]);
            for (int i = 1; i < sequence.Count; i++)
            {
                int current = sequence[i];

                if (current == currentSeq[0])
                {
                    currentSeq.Add(current);
                }
                else
                {
                    if (currentSeq.Count > bestSeq.Count)
                    {
                        bestSeq = currentSeq;
                    }
                    currentSeq = new List<int>();
                    currentSeq.Add(current);
                }
            }

            if (currentSeq.Count > bestSeq.Count)
            {
                bestSeq = currentSeq;
            }

            return bestSeq;
        }

        /// <summary>
        /// Write a program that reads from the console a sequence of positive 
        /// integer numbers. The sequence ends when an empty line is entered. 
        /// Print the sequence sorted in ascending order.
        /// </summary>
        private static void SortSeqOfIntegers()
        {
            List<int> seq = new List<int>();

            string str;

            while ((str = Console.ReadLine()) != "")
            {
                seq.Add(int.Parse(str));
            }

            int[] array = seq.ToArray();

            Array.Sort(array);

            seq = array.ToList<int>();

            foreach (int number in seq)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which reads from the console N integers 
        /// and prints them in reversed order. Use the Stack<int> class.
        /// </summary>
        private static void StackReverseDemo()
        {
            int n = int.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }

            while (stack.Count > 1)
            {
                Console.Write("{0} ", stack.Pop());
            }
            Console.WriteLine(stack.Pop());

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reads from the console a sequence of 
        /// positive integer numbers. The sequence ends when empty line
        /// is entered. Calculate and print the sum and the average of 
        /// the sequence. Keep the sequence in List<int>.
        /// </summary>
        private static void SumAndAveragesOfPositiveIntegers()
        {
            List<int> seq = new List<int>();
            string str;
            int sum = 0;
            while ((str = Console.ReadLine()) != "")
            {
                int num = int.Parse(str);
                seq.Add(num);
                sum += num;
            }

            Console.WriteLine(sum);
            Console.WriteLine((double)sum / seq.Count);
            Console.ReadLine();
        }

        #region StringsAndTexts
        /// <summary>
        /// Write a program that extracts all the text without 
        /// any tags and attribute values from an HTML document.
        /// </summary>
        private static void ExtractHTMLTags()
        {
            const int LengthOfTitleTag = 7; // length of "<title>" tag is 7
            byte numberOfLines = byte.Parse(Console.ReadLine());
            StringBuilder initialText = new StringBuilder();
            for (byte i = 0; i < numberOfLines; i++)
            {
                string inputLine = Console.ReadLine();
                initialText.Append(inputLine);
            }

            bool inTag = false;

            string textAsStringVariable = initialText.ToString();

            int titleStartIndex = textAsStringVariable.IndexOf("<title>");
            int titleEndIndex = textAsStringVariable.IndexOf("</title>");
            int lengthOfTextTitle = int.MinValue;
            string title = null;

            if (titleStartIndex != -1 && titleEndIndex != -1)
            {
                lengthOfTextTitle = titleEndIndex - (titleStartIndex + LengthOfTitleTag);
                title = textAsStringVariable.Substring(titleStartIndex + LengthOfTitleTag,
                lengthOfTextTitle); // extracting TITLE from initial text
            }

            else
            {
                // make sure the title tags are not capitalized
                titleStartIndex = textAsStringVariable.IndexOf("<TITLE>");
                titleEndIndex = textAsStringVariable.IndexOf("</TITLE>");

                if (titleStartIndex != -1 && titleEndIndex != -1)
                {
                    lengthOfTextTitle = titleEndIndex - (titleStartIndex + LengthOfTitleTag);
                    title = textAsStringVariable.Substring(titleStartIndex + LengthOfTitleTag,
                    lengthOfTextTitle); // extracting TITLE from initial text
                }
            }

            if (title != null && title != "") // if there is an existing Title
            {
                Console.WriteLine("Title: {0}", title);
                textAsStringVariable = textAsStringVariable.Remove(titleStartIndex + 7,
                lengthOfTextTitle); // Remove from text since it's already shown
            }

            else
            {
                Console.WriteLine("*No title*");
            }

            StringBuilder cleanText = new StringBuilder();

            for (int i = 0; i < textAsStringVariable.Length; i++)
            {

                if (inTag == true)
                {
                    if (textAsStringVariable[i].Equals('>'))
                    {
                        inTag = false;
                        cleanText.Append(" "); /* add space to avoid concatenating two words
                                              when removing tags */
                    }
                }

                else
                {
                    if (textAsStringVariable[i].Equals('<'))
                    {
                        inTag = true;
                    }

                    else
                    {
                        cleanText.Append(textAsStringVariable[i]);
                    }
                }
            }

            Console.WriteLine("Body: ");
            string text = cleanText.ToString(); // Convert to string the 'cleaned' text
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Separate each word and trim empty spaces

            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reads a list of words separated 
        /// by commas from the console and prints them in 
        /// alphabetical order (after sorting).
        /// </summary>
        private static void SortWordsAlphabetically()
        {
            string input = Console.ReadLine();
            char[] separators = new char[] { ' ', ',' };
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reads a string from the console and 
        /// replaces every sequence of identical letters in it with a 
        /// single letter (the repeating letter). 
        /// Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
        private static void RepetitionRemover()
        {
            string stringToProcess = Console.ReadLine();
            Console.WriteLine(RemoveRepetitiveChars(stringToProcess));
            Console.ReadLine();
        }

        static string RemoveRepetitiveChars(string stringToProcess)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < stringToProcess.Length; i++)
            {
                if (i == 0)
                {
                    result.Append(stringToProcess[i]);
                }
                else if (stringToProcess[i - 1] != stringToProcess[i])
                {
                    result.Append(stringToProcess[i]);
                }
            }
            return result.ToString();
        }



        /// 
        /// Write a program that reads a string from the console 
        /// and prints in alphabetical order all words from the 
        /// input string and how many times each one of them occurs in the string.
        /// </summary>
        private static void WordsCountInText()
        {
            string userInput = Console.ReadLine();
            SortedDictionary<string, int> words = GetWordsInText(userInput);
            foreach (var item in words)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
            Console.ReadLine();
        }

        private static SortedDictionary<string, int> GetWordsInText(string text)
        {
            SortedDictionary<string, int> words = new SortedDictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == ' ' || c == '.' || c == ',' || c == '!' || c == '?' || c == '-')
                {
                    SaveWord(sb, words);
                }
                else
                {
                    sb.Append(c);
                }
            }
            SaveWord(sb, words);
            return words;
        }

        private static void SaveWord(StringBuilder sb, SortedDictionary<string, int> dict)
        {
            if (sb.Length == 0)
            {
                return;
            }
            string word = sb.ToString().ToLower();
            sb.Clear();
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }

        /// <summary>
        /// Write a program that reads a string from the console 
        /// and prints in alphabetical order all letters from the
        /// input string and how many times each one of them occurs in the string.
        /// </summary>
        private static void LettersCountInText()
        {
            string userInput = Console.ReadLine();
            int[] characters = new int[65536];
            foreach (char currentCharacter in userInput)
            {
                characters[currentCharacter]++;
            }
            for (int i = 0; i < characters.Length; i++)
            {
                char currentCharacter = (char)i;
                if (char.IsLetter(currentCharacter) && characters[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", currentCharacter, characters[i]);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that extracts from a text all 
        /// words which are palindromes, such as ABBA", "lamal", "exe".
        /// </summary>
        private static void ExtractPalindromes()
        {
            string inputText = Console.ReadLine();
            char[] separators = { ',', ' ', '.', };
            string[] splitinput = inputText.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);

            List<string> palindromes = new List<string>();
            foreach (var item in splitinput)
            {
                if (IsTheWordPalindrom(item) == true)
                {
                    palindromes.Add(item);
                }
            }

            foreach (string palindrom in palindromes)
            {
                Console.Write("{0} ", palindrom);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        static bool IsTheWordPalindrom(string inputWord)
        {
            bool result = true;
            for (int i = 0; i < inputWord.Length / 2; i++)
            {
                if (inputWord[i] != inputWord[inputWord.Length - i - 1])
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Write a program that extracts from a text all dates written in 
        /// format DD.MM.YYYY and prints them on the console in the 
        /// standard format for Canada. Sample text:
        /// </summary>
        private static void DateFinder()
        {
            string textInput = Console.ReadLine();
            FindDates(textInput);
            Console.ReadLine();
        }

        static void FindDates(string textToCheck)
        {
            string pattern = @"[^\.]\b(?<Day>[12]\d|0?[1-9]|3[01])\.(?<Month>0?[1-9]|12|11|10)\.(?<Year>(?:\d{4}))\b";
            MatchCollection dates = Regex.Matches(textToCheck, pattern);

            CultureInfo canadianCultureInfo = new CultureInfo("en-CA");

            for (int i = 0; i < dates.Count; i++)
            {
                Match currentDate = dates[i];
                DateTime dateToPrint = new DateTime(
                    int.Parse(currentDate.Groups["Year"].ToString()),
                    int.Parse(currentDate.Groups["Month"].ToString()),
                    int.Parse(currentDate.Groups["Day"].ToString())
                    );

                Console.WriteLine(dateToPrint.ToString("d", canadianCultureInfo));
            }
        }

        /// <summary>
        /// Write a program that extracts all e-mail addresses from a text. 
        /// These are all substrings that are limited on both sides by text
        /// end or separator between words and match the shape 
        /// <sender>@<host>…<domain>.
        /// </summary>
        private static void ExtractEmailAddresses()
        {
            string sampleText = Console.ReadLine();
            string pattern = @"([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})";

            MatchCollection results = Regex.Matches(sampleText, pattern);
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(results[i]);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reads the date and time entered in 
        /// the format "day.month.year hour:minutes:seconds" and 
        /// prints the date and time after 6 hours and 30 
        /// minutes in the same format.
        /// </summary>
        private static void DateAfter6HoursAnd30Minutes()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            string userInput = Console.ReadLine();
            DateTime date = Convert.ToDateTime(userInput);
            date = date.AddHours(6);
            date = date.AddMinutes(30);
            Console.WriteLine(date);
        }

        /// <summary>
        /// Write a program that reads two dates entered in the format "day.month.year" and calculates the number of days between them.
        /// Enter the first date: 27.02.2006
        /// Enter the second date: 3.03.2006
        /// Distance: 4 days
        /// </summary>
        private static void DaysCountBetweenTwoDates()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "d.M.yyyy";

            string firstUserInput = Console.ReadLine();
            string secondUserInput = Console.ReadLine();
            DateTime firstDate = DateTime.ParseExact(firstUserInput, format, provider);
            DateTime secondDate = DateTime.ParseExact(secondUserInput, format, provider);
            DateTime startDate = firstDate;
            DateTime endDate = secondDate;
            if (firstDate > secondDate)
            {
                startDate = secondDate;
                endDate = firstDate;
            }

            int daysCount = (endDate - startDate).Days;
            Console.WriteLine(daysCount);
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that replaces all hyperlinks in a 
        /// HTML document consisting of <a href="…">…</a> and
        /// hyperlinks in "forum" style, which look like [URL=…]…[/URL].
        /// </summary>
        private static void HTMLParser()
        {
            string source = Console.ReadLine();
            Console.WriteLine(ParseHTML(source));
            Console.ReadLine();
        }

        static string ParseHTML(string htmlSource)
        {
            string pattern = @"<a.href=""([^>]*)"">([^<]*(?:(?!</a)<[^<]*)*)</a>";
            return Regex.Replace(htmlSource, pattern, "[URL=$1]$2[/URL]");
        }

        /// <summary>
        /// A dictionary is given, which consists of several lines of text. 
        /// Each line consists of a word and its explanation, separated by a hyphen:
        /// .NET – platform for applications from Microsoft
        /// 494 Fundamentals of Computer Programming with C#
        /// CLR – managed execution environment for .NET namespace
        /// – hierarchical organization of classes
        /// Write a program that parses the dictionary and then reads words 
        /// from the console in a loop, gives an explanation for it or writes
        /// a message on the console that the word is not into the dictionary.
        /// </summary>
        private static void Dictionary()
        {
            int wordsCount = 0;
            try
            {
                wordsCount = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("The Dictionary Cannot be Empty");
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < wordsCount; i++)
            {
                string input = Console.ReadLine();
                string[] splitinput = input.Split('-');
                dictionary.Add(splitinput[0].TrimEnd(), splitinput[1].TrimStart());
            }

            string inputWord = Console.ReadLine();
            if (inputWord == string.Empty)
            {
                Console.WriteLine("Search value cannot be empty");
                return;
            }
            try
            {
                Console.WriteLine("{0} - {1}", inputWord, dictionary[inputWord]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The word is not in the dictionary.");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reverses the words in a given 
        /// sentence without changing punctuation and spaces. 
        /// For example: "C# is not C++ and PHP is not Delphi" 
        /// "Delphi not is PHP and C++ not is C#".
        /// </summary>
        private static void ReverseSentenceOrder()
        {
            string input = Console.ReadLine();
            StringBuilder reversed = new StringBuilder();
            char[] separator = new char[] { space };
            string[] words = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string local;
            for (int index = words.Length - 1; index >= 0; index--)
            {
                local = ComposeWord(words[index]);
                reversed.Append(local + space);
            }

            Console.WriteLine(reversed.ToString());
            Console.ReadLine();
        }

        public static string ComposeWord(string word)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder charactersToAdd = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                foundChar = false;
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (symbols[j] == word[i])
                    {
                        foundChar = true;
                        charactersToAdd.Append(symbols[j]);
                    }
                }
            }

            if (foundChar)
            {
                result.Append(charactersToAdd);
                result.Append(word.Substring(0, word.Length - charactersToAdd.Length));
                return result.ToString();
            }


            else
            {
                return word;
            }
        }

        /// <summary>
        /// Write a program that parses an URL in following format:
        /// [protocol]://[server]/[resource]
        /// It should extract from the URL the protocol, server and resource parts. 
        /// For example, when http://www.cnn.com/video is passed, the result is:
        /// [protocol]="http"
        /// [server]="www.cnn.com"
        /// [resource]="/video"
        /// </summary>
        private static void URLSplitter()
        {
            string url = Console.ReadLine();
            TestParseURL(url);
            Console.ReadLine();
        }

        static void TestParseURL(string url)
        {
            string pattern = @"^(?<protocol>[a-z]+)(?:://)" +
                                   @"(?<server>[^<>=/\?#]+)" +
                                   @"(?<resource>/.*|.*)" +
                                   "|" +
                                   @"^(?<server>[^<>=/\?#]+)" +
                                   "(?<resource>/.*|.*)";

            Regex urlRegex = new Regex(pattern, RegexOptions.ExplicitCapture);
            Match matchedURL = urlRegex.Match(url);

            Console.WriteLine("[protocol] = " + matchedURL.Groups["protocol"]);
            Console.WriteLine("[server] = " + matchedURL.Groups["server"]);
            Console.WriteLine("[resource] = " + matchedURL.Groups["resource"]);
        }

        /// <summary>
        /// Write a program that reads a number from console 
        /// and prints it in 15-character field, aligned right
        /// in several ways: as a decimal number, hexadecimal 
        /// number, percentage, currency and exponential 
        /// (scientific) notation.
        /// </summary>
        private static void NumberInDifferentFormats()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("{0,15:D}", number); // decimal
                Console.WriteLine("{0,15:X}", number); // hexademical
                Console.WriteLine("{0,15:P}", number); // percentage
                Console.WriteLine("{0,15:C}", number); // currency
                Console.WriteLine("{0,15:#.##E+0}", number); // scientific
            }

            catch (FormatException)
            {

                Console.WriteLine("Incorrect input!");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Incorrect input!");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// A string is given, composed of several "forbidden" 
        /// words separated by commas. Also a text is given, 
        /// containing those words. Write a program that 
        /// replaces the forbidden words with asterisks.
        /// </summary>
        private static void ForbiddenWords()
        {
            string input = Console.ReadLine();
            string[] forbidden = input.Split(',');

            input = Console.ReadLine();


            string[] asterisk = new string[forbidden.Length];
            for (int i = 0; i < forbidden.Length; i++)
            {
                StringBuilder sb = new StringBuilder(forbidden[i].Length);

                for (int p = 0; p < forbidden[i].Length; p++)
                {
                    sb.Append('*');
                }
                asterisk[i] = sb.ToString();
            }
            for (int i = 0; i < forbidden.Length; i++)
            {
                input = input.Replace(forbidden[i], asterisk[i]);
            }
            Console.WriteLine(input);
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that extracts from a text all sentences 
        /// that contain a particular word. We accept that the sentences 
        /// are separated from each other by the character "." 
        /// and the words are separated from one another 
        /// by a character which is not a letter.
        /// </summary>
        private static void ExtractInSentences()
        {
            string text = Console.ReadLine();
            string word = Console.ReadLine().ToLower();
            string result = ExtractSentances(text, word);
            if (result.Length > 0)
            {
                Console.Write(result);
            }
            else
            {
                Console.WriteLine("[no result]");
            }
            Console.ReadLine();
        }

        static string ExtractSentances(string text, string word)
        {
            if (word.Length == 0)
            {
                return string.Empty;
            }

            string[] sentences = text.Split('.');
            StringBuilder sb = new StringBuilder();

            foreach (string item in sentences)
            {
                string sentence = item.TrimStart();
                int index = 0;
                while (index != -1)
                {
                    index = sentence.ToLower().IndexOf(word, index);
                    if (index == -1)
                    {
                        continue;
                    }
                    int lastIndex = index + word.Length;
                    if (IsSeparateWord(word, sentence, index - 1, lastIndex))
                    {
                        sb.AppendFormat("{0}.", sentence);
                        sb.Append(Environment.NewLine);
                        break;
                    }
                    index++;
                }
            }
            return sb.ToString();
        }

        static bool IsSeparateWord(string word, string sentence, int indexBefore, int indexAfter)
        {
            bool isSeparateWord = IsOnlyWord(sentence, indexBefore, indexAfter) ||
                            IsFirstWord(sentence, indexBefore, indexAfter) ||
                            IsLastWord(sentence, indexBefore, indexAfter) ||
                            IsMiddleWord(sentence, indexBefore, indexAfter);
            return isSeparateWord;
        }

        static bool IsOnlyWord(string sentence, int indexBefore, int indexAfter)
        {
            if (indexBefore == -1 && indexAfter == sentence.Length)
            {
                return true;
            }
            return false;
        }

        static bool IsFirstWord(string sentence, int indexBefore, int indexAfter)
        {
            if (indexBefore == -1)
            {
                if (!char.IsLetter(sentence[indexAfter]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        static bool IsLastWord(string sentence, int indexBefore, int indexAfter)
        {
            if (indexAfter == sentence.Length)
            {
                if (!char.IsLetter(sentence[indexBefore]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        static bool IsMiddleWord(string sentence, int indexBefore, int indexAfter)
        {
            if (indexBefore != -1 && indexAfter != sentence.Length &&
                !char.IsLetter(sentence[indexBefore]) && !char.IsLetter(sentence[indexAfter]))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Write a program that encrypts a text by applying XOR (excluding or) 
        /// operation between the given source characters and given cipher 
        /// code. The encryption should be done by applying XOR between
        /// the first letter of the text and the first letter of the 
        /// code, the second letter of the text and the second letter 
        /// of the code, etc. until the last letter of the code, then 
        /// goes back to the first letter of the code and the next letter
        /// of the text. Print the result as a series of Unicode escape characters \xxxx.
        /// </summary>
        private static void EncryptsText()
        {
            string input = Console.ReadLine();

            string cipher = Console.ReadLine();
            int a = 0;
            StringBuilder coded = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                uint firstletter = Convert.ToUInt16(input[i]);
                uint cipherletter = Convert.ToUInt16(cipher[a]);
                uint final = firstletter ^ cipherletter;

                string result = String.Format(@"\u{0:x4}", final);

                coded.Append(result);
                if (a == cipher.Length - 1)
                {
                    a = 0;
                }
                else
                {
                    a++;
                }
            }
            string finished = coded.ToString();

            Console.WriteLine(finished);
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that converts a given string into 
        /// the form of array of Unicode escape sequences in 
        /// the format used in the C# language. Sample input: 
        /// "Test". Result: "\u0054\u0065\u0073\u0074".
        /// </summary>
        private static void StringToUnicode()
        {
            string input = Console.ReadLine();
            int[] charsToInt = new int[input.Length];
            StringBuilder converted = new StringBuilder();
            string unicode;
            for (int index = 0; index < charsToInt.Length; index++)
            {
                charsToInt[index] = input[index];
                unicode = string.Format(@"\u{0:x4}", charsToInt[index]);
                converted.Append(unicode);
            }
            Console.WriteLine(converted.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that reads a string from the console
        /// (20 characters maximum) and if shorter complements 
        /// it right with "*" to 20 characters.
        /// </summary>
        private static void AstericComplements()
        {
            string input = Console.ReadLine();
            if (input.Length > 20)
            {
                Console.WriteLine("String is too long! Must be <= 20 chars.");
            }
            StringBuilder fullstring = new StringBuilder(20);
            for (int i = 0; i < 20; i++)
            {
                if (i >= input.Length)
                {
                    fullstring.Append('*');
                }
                else
                {
                    fullstring.Append(input[i]);
                }
            }
            Console.WriteLine(fullstring.ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// A text is given. Write a program that modifies the 
        /// casing of letters to uppercase at all places in 
        /// the text surrounded by <upcase> and </upcase> tags.
        /// </summary>
        private static void ModifiedCasing()
        {
            string text = Console.ReadLine();
            Console.WriteLine(ToUpperCase(text));
            Console.ReadLine();
        }

        static string ToUpperCase(string input)
        {

            string[] splittext = input.Split('<', '>');
            StringBuilder result = new StringBuilder(input.Length);
            for (int i = 0; i < splittext.Length; i++)
            {
                if (splittext[i] != "upcase" && splittext[i] != "/upcase")
                {
                    result.Append(splittext[i]);
                }
                else if (splittext[i] == "upcase")
                {
                    result.Append((splittext[i + 1].ToString().ToUpper()));
                    i++;
                }

            }
            return result.ToString();
        }

        /// <summary>
        /// Write a program that detects how many times a 
        /// substring is contained in the text.
        /// </summary>
        private static void SubstringsAppearancesCount()
        {
            string text = Console.ReadLine();
            string substring = Console.ReadLine();
            int count = CountSubstringsAppearances(text.ToLower(), substring.ToLower());
            Console.WriteLine(count);
            Console.ReadLine();
        }

        private static int CountSubstringsAppearances(string text, string substring)
        {
            if (substring.Length == 0)
            {
                return 0;
            }
            int count = 0;
            int index = 0;
            while (true)
            {
                index = text.IndexOf(substring, index);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    count++;
                    index++;
                }
            }
            return count;
        }

        /// <summary>
        /// How many backslashes you must specify as an argument to 
        /// the method Split(…) in order to split the text by a backslash?
        /// Example: one\two\three.
        /// </summary>
        private static void BackSlashCharacter()
        {
            char[] separator = new char[] { '\\' };
            string input = Console.ReadLine();
            string[] words = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program that checks whether the parentheses
        /// are placed correctly in an arithmetic expression. 
        /// Example of expression with correctly placed brackets: 
        /// ((a+b)/5-d). Example of an incorrect expression: )(a+b)).
        /// </summary>
        private static void BracketChecker()
        {
            string expressionToCheck = Console.ReadLine();
            bool result = IsExpressionCorrect(expressionToCheck);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static bool IsExpressionCorrect(string expressionToCheck)
        {
            int bracketCounter = 0;
            for (int i = 0; i < expressionToCheck.Length; i++)
            {
                if (expressionToCheck[i] == '(')
                {
                    bracketCounter++;
                }
                else if (expressionToCheck[i] == ')')
                {
                    bracketCounter--;
                }
                if (bracketCounter < 0)
                {
                    break;
                }
            }
            if (bracketCounter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Write a program that reads a string, reverse it and 
        /// prints it to the console. For example: "introduction"  "noitcudortni".
        /// </summary>
        private static void ReversedString()
        {
            string originalString = Console.ReadLine();
            string reversedString = ReverseString(originalString);

            Console.WriteLine(reversedString);
            Console.ReadLine();
        }

        static string ReverseString(string originalString)
        {
            StringBuilder reversedString = new StringBuilder();
            for (int i = originalString.Length - 1; i >= 0; i--)
            {
                reversedString.Append(originalString[i]);
            }
            return reversedString.ToString();
        } 
        #endregion

        #region Arrays
        /// <summary>
        /// Write a program, which reads an integer number N from 
        /// the console and prints all combinations of K elements 
        /// of numbers in range [1 … N]. Example: N = 5, K = 2  
        /// {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, 
        /// {3, 4}, {3, 5}, {4, 5}.
        /// </summary>
        private static void AllCombinations()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] variation = new int[k];
            for (int i = 0; i < k; i++)
            {
                variation[i] = 1;
            }
            bool combEnd = false;
            int currIndex = k - 1;
            while (!combEnd)
            {
                for (int j = 0; j < k; j++)//print current variation
                {
                    Console.Write(variation[j]);
                    if (j < k - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();

                variation[currIndex]++;

                if (variation[currIndex] > n)
                {
                    while (variation[currIndex] > n)
                    {
                        variation[currIndex] = 1;
                        currIndex--;
                        if (currIndex >= 0)
                        {
                            variation[currIndex]++;
                        }
                        else
                        {
                            combEnd = true;
                            break;
                        }
                    }
                    currIndex = k - 1;
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which reads the integer numbers N and K 
        /// from the console and prints all variations of K elements
        /// of the numbers in the interval [1…N]. Example: N = 3, 
        /// K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2},
        /// {2, 3}, {3, 1}, {3, 2}, {3, 3}.
        /// </summary>
        private static void Permutations()
        {
            int n = int.Parse(Console.ReadLine());
            int[] permutationElements = new int[n];
            for (int i = 0; i < n; i++)
            {
                permutationElements[i] = i + 1;
            }
            int[] factorialNumbers = new int[n];
            bool[] used = new bool[n];
            bool permEnd = false;
            int currIndex = n - 1;
            while (!permEnd)
            {
                for (int i = 0; i < n; i++)//print current permutation
                {
                    int countOfUsed = -1;
                    for (int j = 0; j < n; j++)
                    {
                        if (!used[j])
                        {
                            countOfUsed++;
                            if (countOfUsed == factorialNumbers[i])
                            {
                                Console.Write(permutationElements[j]);
                                if (i < n - 1)
                                {
                                    Console.Write(" ");
                                }
                                used[j] = true;
                            }
                        }
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < n; i++)//zero used
                {
                    used[i] = false;
                }

                factorialNumbers[currIndex]++;

                if (factorialNumbers[currIndex] > n - currIndex - 1)
                {
                    while (factorialNumbers[currIndex] > n - currIndex - 1)
                    {
                        factorialNumbers[currIndex] = 0;
                        currIndex--;
                        if (currIndex >= 0)
                        {
                            factorialNumbers[currIndex]++;
                        }
                        else
                        {
                            permEnd = true;
                            break;
                        }
                    }
                    currIndex = n - 1;
                }

            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which reads an array of integer numbers from the 
        /// console and removes a minimal number of elements in such a 
        /// way that the remaining array is sorted in an increasing order.
        /// Example: {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
        /// </summary>
        private static void SubsequenceOfIncreasingNumbers()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }

            int[] result = LongestIncSubsequence(arr);

            Console.Write("{");
            foreach (int num in result)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" }");
            Console.ReadLine();
        }

        public static int[] LongestIncSubsequence(int[] array)
        {
            int[] increasingLengths = new int[array.Length];
            increasingLengths[0] = 1;
            for (int i = 1; i < increasingLengths.Length; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i] && increasingLengths[j] > maxLength)
                    {
                        maxLength = increasingLengths[j];
                    }
                }
                increasingLengths[i] = maxLength + 1;
            }

            int[] sortedSubset = new int[increasingLengths.Max()];
            int serialNumber = increasingLengths.Max();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (serialNumber == increasingLengths[i])
                {
                    sortedSubset[serialNumber - 1] = array[i];
                    serialNumber--;
                }
            }

            return sortedSubset;
        }


        /// <summary>
        /// Write a program which by given N numbers, K and S, finds K elements out
        /// of the N numbers, the sum of which is exactly S or says it is not possible.
        /// Example: {3, 1, 2, 4, 9, 6}, S = 14, K = 3  yes (1 + 2 + 4 = 14)
        /// </summary>
        public static void SumSeqOfGivenSum()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int usedSum;
            List<int> usedNums = new List<int>();
            List<int> unusedNums = arr.ToList();

            usedNums.Add(arr[0]);
            unusedNums.RemoveAt(0);
            usedSum = usedNums.Sum();

            while (usedSum != s || usedNums.Count != k)
            {
                if (s > usedSum)
                {
                    usedNums.Add(unusedNums[0]);
                    unusedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
                else
                {
                    unusedNums.Add(usedNums[0]);
                    usedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
            }

            Console.Write("yes (");
            foreach (int num in usedNums)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" )");
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which checks whether there is a subset of given
        /// array of N elements, which has a sum S. The numbers N, S and the array
        /// values are read from the console. Same number can be used many times.
        /// Example: {2, 1, 2, 4, 3, 5, 2, 6}, S = 14  yes (1 + 2 + 5 + 6 = 14)
        /// </summary>
        public static void SubSequenceWithGivenSum()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            int s = int.Parse(Console.ReadLine());

            int usedSum;
            List<int> usedNums = new List<int>();
            List<int> unusedNums = new List<int>();

            usedNums.Add(arr[0]);

            unusedNums = arr.ToList();
            unusedNums.RemoveAt(0);

            usedSum = usedNums.Sum();

            while (usedSum != s)
            {
                if (s > usedSum)
                {
                    usedNums.Add(unusedNums[0]);
                    unusedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
                else
                {
                    unusedNums.Add(usedNums[usedNums.Count - 1]);
                    usedNums.RemoveAt(usedNums.Count - 1);
                    usedSum = usedNums.Sum();
                }
            }

            Console.Write("yes (");
            foreach (int num in usedNums)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" )");
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which finds all prime numbers in the range
        /// [1…10,000,000].
        /// </summary>
        public static void AllPrimeNumbers()
        {
            //int num = 10000000;
            int num = 100;
            bool[] flag = new bool[num];

            for (int i = 2; i < num; i++)
            {
                flag[i] = true;
            }

            for (int i = 2; i < num; i++)
            {
                if (flag[i] == true)
                {
                    int j = i + 1;
                    while (j < num)
                    {
                        if (j % i == 0)
                        {
                            flag[j] = false;
                        }
                        j++;
                    }
                }
            }

            for (int i = 2; i < num; i++)
            {
                if (flag[i] == true)
                {
                    Console.Write("{0} - ", i);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which sorts an array of integer elements using a "quick
        /// sort" algorithm.
        /// </summary>
        public static void QuickSort()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] unsorted = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                unsorted[i] = int.Parse(inputOne[i]);
            }

            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }

            Console.WriteLine();

            Quicksort(unsorted, 0, unsorted.Length - 1);

            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }
            Console.ReadLine();
        }

        public static void Quicksort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        /// <summary>
        /// Write a program, which sorts an array of integer elements using a "merge
        /// sort" algorithm.
        /// </summary>
        public static void MergeSort()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            arr = MergeSortArray(arr);

            PrintArray(arr);
        }

        public static void PrintArray(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.WriteLine("{0} ", numbersArray[i]);
            }
        }

        public static int[] MergeSortArray(int[] arrayToSort)
        {
            return (MergeSortList(arrayToSort.ToList<int>())).ToArray<int>();
        }

        public static List<int> MergeSortList(List<int> ListToSort)
        {
            if (ListToSort.Count <= 1)
            {
                return ListToSort;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> result = new List<int>();

            int middle = ListToSort.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(ListToSort[i]);
            }

            for (int i = middle; i < ListToSort.Count; i++)
            {
                right.Add(ListToSort[i]);
            }
            left = MergeSortList(left);
            right = MergeSortList(right);
            result = Merge(left, right);
            return result;
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            return result;
        }

        /// <summary>
        /// Write a program, which uses a binary search in a sorted array of
        /// integer numbers to find a certain element.
        /// </summary>
        public static void BinarySearch()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            Array.Sort(arr);
            int numberToFind = int.Parse(Console.ReadLine());

            BinarySearchInArray(numberToFind, arr);
            Console.ReadLine();
        }

        public static void BinarySearchInArray(int numberToFind, int[] array)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;
            int currentIndex = 0;

            currentIndex = (startIndex + endIndex) / 2;
            do
            {

                if (array[currentIndex] == numberToFind)
                {
                    Console.WriteLine("{0}", currentIndex);
                    return;
                }
                else if (array[currentIndex] > numberToFind)
                {
                    endIndex = currentIndex;
                    currentIndex = (startIndex + endIndex - 1) / 2;
                }
                else
                {
                    startIndex = currentIndex;
                    currentIndex = (startIndex + endIndex + 1) / 2;
                }

            } while (startIndex != endIndex);

            Console.WriteLine("Not found");
        }

        /// <summary>
        /// Write a program, which creates an array containing all Latin letters.
        /// The user inputs a word from the console and as result the program
        /// prints to the console the indices of the letters from the word.
        /// </summary>
        public static void IndexOfLetters()
        {
            string[] alphabetArray = new string[26];
            Console.WriteLine("Please enter a word:");
            string word = Console.ReadLine();

            for (int i = 0; i < 26; i++)
            {
                alphabetArray[i] = Convert.ToString(Convert.ToChar(i + 65));
            }
            Console.WriteLine();
            for (int i = 0; i < word.Length; i++)
            {
                PrintIndexOfLetter(alphabetArray, word, i);
            }
            Console.ReadLine();
        }

        public static void PrintIndexOfLetter(string[] alphabetArray, string word, int indexToStart)
        {
            word = word.ToUpper();
            for (int i = 0; i < 26; i++)
            {
                if (Convert.ToString(word[indexToStart]) == alphabetArray[i])
                {
                    Console.WriteLine("{0}->{1}", word[indexToStart], i);
                    return;
                }
            }
            Console.WriteLine("Error - Not a letter!");
        }

        /// <summary>
        /// Write a program, which creates a rectangular array with size of n by m
        /// elements. The dimensions and the elements should be read from the
        /// console. Find a platform with size of (3, 3) with a maximal sum.
        /// </summary>
        public static void FindTheLongestSubsequeanceOfEqualElements()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var matrix = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] transformation = input.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = transformation[j];
                }

            }

            // Find the longest sequence of equal strings
            Dictionary<string, int> sequence = new Dictionary<string, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int neighbourCount = LookupNeighbours(row, col);
                    if (neighbourCount == 0)
                    {
                        if (sequence.ContainsKey(matrix[row, col]))
                        {
                            sequence.Remove(matrix[row, col]);
                        }
                    }
                    else
                    {
                        if (sequence.ContainsKey(matrix[row, col]))
                        {
                            sequence[matrix[row, col]]++;
                        }
                        else
                        {
                            sequence.Add(matrix[row, col], 1);
                        }
                    }
                }
            }

            var sortedDict = (from entry in sequence orderby entry.Value ascending select entry)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            KeyValuePair<string, int> element;
            int index = sortedDict.Count - 1;
            element = sortedDict.ElementAt(index);

            int repeats = element.Value;
            string str = element.Key;

            string result = "";
            for (int i = 1; i <= repeats; i++)
            {
                result += " ";
                result += str;
            }

            Console.WriteLine(result);

        }

        public static int LookupNeighbours(int x, int y)
        {
            int[,] matrix = new int[x, y];
            int result = 0;
            for (int row = x - 1; row <= x + 1; row++)
            {
                if (row < 0 || row > matrix.GetLength(0) - 1)
                {
                    continue;
                }
                for (int col = y - 1; col <= y + 1; col++)
                {
                    if (col < 0 || col > matrix.GetLength(1) - 1 || (row == x && col == y))
                    {
                        continue;
                    }
                    if (matrix[row, col] == matrix[x, y])
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Write a program, which creates square matrices like 
        /// those in the figures below and prints them formatted 
        /// to the console. The size of the matrices will be read 
        /// from the console. See the examples for matrices with 
        /// size of 4 x 4 and make the other sizes in a similar fashion:
        /// </summary>
        public static void Find3x3MatrixWithMaxSum()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] transformation = input.Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(transformation[j]);
                }

            }

            int currentSum = 0;
            int maxSum = 0;
            int maxSquareX = 0;
            int maxSquareY = 0;
            // find square
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    for (int i2 = i; i2 < i + 3; i2++)
                    {
                        for (int j2 = j; j2 < j + 3; j2++)
                        {
                            currentSum += matrix[i2, j2];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSquareX = j;
                        maxSquareY = i;
                    }
                    currentSum = 0;
                }
            }
            // output
            for (int i2 = maxSquareY; i2 < maxSquareY + 3; i2++)
            {
                for (int j2 = maxSquareX; j2 < maxSquareX + 3; j2++)
                {
                    Console.Write(matrix[i2, j2] + " ");
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Write a program, which creates square matrices 
        /// like those in the figures below and prints them 
        /// formatted to the console. The size of the matrices 
        /// will be read from the console. See the examples for 
        /// matrices with size of 4 x 4 and make the other 
        /// sizes in a similar fashion:
        /// </summary>
        public static void PrintMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = DoMatrixA(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixB(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixC(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixD(n);
            PrintMatrix(matrix);

            Console.WriteLine();
            Console.ReadLine();
        }

        static int[,] DoMatrixA(int dim)
        {
            int[,] matrix = new int[dim, dim];

            matrix[0, 0] = 1;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[0, i] = matrix[0, i - 1] + dim;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + 1;
                }
            }

            return matrix;
        }

        static int[,] DoMatrixB(int dim)
        {
            int[,] matrix = new int[dim, dim];
            matrix[0, 0] = 1;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 1)
                {
                    matrix[0, i] = matrix[0, i - 1] + dim * 2 - 1;
                }
                else
                {
                    matrix[0, i] = matrix[0, i - 1] + 1;
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j % 2 == 1)
                    {
                        matrix[i, j] = matrix[i - 1, j] - 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j] + 1;
                    }
                }
            }

            return matrix;
        }

        static int[,] DoMatrixC(int dim)
        {
            int[,] matrix = new int[dim, dim];
            matrix[dim - 1, 0] = 1;
            int counter = 1;
            for (int row = dim - 2; row >= 0; row--)
            {
                matrix[row, 0] = matrix[row + 1, 0] + counter;
                int newRow = row;
                for (int diagonal = 1; diagonal <= counter; diagonal++)
                {
                    matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                    newRow++;
                }
                counter++;
            }

            matrix[0, dim - 1] = dim * dim;
            int diagonalLength = 2;
            int posX = 1;
            int posY = dim - 1;
            int prevX = 0;
            int prevY = dim - 1;

            for (int i = 1; i < counter - 1; i++)
            {
                for (int j = 1; j <= diagonalLength; j++)
                {
                    matrix[posX, posY] = matrix[prevX, prevY] - 1;
                    prevX = posX;
                    prevY = posY;
                    posX--;
                    posY--;
                }
                diagonalLength++;
                posX = i + 1;
                posY = dim - 1;
            }

            return matrix;
        }

        static int[,] DoMatrixD(int dim)
        {
            int[,] matrix = new int[dim, dim];
            int numConcentricSquares = (int)Math.Ceiling((dim) / 2.0);
            int j;
            int sideLen = dim;
            int currNum = 0;

            for (int i = 0; i < numConcentricSquares; i++)
            {

                // do left side
                for (j = 0; j < sideLen; j++)
                {
                    matrix[i + j, i] = ++currNum;
                }

                // do bottom side
                for (j = 1; j < sideLen - 1; j++)
                {
                    matrix[dim - 1 - i, i + j] = ++currNum;
                }

                // do right side
                for (j = sideLen - 1; j > 0; j--)
                {
                    matrix[i + j, dim - 1 - i] = ++currNum;
                }

                // do top side
                for (j = sideLen - 1; j > 0; j--)
                {
                    matrix[i, i + j] = ++currNum;
                }

                sideLen -= 2;
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Write a program to find a sequence of neighbor 
        /// numbers in an array, which has a sum of certain 
        /// number S.
        /// Example: {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}.
        /// </summary>
        public static void FindSubsequenceOfGivenSum()
        {
            int[] numbersArray = new int[] { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;

            FindSequenceOfGivenSum(numbersArray, sum);
            Console.ReadLine();
        }

        static void PrintArray(int startIndex, int endIndex, int[] array)
        {
            Console.WriteLine("Sequence of given sum is present:");
            Console.Write("{ ");
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.Write("}");
        }

        public static void FindSequenceOfGivenSum(int[] numbersArray, int sum)
        {
            long currentSum = 0;
            for (int currentEndIndex = 0; currentEndIndex < numbersArray.Length; currentEndIndex++)
            {
                currentSum = 0;
                for (int currentSumIndex = currentEndIndex; currentSumIndex >= 0; currentSumIndex--)
                {
                    currentSum += numbersArray[currentSumIndex];
                    if (currentSum == sum)
                    {
                        PrintArray(currentSumIndex, currentEndIndex, numbersArray);
                        return;
                    }
                }
            }
            Console.WriteLine("There is no sequence of given sum!");
        }

        /// <summary>
        /// Write a program, which finds the most frequently 
        /// occurring element in an array. 
        /// Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} 
        ///  4 (5 times).
        /// </summary>
        public static void MostFrequentNumber()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }

            int tempCounter = 1;
            int counter = 0;
            int index = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        tempCounter++;
                    }
                }
                if (tempCounter > counter)
                {
                    counter = tempCounter;
                    index = i;
                }
                tempCounter = 0;

            }
            Console.WriteLine(arr[index] + "  " + counter + " times");
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which finds a subsequence of 
        /// numbers with maximal sum. 
        /// E.g.: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  11
        /// </summary>
        public static void SubsequenceWithMaxSum()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }

            int maxSum = 0;
            int currentSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                else if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            Console.WriteLine(maxSum);
            Console.ReadLine();
        }

        /// <summary>
        /// Sorting an array means to arrange its elements in 
        /// an increasing (or decreasing) order. Write a program, 
        /// which sorts an array using the algorithm "selection sort".
        /// </summary>
        public static void SelectionSort()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int min;
            for (int i = 0; i < n; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                int temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                if (i != n - 1)
                {
                    Console.Write("{0} ", numbers[i]);
                }
                else
                {
                    Console.Write(numbers[i]);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which reads from the console two integer 
        /// numbers N and K (K<N) and array of N integers. Find those 
        /// K consecutive elements in the array, which have maximal sum.
        /// </summary>
        public static void MaxSumOfSequentialElements()
        {
            //input
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string input = Console.ReadLine();
            string[] transformedInput = input.Split(' ');
            for (int i = 0; i < transformedInput.Length; i++)
            {
                arr[i] = int.Parse(transformedInput[i]);
            }

            //get max array
            int currentSum = 0;
            int maxIndex = 0;
            int maxSum = 0;
            int maxArrayElementsCount = 1;
            for (int i = 0; i <= n - k; i++)
            {
                int j = i;
                for (; j < i + k; j++)
                {
                    currentSum += arr[j];
                }

                if (currentSum > maxSum)
                {
                    maxIndex = i;
                    maxSum = currentSum;
                    maxArrayElementsCount = j - i;
                }
                currentSum = 0;
            }

            for (int i = maxIndex; i < maxIndex + maxArrayElementsCount; i++)
            {
                if (i != maxIndex + maxArrayElementsCount - 1)
                {
                    Console.Write(arr[i] + " ");
                }
                else
                {
                    Console.Write(arr[i]);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which finds the maximal sequence of 
        /// increasing elements in an array arr[n]. It is not 
        /// necessary the elements to be consecutively placed. 
        /// E.g.: {9, 6, 2, 7, 4, 7, 6, 5, 8, 4}  {2, 4, 6, 8}.
        /// </summary>
        public static void LongestIncreasingSequenceNotConsecutively()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }

            int[] longestSubsequence = FindLongestSubsequence(arr);
            for (int i = 0; i < longestSubsequence.Length; i++)
            {
                Console.Write(longestSubsequence[i] + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public static int[] FindLongestSubsequence(int[] arr)
        {
            int[] len = new int[arr.Length];
            len[0] = 1;
            for (int x = 1; x < arr.Length; x++)
            {
                int max = 0;
                for (int prev = 0; prev < x; prev++)
                {
                    if (arr[prev] < arr[x])
                    {
                        int current = len[prev];
                        if (current > max)
                        {
                            max = current;
                        }
                    }
                }
                len[x] = 1 + max;
            }

            int maxLength = len.Max();
            int[] longestSubsequence = new int[maxLength];
            int maxLengthIndex = 0;
            for (int i = len.Length - 1; i >= 0; i--)
            {
                if (len[i] == maxLength)
                {
                    longestSubsequence[maxLength - 1] = arr[i];
                    maxLengthIndex = i;
                    break;
                }
            }

            int currentIndex = maxLengthIndex - 1;
            int currentMaxIndex = maxLengthIndex;
            int sequenceIndex = maxLength - 2;
            while (true)
            {
                if (sequenceIndex == -1 || currentIndex == -1)
                {
                    break;
                }
                if (len[currentIndex] == len[currentMaxIndex] - 1)
                {
                    longestSubsequence[sequenceIndex] = arr[currentIndex];
                    sequenceIndex--;
                    currentMaxIndex = currentIndex;
                }
                currentIndex--;
            }

            return longestSubsequence;
        }

        public static int[] ProcessInput()
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        /// <summary>
        /// Write a program, which finds the maximal sequence of 
        /// consecutively placed increasing integers. 
        /// Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
        /// </summary>
        public static void LongestIncreasingSequence()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                counter = 1;
                int j = i + 1;
                int k = i;

                while (arr[k] < arr[j])
                {
                    counter++;
                    j++;
                    k++;
                    if (j >= arr.Length)
                    {
                        break;
                    }
                }
                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    index = i;
                }
            }

            for (int i = index; i <= index + maxSequence - 1; i++)
            {
                if (i != index + maxSequence - 1)
                {
                    Console.Write(arr[i] + ",");
                }
                else
                {
                    Console.WriteLine(arr[i]);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which finds the maximal sequence of 
        /// consecutive equal elements in an array. 
        /// E.g.: {1, 1, 2, 3, 2, 2, 2, 1}  {2, 2, 2}.
        /// </summary>
        public static void MaxSequenceEqualElements()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }
            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                counter = 0;
                int j = i;

                while (arr[i] == arr[j])
                {
                    counter++;
                    j++;
                    if (j >= arr.Length)
                    {
                        break;
                    }
                }

                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    index = i;
                }
            }

            for (int i = index; i <= index + maxSequence - 1; i++)
            {
                if (i != index + maxSequence - 1)
                {
                    Console.Write(arr[i] + ",");
                }
                else
                {
                    Console.WriteLine(arr[i]);
                }
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Write a program, which compares two arrays of type char 
        /// lexicographically (character by character) and checks, 
        /// which one is first in the lexicographical order.
        /// </summary>
        public static void CharLexicographicalComparison()
        {
            string inputArr1 = Console.ReadLine();
            string inputArr2 = Console.ReadLine();

            char[] arr1 = inputArr1.ToCharArray();
            char[] arr2 = inputArr2.ToCharArray();

            int i = 0;
            int j = 0;
            bool equal = false;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] > arr2[j])
                {
                    Console.WriteLine(inputArr2);
                    equal = false;
                    break;
                }
                else if (arr1[i] < arr2[j])
                {
                    Console.WriteLine(inputArr1);
                    equal = false;
                    break;
                }
                else
                {
                    equal = true;
                }

                i++;
                j++;
            }

            if (equal == true)
            {
                if (arr1.Length < arr2.Length)
                {
                    Console.WriteLine(inputArr1);
                }
                else if (arr1.Length > arr2.Length)
                {
                    Console.WriteLine(inputArr2);
                }
                else
                {
                    Console.WriteLine("No difference");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which reads two arrays from the console 
        /// and checks whether they are equal (two arrays are equal 
        /// when they are of equal length and all of their elements, 
        /// which have the same index, are equal).
        /// </summary>
        public static void CompareTwoArrays()
        {
            string inputArrayOne = Console.ReadLine();
            string inputArrayTwo = Console.ReadLine();
            // Transforming the input
            string[] inputOne = inputArrayOne.Split(' ');
            string[] inputTwo = inputArrayTwo.Split(' ');

            int[] arr1 = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr1[i] = int.Parse(inputOne[i]);
            }
            int[] arr2 = new int[inputTwo.Length];
            for (int i = 0; i < inputTwo.Length; i++)
            {
                arr2[i] = int.Parse(inputTwo[i]);
            }

            int counterOfEqualElements = 0;
            if (arr1.Length != arr2.Length)
            {
                Console.WriteLine("False");
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] == arr2[i])
                    {
                        counterOfEqualElements++;
                    }
                }
                if (counterOfEqualElements == arr1.Length)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Write a program, which creates an array of 20 elements of type integer 
        /// and initializes each of the elements with a value equals to the index 
        /// of the element multiplied by 5. Print the elements to the console.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void IndexMultipliedByFive()
        {
            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Element {0} Result {1}", i + 1, array[i]);
            }
            Console.ReadLine();
        } 
        #endregion
    }

 

}
