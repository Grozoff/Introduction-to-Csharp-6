using System;
using System.Diagnostics;

namespace Task_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            while (!endApp)
            {
                Console.Write("Меню:\n1 Список запущенных процессов\n2 Завершить процесс по его ID\n3 Завершить процесс по его имени\nВаш ответ: ");

                ConsoleKey usersKey = Console.ReadKey().Key;

                switch (usersKey)
                {
                    case ConsoleKey.D3:
                        Console.Write("\nПо имени так по имени, вводи имя процесса если ты его знаешь и нажми Enter: ");
                        string processName = Console.ReadLine();
                        try
                        {
                            foreach (Process process in Process.GetProcessesByName(processName))
                            {
                                process.Kill();
                            }
                        }
                        catch
                        {
                            Console.Write("\nЧто-то пошло не так:(");
                        }
                        break;

                    case ConsoleKey.D2:
                        Console.Write("\nВведи ID процесса если ты его знаешь и нажми Enter: ");
                        int processID = int.Parse(Console.ReadLine());
                        try
                        {
                            Process procId = Process.GetProcessById(processID);
                            procId.Kill();
                        }
                        catch
                        {
                            Console.Write("\nЧто-то пошло не так:(");
                        }
                        break;

                    case ConsoleKey.D1:
                        Console.WriteLine("\nЗапущенные процессы в данный момент:");
                        Console.WriteLine("{0,-40}  {1,-10}  {2,-10}", "Имя", "ID", "RAM (bytes)");
                        Console.WriteLine("====================================================================");
                        foreach (Process process in Process.GetProcesses())
                            Console.WriteLine("{0,-40} {1,-10} {2,-10}", process.ProcessName, process.Id, process.WorkingSet64);
                        break;
                }
                Console.Write("\nНажмите Enter что бы показать меню, или нажмите 'q' и Enter для закрытия приложения: ");
                if (Console.ReadLine() == "q") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
