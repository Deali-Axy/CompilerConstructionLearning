using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace CompilerConstructionLearning.code.exp.exp1 {
    /// 对C或C++等高级程序设计语言编写的源程序中的//注释和/*…*/注释进行删除，保留删除后的源程序。要求以文件形式进行保存。
    public static class Exp1 {
        private const string Replacement = "[!SuperDA!Replacement!]";

        public static void Run()
        {
            Console.Write("请输入待处理的文件路径: ");
            var filePath = Console.ReadLine();
            Console.WriteLine("\n开始处理...");
            Proc(filePath);
        }

        private static void Proc(string filePath)
        {
            var sReader = new StreamReader(filePath);
            var newSource = "";
            var inBlock = false;
            var replaceFlag = false;
            var tempLine = ""; // 用于保存被替换的特殊行代码
            const string quotationPattern = "^(.*?)\".*//.*\"";
            while (!sReader.EndOfStream) {
                var line = sReader.ReadLine();
                if (line.Length == 0) continue; // 去除空行

                var quotationResult = Regex.Match(line, quotationPattern);
                if (quotationResult.Success) {
                    Console.WriteLine("替换特殊代码，双引号中包裹注释斜杠");
                    tempLine = quotationResult.Groups[0].Value;
                    replaceFlag = true;
                    line = Regex.Replace(line, quotationPattern, Replacement);
                }

                // 单行注释
                if (line.Trim().StartsWith(@"//"))
                    continue;
                if (line.Trim().StartsWith(@"/*") && line.EndsWith(@"*/"))
                    continue;

                // 注释块
                if (Regex.Match(line.Trim(), @"^/\*").Success)
                    inBlock = true;
                if (Regex.Match(line.Trim(), @"\*/$").Success) {
                    inBlock = false;
                    continue;
                }

                // 行后注释
                // 使用非贪婪模式(.+?)匹配第一个//
                const string pattern = @"^(.*?)//(.*)";
                // var pattern = @"[^(.*?)//(.*)]|[^(.*?)/\*(.*)\*/]";
                var result = Regex.Match(line, pattern);
                if (result.Success) {
                    Console.WriteLine("发现行后注释：{0}", result.Groups[2]);
                    line = result.Groups[1].Value;
                }

                // 还原被替换的代码
                if (replaceFlag) {
                    Console.WriteLine("还原特殊代码");
                    line = line.Replace(Replacement, tempLine);
                    replaceFlag = false;
                }

                if (inBlock) continue;
                newSource += line + Environment.NewLine;
            }

            const string outputPath = "output/exp1.src";
            Console.WriteLine("去除注释完成，创建新文件。");
            using (var sWriter = new StreamWriter(outputPath)) {
                sWriter.Write(newSource);
            }

            Console.WriteLine("操作完成！文件路径：{0}", outputPath);
        }
    }
}