using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Task 1
            string text = "Дано текст (взяти любий з інтернету). Визначити 3 символи, що найчастіше зустрічаються в ньому. Пробіли слід ігнорувати (не враховувати при підрахунку). Для результатів обчислень потрібно написати функцію.";
            //CounterSumbolInString(text);

            //Task 2
            //string text = "Дано текст взяти любий з інтернету";

            //foreach (char word in CaseChange(text))
            //{
            //    Console.Write(word);
            //}
            //Task 3
            //string text = "Дано текст (взяти любий з інтернету). (Створити) функцію (яка) буде повертати текст з вирізаними поясненнями в скобках (як цей наприклад). Кількість текстів в скобках може бути довільний (в умові задачі їх три).";

            //Console.WriteLine(CutClarification(text));

            //Task 4
            //string one = "Привет мир";
            //string two = "Прим";
            //Console.WriteLine(F(one, two));


            Console.ReadLine();
        }
        /// <summary>
        /// Метод расчитывает и выводит количество символово в стоке. Ничего не возвращает
        /// </summary>
        /// <param name="text"></param>
        static void CounterSumbolInString(string text)
        {
            string newMyStr = text.Replace(" ", "");
            int temp = 0;
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            foreach (var item in newMyStr)
            {
                if (!keyValuePairs.ContainsKey(item))
                    keyValuePairs.Add(item, 1);
                else keyValuePairs[item]++;
            }
            var sortedDict = keyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //Как вывести первые 3 элемента не зная ключи так и не разобрался
            foreach (var kvp in sortedDict.Reverse())
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
        }
        /// <summary>
        /// Меняет первую букву слова в строке по очереди
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string CaseChange(string text)
        {
            string[] words = text.Split();
            string newWord = char.ToLower(words[0][0]) + words[0].Substring(1, words[0].Length - 1) + " ";
            for (int i = 1; i < words.Length; i++)
            {
                if (i % 2 == 1)
                {
                    newWord += char.ToUpper(words[i][0]) + words[i].Substring(1, words[i].Length - 1) + " ";
                }
                else
                {
                    newWord += char.ToLower(words[i][0]) + words[i].Substring(1, words[i].Length - 1) + " ";
                }
            }
            return newWord;
        }
        /// <summary>
        /// Вырезаем подстроку в скобках
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Строку со скобок</returns>
        static string CutClarification(string text)
        {
            string resultString = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    int a = text.IndexOf("(", i);
                    int b = text.IndexOf(")", a) - i + 1;
                    resultString += text.Substring(a, b);

                }

            }
            return resultString;
        }
        /// <summary>
        /// Метод проверяет, можем ли с символов одной строки составить другую строку
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns>true, false</returns>
        static bool F(string one, string two)
        {
            string temp = one.Replace(" ", "");
            char[] mas = new char[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                mas[i] = temp[i];
            }
            HashSet<char> hs = new HashSet<char>();
            foreach (var item in mas)
                hs.Add(item);
            string t = "";
            foreach (var item in hs)
            {
                t += item;
            }
            Console.WriteLine(t);
            char[] resMas = new char[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                resMas[i] = t[i];
            }
            bool result = false;
            string tempResult = string.Empty;
            for (int i = 0; i < two.Length; i++)
            {
                for (int j = 0; j < resMas.Length; j++)
                {
                    if (two[i] == resMas[j])
                        tempResult += two[i];
                    if (tempResult.Length == two.Length) 
                        result = true;
                }
            }
            return result;
        }
    }
}
