using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace CompilerConstructionLearning
{
    /// 对C或C++等高级程序设计语言编写的源程序中的//注释和/*…*/注释进行删除，保留删除后的源程序。要求以文件形式进行保存。
    public class Exp1
    {
        public static void Run()
        {
            System.Console.Write("请输入待处理的文件路径");
            var filePath = Console.ReadLine();
            System.Console.WriteLine("\n开始处理...");
            Proc(filePath);
        }

        public static void Proc(String filePath)
        {
            var sReader = new StreamReader(filePath);
            var newSource = "";
            var inBlock = false;
            while (!sReader.EndOfStream)
            {
                var line = sReader.ReadLine();

                // 单行注释
                if (line.StartsWith(@"//"))
                    continue;
                if (line.StartsWith(@"/*") && line.EndsWith(@"*/"))
                    continue;

                // 注释块
                if (line.Trim().StartsWith(@"/*"))
                    inBlock = true;
                if (line.Trim().Contains(@"*/"))
                    inBlock = false;

                // 行后注释
                var pattern = @".+//.+";
                if (Regex.Match(line, pattern).Success)
                    continue;

                if (inBlock) continue;
                newSource += line + Environment.NewLine;
            }
        }
    }
}