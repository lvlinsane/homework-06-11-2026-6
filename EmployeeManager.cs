class EmployeeManager
{
    private Employee[] employees = new Employee[0];
    private int nextId = 1;

    public int GetNextId()
    {
        return nextId++;
    }

    public void Add(Employee employee)
    {
        Array.Resize(ref employees, employees.Length + 1);
        employees[employees.Length - 1] = employee;
    }

    public void FillTestData()
    {
        Add(new Developer(GetNextId(), "Иванов Иван", 25, 400000, "C#", 3));
        Add(new Developer(GetNextId(), "Петров Пётр", 28, 350000, "Python", 7));
        Add(new Manager(GetNextId(), "Сидорова Анна", 35, 500000, 10, 100000));
        Add(new Manager(GetNextId(), "Ахметов Ержан", 40, 450000, 5, 50000));
        Add(new Accountant(GetNextId(), "Каримова Алия", 32, 300000, 4, "Высшая"));
        Add(new Accountant(GetNextId(), "Смирнова Ольга", 50, 280000, 15, "Первая"));
    }

    public Employee FindById(int id)
    {
        foreach (Employee e in employees)
        {
            if (e.Id == id)
            {
                return e;
            }
        }
        return null;
    }

    public void ShowAll()
    {
        if (employees.Length == 0)
        {
            Console.WriteLine("Список сотрудников пуст");
            return;
        }

        foreach (Employee e in employees)
        {
            e.DisplayInfo();
            Console.WriteLine("----------------------------");
        }
    }

    public void ShowEmployee(int id)
    {
        Employee e = FindById(id);

        if (e == null)
        {
            Console.WriteLine("Сотрудник с ID " + id + " не найден");
            return;
        }

        e.DisplayInfo();
    }

    public void ShowByPosition(int type)
    {
        int found = 0;

        foreach (Employee e in employees)
        {
            bool match = false;

            if (type == 1 && e is Developer)
            {
                match = true;
            }
            else if (type == 2 && e is Manager)
            {
                match = true;
            }
            else if (type == 3 && e is Accountant)
            {
                match = true;
            }

            if (match)
            {
                e.DisplayInfo();
                Console.WriteLine("----------------------------");
                found++;
            }
        }

        if (found == 0)
        {
            Console.WriteLine("Сотрудники этой должности не найдены");
        }
    }

    public void ShowMaxSalary()
    {
        if (employees.Length == 0)
        {
            Console.WriteLine("Список сотрудников пуст");
            return;
        }

        Employee best = employees[0];

        for (int i = 1; i < employees.Length; i++)
        {
            if (employees[i].CalculateSalary() > best.CalculateSalary())
            {
                best = employees[i];
            }
        }

        Console.WriteLine("Сотрудник с максимальной зарплатой:");
        best.DisplayInfo();
    }

    public void ShowPayroll()
    {
        double total = 0;

        foreach (Employee e in employees)
        {
            total += e.CalculateSalary();
        }

        Console.WriteLine("Фонд оплаты труда: " + Employee.FormatMoney(total));
    }

    public void ShowStatistics()
    {
        if (employees.Length == 0)
        {
            Console.WriteLine("Список сотрудников пуст");
            return;
        }

        int developers = 0;
        int managers = 0;
        int accountants = 0;

        foreach (Employee e in employees)
        {
            if (e is Developer)
            {
                developers++;
            }
            else if (e is Manager)
            {
                managers++;
            }
            else if (e is Accountant)
            {
                accountants++;
            }
        }

        Console.WriteLine("Всего сотрудников: " + employees.Length);
        Console.WriteLine("Разработчиков: " + developers);
        Console.WriteLine("Менеджеров: " + managers);
        Console.WriteLine("Бухгалтеров: " + accountants);
        Console.WriteLine();

        foreach (Employee e in employees)
        {
            if (e is Developer dev)
            {
                Console.WriteLine(dev.Name + " - язык программирования: " + dev.ProgrammingLanguage);
            }
            else if (e is Manager man)
            {
                Console.WriteLine(man.Name + " - подчинённых: " + man.TeamSize);
            }
            else if (e is Accountant acc)
            {
                Console.WriteLine(acc.Name + " - стаж работы: " + acc.Experience + " лет");
            }
        }
    }
}
