class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double BaseSalary { get; set; }

    public Employee(int id, string name, int age, double baseSalary)
    {
        Id = id;
        Name = name;
        Age = age;
        BaseSalary = baseSalary;
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }

    public virtual string GetPosition()
    {
        return "Employee";
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Сотрудник: " + Name);
        Console.WriteLine("Должность: " + GetPosition());
        Console.WriteLine("Возраст: " + Age);
        Console.WriteLine("Базовая зарплата: " + FormatMoney(BaseSalary));
    }

    public static string FormatMoney(double money)
    {
        return money.ToString("N0", System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' ') + " KZT";
    }
}
