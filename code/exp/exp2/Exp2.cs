using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace CompilerConstructionLearning.code.exp.exp2 {
    public class Exp2 {
        private static List<string> spliters = new List<string>() {
//            "/",
//            "\\",
            "=",
            "+", "-", "*"
        };

        public static void Run()
        {
//            Console.Write("请输入待处理的文件路径: ");
//            var filePath = Console.ReadLine();
            Console.WriteLine("\n开始处理...");
//            Proc(filePath);
            Proc("output/exp1.c");
        }

        private static void Proc(string filePath)
        {
            using (var sr = new StreamReader(filePath)) {
                while (!sr.EndOfStream) {
                    var line = sr.ReadLine();
                    // 点也是相当于空格的分隔符
                    line = line?.Replace(".", " ");
                    // 去掉分号
                    line = line?.Replace(";", "");
                    foreach (var spliter in spliters) {
//                        line = line?.Replace(spliter, $" {spliter} ");
                        line = line?.Replace(spliter, $"");
                    }

                    var lineElements = line?.Trim().Split(" ");
                    Console.WriteLine(string.Join(",", lineElements));
                }
            }
        }
    }
}