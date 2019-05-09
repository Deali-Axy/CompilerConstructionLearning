#include <iostream>
#include <fstream>
#include <iomanip>
#include <cstdlib>
using namespace std;

int main()
{
    cout << '/';
    ifstream ifile; //建立文件流对象
    ofstream ofile;
    ifile.open("f:\\上机实验题\\C++\\ConsoleApplication2\\ConsoleApplication2\\源.cpp"); //打开F盘根目录下的fileIn.txt文件
    ofile.open("f:\\上机实验题\\C++\\ConsoleApplication2\\ConsoleApplication2\\源.obj");
    if (ifile.fail() || ofile.fail())
    { //测试打开操作是否成功
        cerr << "open file fail\n";
        return EXIT_FAILURE;
        /*返回值EXIT_FAILURE（在cstdlib库中定义）,用于向操作系统报*
		告打开文件失败*/
    }
    char ch;
    ch = ifile.get(); //进行读写操作
    while (!ifile.eof())
    {
        if (ch == 34)
        {                   //双引号中若出现“//”，双引号中的字符不消除
            char temp = ch; //第一个双引号
            ofile.put(ch);
            ch = ifile.get();
            while (!ifile.eof())
            {
                if (ch != temp)
                { //寻找下一个双引号
                    ofile.put(ch);
                    ch = ifile.get();
                }
                else
                {
                    ofile.put(ch);
                    break;
                }
            }
            ch = ifile.get();
            continue; //双引号情况结束，重新新一轮判断
        }
        if (ch == 47)
        { //出现第一个斜杠
            char temp2 = ch;
            ch = ifile.get();
            if (ch == 47)
            { //单行注释情况
                ch = ifile.get();
                while (!(ch == '\n'))
                    ch = ifile.get();
            }
            else if (ch == '*')
            { //多行注释情况
                while (1)
                {
                    ch = ifile.get();
                    while (!(ch == '*'))
                        ch = ifile.get();
                    ch = ifile.get();
                    if (ch == 47)
                        break;
                }
                ch = ifile.get();
            }
            else
            {
                ofile.put(temp2); //temp2保存第一个斜杠，当上述两种情况都没有时，将此斜杠输出
            }
            //ch = ifile.get();
        }
        //cout << ch << endl;
        ofile.put(ch);    //将字符写入文件流对象中
        ch = ifile.get(); //从输入文件对象流中读取一个字符
    }
    ifile.close(); //关闭文件
    ofile.close();
    cout << "/////*////ret/rtr////";
    system("pause");
    return 0;
}