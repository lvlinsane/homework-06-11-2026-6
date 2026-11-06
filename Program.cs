class Program
{
    static EmployeeManager manager = new EmployeeManager();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        manager.FillTestData();

        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    manager.ShowAll();
                    break;
                case "3":
                    FindEmployee();
                    break;
                case "4":
                    CalculateSalary();
                    break;
                case "5":
                    ShowByPosition();
                    break;
                case "6":
                    manager.ShowMaxSalary();
                    break;
                case "7":
                    manager.ShowPayroll();
                    break;
                case "8":
                    manager.ShowStatistics();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Выход из программы");
                    break;
                default:
                    Console.WriteLine("Неверный пункт меню, попробуйте ещё раз");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Система управления сотрудниками");
        Console.WriteLine("1. Добавить сотрудника");
        Console.WriteLine("2. Просмотреть список сотрудников");
        Console.WriteLine("3. Найти сотрудника по ID");
        Console.WriteLine("4. Рассчитать заработную плату");
        Console.WriteLine("5. Просмотреть сотрудников по должности");
        Console.WriteLine("6. Найти сотрудника с максимальной зарплатой");
        Console.WriteLine("7. Рассчитать фонд оплаты труда");
        Console.WriteLine("8. Статистика сотрудников");
        Console.WriteLine("0. Выход");
        Console.Write("Выберите действие: ");
    }

    static void AddEmployee()
    {
        Console.WriteLine("Кого добавить?");
        Console.WriteLine("1. Developer");
        Console.WriteLine("2. Manager");
        Console.WriteLine("3. Accountant");
        int type = ReadInt("Выберите должность: ", 1, 3);

        string name = ReadString("Введите ФИО: ");
        int age = ReadInt("Введите возраст: ", 16, 100);
        double salary = ReadDouble("Введите базовую зарплату (KZT): ");
        int id = manager.GetNextId();

        if (type == 1)
        {
            string language = ReadString("Введите язык программирования: ");
            int projects = ReadInt("Введите количество завершённых проектов: ", 0, 1000);
            manager.Add(new Developer(id, name, age, salary, language, projects));
        }
        else if (type == 2)
        {
            int teamSize = ReadInt("Введите количество подчинённых: ", 0, 1000);
            double bonus = ReadDouble("Введите премию (KZT): ");
            manager.Add(new Manager(id, name, age, salary, teamSize, bonus));
        }
        else
        {
            int experience = ReadInt("Введите стаж работы (лет): ", 0, 60);
            string qualification = ReadString("Введите уровень квалификации: ");
            manager.Add(new Accountant(id, name, age, salary, experience, qualification));
        }

        Console.WriteLine("Сотрудник добавлен, его ID: " + id);
    }

    static void FindEmployee()
    {
        int id = ReadInt("Введите ID сотрудника: ", 1, int.MaxValue);
        manager.ShowEmployee(id);
    }

    static void CalculateSalary()
    {
        int id = ReadInt("Введите ID сотрудника: ", 1, int.MaxValue);
        manager.ShowEmployee(id);
    }

    static void ShowByPosition()
    {
        Console.WriteLine("1. Developer");
        Console.WriteLine("2. Manager");
        Console.WriteLine("3. Accountant");
        int type = ReadInt("Выберите должность: ", 1, 3);
        Console.WriteLine();
        manager.ShowByPosition(type);
    }

    static int ReadInt(string text, int min, int max)
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number) && number >= min && number <= max)
            {
                return number;
            }

            Console.WriteLine("Ошибка: введите целое число от " + min + " до " + max);
        }
    }

    static double ReadDouble(string text)
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine();
            double number;

            if (double.TryParse(input, out number) && number >= 0)
            {
                return number;
            }

            Console.WriteLine("Ошибка: введите неотрицательное число");
        }
    }

    static string ReadString(string text)
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine();

            if (input != null && input.Trim() != "")
            {
                return input.Trim();
            }

            Console.WriteLine("Ошибка: строка не должна быть пустой");
        }
    }
}
