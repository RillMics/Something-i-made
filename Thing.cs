using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

class Program
{
    class vec2
    {
        public int x;
        public int y;
        public vec2 range(vec2 first, vec2 second)
        {
            return first - second;
        }
        public static vec2 operator +(vec2 first, vec2 second)
        {
            return new vec2(first.x + second.x, first.y + second.y);
        }
        public static vec2 operator -(vec2 first, vec2 second)
        {
            return new vec2(first.x - second.x, first.y - second.y);
        }
        public static vec2 operator *(vec2 first, vec2 second)
        {
            return new vec2(first.x * second.x, first.y * second.y);
        }
        public static vec2 operator /(vec2 first, vec2 second)
        {
            return new vec2(first.x / second.x, first.y / second.y);
        }
        public static vec2 operator ^(vec2 first, vec2 second)
        {
            return new vec2(first.x ^ second.x, first.y ^ second.y);
        }
        public vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }



    class screen
    {
        public static int height = 30;
        public static int width = 120;
        public static char[] ChScreen = new char[width * height + 1];

        public static int CalcCoord(int x, int y)
        {
            return (x * width) + y;
        }
        public static void CalcPix(int x, int y)
        {
            ChScreen[CalcCoord(x, y)] = '#';
        }
        public static void CalcPix(int x, int y, char symbol)
        {
            ChScreen[CalcCoord(x, y)] = symbol;
        }
        public static void CalcPix(vec2 coord)
        {
            ChScreen[CalcCoord(coord.x, coord.y)] = '#';
        }
        public static void CalcPix(vec2 coord, char symbol)
        {
            ChScreen[CalcCoord(coord.x, coord.y)] = symbol;
        }
        public static void Clear()
        {
            for (int i = 0; i <= width * height; i++)
            {
                ChScreen[i] = '\0';
            }
        }
        public static void ClearHalfUp()
        {
            for (int i = 0; i <= (width * height) / 2; i++)
            {
                ChScreen[i] = '\0';
            }
        }
        public static void ClearHalfDown()
        {
            for (int i = 0; i <= (width * height); i++)
            {
                if (i >= (width * height) / 2)
                {
                    ChScreen[i] = ChScreen[i];
                }
                else { if (i <= (width * height) / 2) { ChScreen[i] = '\0'; } }
            }
        }
        public static void CalcSqu(int x, int y, int size)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + x) / 2, j + y);
                }
            }
        }
        public void CalcSqu(int x, int y, int size, char symbol)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + x) / 2, j + y, symbol);
                }
            }
        }
        public void CalcSqu(vec2 coord, int size, char symbol)
        {
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    CalcPix((i + coord.x) / 2, j + coord.y, symbol);
                }
            }
        }
        public void CalcSqu(vec2 coord, vec2 size, char symbol)
        {
            for (int i = 0; i <= size.y - 1; i++)
            {
                for (int j = 0; j <= size.x - 1; j++)
                {
                    CalcPix((i + coord.x), j + coord.y, symbol);
                }
            }
        }
        public void Square(vec2 coord, int size, char symbol)
        {
            CalcSqu(coord, size, symbol);
        }
        public void Square(vec2 coord, vec2 size, char symbol)
        {
            CalcSqu(coord, size, symbol);
        }
        public void pixel(int x, int y)
        {
            CalcPix(x, y);
        }
        public void pixel(vec2 coord)
        {
            CalcPix(coord.x, coord.y);
        }
        public void pixel(int x, int y, char symbol)
        {
            CalcPix(x, y, symbol);
        }
        public void pixel(vec2 coord, char symbol)
        {
            CalcPix(coord.x, coord.y, symbol);
        }
        public char[] GetScreen()
        {
            return ChScreen;
        }
        public void setWindow(vec2 size)
        {
            width = size.x;
            height = size.y;
            Array.Resize(ref ChScreen, width * height);
            Console.SetWindowSize(size.x, size.y);
        }
        public void clr()
        {
            Clear();
        }
        public void Update()
        {
            Console.WriteLine(ChScreen);
        }
    }
    class Language
    {
        
        public static void Warning(int code, int warnString)
        {
            string[] WarnCode = { "There is no file you want to use" };
            Console.WriteLine(WarnCode[code] + " " + (warnString + 1));
        }
        public static void Warning(int code)
        {
            string[] WarnCode = { "There is no file you want to use" };
            Console.WriteLine(WarnCode[code]);
        }
        public static void MicroLang()
        {
            string fileName = Console.ReadLine();
            string filePath = @"C:\Kirill DOS\" + fileName;
            string[] code = File.ReadAllLines(filePath);
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i].Substring(0,2))
                {
                    case "prt":
                        Console.WriteLine(code[i].Substring(4));
                        break;
                }
            }
        }
        public static int Parse(string inner)
        {
            return Int32.Parse(inner);
        }
        
        public static void ReadAndCompile(string trgtFile)
        {
            string fileName = trgtFile;
            string filePath = @"C:\DOS\" + fileName;
            string[] code = File.ReadAllLines(filePath);
            List<string> StrVarslist = new List<string>();
            List<int> IntVarList = new List<int>();
            List<int> Procedures = new List<int>();
            List<string> procNames = new List<string>();
            screen main = new screen();
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case "ReadCode":
                        ReadAndCompile(code[i+1]);
                        break;
                    case "ReadStrVar":
                        StrVarslist.Add(Console.ReadLine());
                        break;
                    case "ReadIntVar":
                        IntVarList.Add(Int32.Parse(Console.ReadLine()));
                        break;
                    case "clr":
                        main.clr();
                        break;
                    case "updScr":
                        main.Update();
                        break;
                    case "pixel":
                        main.pixel(new vec2(Parse(code[i + 1]), Parse(code[i + 2])));
                        break;
                    case "updif":
                        if (Int32.Parse(code[i + 1]) != Int32.Parse(code[i + 2]))
                        {
                            i = Int32.Parse(code[i + 4]);
                        }
                        break;
                    case "init":

                        break;
                    case "startProc":
                        int buff = i;
                        if (code[i] == "endProc")
                        {
                            i = buff;
                        }
                        else
                        {
                            i = Procedures[Int32.Parse(code[i + 1])];
                        }
                        break;
                    case "goto":
                        i = Int32.Parse(code[i + 1]);
                        break;
                    case "if":
                        if (code[i + 1] != code[i + 2])
                        {
                            i = code[i + 4].IndexOf(code[i + 4]);
                        }
                        else
                        {
                            i = Int32.Parse(code[i + 3]);
                        }
                        break;
                    case "varif":
                        if (IntVarList[i + 1] != IntVarList[i + 2])
                        {
                            i = code[i + 4].IndexOf(code[i + 4]);
                        }
                        else
                        {
                            i = Int32.Parse(code[i + 3]);
                        }
                        break;
                    case "plus":
                        IntVarList[Int32.Parse(code[i + 1])] += IntVarList[Int32.Parse(code[i + 2])];
                        break;
                    case "minus":
                        IntVarList[Int32.Parse(code[i + 1])] -= IntVarList[Int32.Parse(code[i + 2])];
                        break;
                    case "clearvar":
                        string trgvar = code[i + 1];
                        int tar;
                        Int32.TryParse(trgvar, out tar);
                        StrVarslist[tar] = "";
                        break;
                    case "end":
                        i = code.Length;
                        break;
                    case "qrun":
                        RunFile();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "int":
                        string stinp = code[i + 1];
                        int cont;
                        Int32.TryParse(stinp, out cont);
                        IntVarList.Add(cont);
                        break;
                    case "var":
                        string variable = code[i + 1];
                        StrVarslist.Add(variable);
                        break;
                    case "printVar":
                        string target = code[i + 1];
                        int str;
                        Int32.TryParse(target, out str);
                        Console.WriteLine(StrVarslist[str]);
                        break;
                    case "run_with_message":
                        string file = code[i + 1];
                        if (File.Exists(file))
                        {
                            Process.Start(file);
                            Console.WriteLine("Файл " + file + " запушен.");
                        }
                        else
                        {
                            Warning(0, code[i].IndexOf(code[i]));
                        }
                        break;
                    case "run":
                        string fileN = code[i + 1];
                        if (File.Exists(fileN))
                        {
                            Process.Start(fileN);
                        }
                        else
                        {
                            Warning(0, code[i].IndexOf(code[i]));
                        }
                        break;
                    case "read":
                        Console.ReadLine();
                        break;
                    case "print":
                        Console.WriteLine(code[i + 1]);
                        break;
                    case "readPrint":
                        Console.WriteLine(Console.ReadLine());
                        break;
                }
            }
        }
        public static void ReadAndCompile()
        {
            string fileName = Console.ReadLine();
            string filePath = @"C:\DOS\" + fileName;
            string[] code = File.ReadAllLines(filePath);
            List<string> StrVarslist = new List<string>();
            List<int> IntVarList = new List<int>();
            List<int> Procedures = new List<int>();
            List<string> procNames = new List<string>();
            screen main = new screen();
            for (int i = 0; i < code.Length; i++)
            {
                switch(code[i]){
                    case "ReadCode":
                        ReadAndCompile(code[i + 1]);
                        break;
                    case "ReadStrVar":
                        StrVarslist.Add(Console.ReadLine());
                        break;
                    case "ReadIntVar":
                        IntVarList.Add(Int32.Parse(Console.ReadLine()));
                        break;
                    case "clr":
                        main.clr();
                        break;
                    case "updScr":
                        main.Update();
                        break;
                    case "pixel":
                        main.pixel(new vec2(Parse(code[i+1]), Parse(code[i + 2])));
                        break;
                    case "updif":
                        if (Int32.Parse(code[i+1]) != Int32.Parse(code[i+2]))
                        {
                            i = Int32.Parse(code[i+4]);
                        }
                        break;
                    case "init":

                        break;
                    case "startProc":
                        int buff = i;
                        if(code[i] == "endProc")
                        {
                            i = buff;
                        }
                        else
                        {
                            i = Procedures[Int32.Parse(code[i + 1])];
                        }
                        break;
                    case "goto":
                        i = Int32.Parse(code[i+1]);
                        break;
                    case "if":
                        if (code[i+1] != code[i+2])
                        {
                            i = code[i+4].IndexOf(code[i+4]);
                        }
                        else
                        {
                            i = Int32.Parse(code[i + 3]);
                        }
                        break;
                    case "varif":
                        if (IntVarList[i + 1] != IntVarList[i+2])
                        {
                            i = code[i + 4].IndexOf(code[i + 4]);
                        }
                        else
                        {
                            i = Int32.Parse(code[i + 3]);
                        }
                        break;
                    case "plus":
                        IntVarList[Int32.Parse(code[i + 1])] += IntVarList[Int32.Parse(code[i+2])];
                        break;
                    case "minus":
                        IntVarList[Int32.Parse(code[i + 1])] -= IntVarList[Int32.Parse(code[i + 2])];
                        break;
                    case "clearvar":
                        string trgvar = code[i + 1];
                        int tar;
                        Int32.TryParse(trgvar, out tar);
                        StrVarslist[tar] = "";
                        break;
                    case "end":
                        i = code.Length;
                        break;
                    case "qrun":
                        RunFile();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "int":
                        string stinp = code[i + 1];
                        int cont;
                        Int32.TryParse(stinp, out cont);
                        IntVarList.Add(cont);
                        break;
                    case "var":
                        string variable = code[i + 1];
                        StrVarslist.Add(variable);
                        break;
                    case "printVar":
                        string target = code[i + 1];
                        int str;
                        Int32.TryParse(target, out str);
                        Console.WriteLine(StrVarslist[str]);
                        break;
                    case "run_with_message":
                        string file = code[i + 1];
                        if (File.Exists(file))
                        {
                            Process.Start(file);
                            Console.WriteLine("Файл " + file + " запушен.");
                        }
                        else
                        {
                            Warning(0, code[i].IndexOf(code[i]));
                        }
                        break;
                    case "run":
                        string fileN = code[i + 1];
                        if (File.Exists(fileN))
                        {
                            Process.Start(fileN);
                        }
                        else
                        {
                            Warning(0, code[i].IndexOf(code[i]));
                        }
                        break;
                    case "read":
                        Console.ReadLine();
                        break;
                    case "print":
                        Console.WriteLine(code[i + 1]);
                        break;
                    case "readPrint":
                        Console.WriteLine(Console.ReadLine());
                        break;
                }
            }
        }
    }
    static void Main(string[] args)
    {
        string directory = @"C:\DOS\";
        Directory.CreateDirectory(directory);
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. create file");
            Console.WriteLine("run - run exe file");
            Console.WriteLine("dir - create directory");
            Console.WriteLine("del - delete file");
            Console.WriteLine("2. edit file");
            Console.WriteLine("3. open file");
            Console.WriteLine("4. not work");
            Console.WriteLine("5. time");
            Console.WriteLine("6. not work");
            Console.WriteLine("clear - clear console");
            Console.WriteLine("delDir - delet directory");
            Console.WriteLine("7. close programm");
            Console.WriteLine("runSource");
            Console.WriteLine("info");

            string input = Console.ReadLine();

            switch (input)
            {
                case "info":
                    string[] dr = Directory.GetFiles(directory + Console.ReadLine());
                    for (int i = 0; i < dr.Length; i++)
                    {
                        Console.WriteLine(dr[i]);
                    }
                    break;
                case "1":
                    CreateFile();
                    break;
                case "run":
                    RunFile();
                    break;
                case "del":
                    DeleteFile();
                    break;
                case "delDir":
                    DelDir();
                    break;
                case "dir":
                    NewDir();
                    break;
                case "2":
                    EditFile();
                    break;
                case "3":
                    OpenFile();
                    break;
                case "4":
                    OpenCalculator();
                    break;
                case "5":
                    ShowCurrentTime();
                    break;
                case "6":
                    OpenMessenger();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "7":
                    isRunning = false;
                    break;
                case "runSource":
                    Language.ReadAndCompile();
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }

            Console.WriteLine();
        }
    }
    static void RunFile()
    {
        Console.WriteLine("Write filename:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;
        if (File.Exists(filePath))
        {
            Process.Start(filePath);
            Console.WriteLine("file " + fileName + " runned.");
        }
        else
        {
            Console.WriteLine("There is no file you want to use");
        }

    }
    static void DelDir()
    {
        Console.WriteLine("Write direcory name:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;
        Directory.Delete(filePath);
        Console.WriteLine("directory deleted");
    }
    static void NewDir()
    {
        Console.WriteLine("Write name of new derectory:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;
        Directory.CreateDirectory(filePath);
        Console.WriteLine("directory has created");
    }
    static void DeleteFile()
    {
        Console.WriteLine("Write filename:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("File has deleted");
        }
        else
        {
            Console.WriteLine("There is no file you want to use");
        }

    }

    static void CreateFile()
    {
        Console.WriteLine("Write filename:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;

        File.Create(filePath).Close();

        Console.WriteLine("File has created.");
    }

    static void EditFile()
    {
        Console.WriteLine("Write filename:");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;

        if (File.Exists(filePath))
        {
            Console.WriteLine("Write text (Ctrl + Z to complete):");

            List<string> lines = new List<string>();

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("File has created");
        }
        else
        {
            Console.WriteLine("File not exists");
        }
    }

    static void OpenFile()
    {
        Console.WriteLine("Write filename");
        string fileName = Console.ReadLine();
        string filePath = @"C:\DOS\" + fileName;

        if (File.Exists(filePath))
        {
            Console.WriteLine("Content");

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("File not exists");
        }
    }

    static void OpenCalculator()
    {
    }

    static void ShowCurrentTime()
    {
        Console.WriteLine("Time: " + DateTime.Now.ToString("HH:mm:ss"));
    }

    static void OpenMessenger()
    {
    }
}
