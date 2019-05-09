using System;
using System.Text.RegularExpressions;

namespace CompilerConstructionLearning
{
    class Exp1Test
    {
        public static void TestMain()
        {
            System.Console.WriteLine("Please enter a line code:");
            var line = Console.ReadLine();
            // 行后注释
            // 使用非贪婪模式(.+?)匹配第一个//
            // var pattern = @"^(.+?)//(.+)";
            // var pattern = @"(.+)/\*(.+)\*/";
            // var pattern = @"(?<!:)//(.*)";
            var pattern="^(.*?)\".*//.*\"";
            var result = Regex.Match(line.Trim(), pattern);
            if (result.Success)
            {
                System.Console.WriteLine("match success!");
                System.Console.WriteLine("code: {0}", result.Groups[1].Value);
                System.Console.WriteLine("comment: {0}", result.Groups[2].Value);
            }
            else
                System.Console.WriteLine("failed!");
        }
    }
}