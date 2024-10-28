using System;

namespace SampleConsole;

public class MyClass
{
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public int Age => (int)((DateTime.Today - BirthDate).TotalDays / 365.25);
}
