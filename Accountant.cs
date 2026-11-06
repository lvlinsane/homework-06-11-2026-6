class Accountant : Employee
{
    public int Experience { get; set; }
    public string Qualification { get; set; }

    public Accountant(int id, string name, int age, double baseSalary,
                      int experience, string qualification)
        : base(id, name, age, baseSalary)
    {
        Experience = experience;
        Qualification = qualification;
    }

    public double GetAllowance()
    {
        double percent = Experience * 2;

        if (percent > 20)
        {
            percent = 20;
        }

        return BaseSalary * percent / 100;
    }

    public override double CalculateSalary()
    {
        return BaseSalary + GetAllowance();
    }

    public override string GetPosition()
    {
        return "Accountant";
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Стаж работы: " + Experience + " лет");
        Console.WriteLine("Квалификация: " + Qualification);
        Console.WriteLine("Надбавка за стаж: " + FormatMoney(GetAllowance()));
        Console.WriteLine("Итоговая зарплата: " + FormatMoney(CalculateSalary()));
    }
}
