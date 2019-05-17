// #define TEST_MODE

#define NORMAL_MODE

using System;
using CompilerConstructionLearning.code.exp.exp1;
using CompilerConstructionLearning.code.exp.exp2;

namespace CompilerConstructionLearning {
    class Program {
        private const int ExpCount = 2;

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

#if TEST_MODE
            Exp1Test.TestMain();
#endif

#if NORMAL_MODE
            while (true) {
                Console.Write("请选择实验编号(1-{0}):", ExpCount);
                var expId = Console.ReadLine();
                Console.WriteLine("输入 exit 退出");
                switch (expId) {
                    case "1":
                        Exp1.Run();
                        break;
                    case "2":
                        Exp2.Run();
                        break;
                    case "exit":
                        Console.WriteLine("学业繁忙，告辞～");
                        return;
                    default:
                        Console.WriteLine("输入错误，没有这个实验！");
                        break;
                }
            }
#endif
        }
    }
}