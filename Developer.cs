class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }
    public int CompletedProjects { get; set; }

    public Developer(int id, string name, int age, double baseSalary,
                     string programmingLanguage, int completedProjects)
        : base(id, name, age, baseSalary)
    {
        ProgrammingLanguage = programmingLanguage;
        CompletedProjects = completedProjects;
    }

    public double GetBonus()
    {
        double percent = CompletedProjects * 5;

        if (percent > 30)
        {
            percent = 30;
        }

        return BaseSalary * percent / 100;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + GetBonus();
    }

    public override string GetPosition()
    {
        return "Developer";
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Язык программирования: " + ProgrammingLanguage);
        Console.WriteLine("Завершённых проектов: " + CompletedProjects);
        Console.WriteLine("Бонус: " + FormatMoney(GetBonus()));
        Console.WriteLine("Итоговая зарплата: " + FormatMoney(CalculateSalary()));
    }
}
