using System;

namespace ValidationEngineTests.TestSupport;

public class TestSampleClass
{
    public string Name { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public int Age => (int)((DateTime.Today - BirthDate).TotalDays / 365.25);
}
