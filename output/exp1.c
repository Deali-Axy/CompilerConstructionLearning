#include <iostream>
#include <fstream>
#include <iomanip>
#include <cstdlib>
using namespace std;
int main()
{
    cout << '/';
    ifstream ifile; 
    ofstream ofile;
    ifile.open("f:\\上机实验题\\C++\\ConsoleApplication2\\ConsoleApplication2\\源.cpp"); 
    ofile.open("f:\\上机实验题\\C++\\ConsoleApplication2\\ConsoleApplication2\\源.obj");
    if (ifile.fail() || ofile.fail())
    { 
        cerr << "open file fail\n";
        return EXIT_FAILURE;
    }
    char ch;
    ch = ifile.get(); 
    while (!ifile.eof())
    {
        if (ch == 34)
        {                   
            char temp = ch; 
            ofile.put(ch);
            ch = ifile.get();
            while (!ifile.eof())
            {
                if (ch != temp)
                { 
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
            continue; 
        }
        if (ch == 47)
        { 
            char temp2 = ch;
            ch = ifile.get();
            if (ch == 47)
            { 
                ch = ifile.get();
                while (!(ch == '\n'))
                    ch = ifile.get();
            }
            else if (ch == '*')
            { 
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
                ofile.put(temp2); 
            }
        }
        ofile.put(ch);    
        ch = ifile.get(); 
    }
    ifile.close(); 
    ofile.close();
    cout << "/////*////ret/rtr////";
    system("pause");
    return 0;
}
