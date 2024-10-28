using System;

namespace DevDad.RulesUtility.Tests.TestData;

public class SampleSubject
{
    public static SampleSubject CreateSample()
        {
            return new SampleSubject
            {
                BoolProperty = false,
                DoubleProperty = 3.14159,
                FloatProperty = 2.71828f,
                LongProperty = 1234567890,
                ShortProperty = 32767,
                ByteProperty = 255,
                CharProperty = 'Z',
                StringProperty = "Hello, World!",
                IntProperty = 42,
                DecimalProperty = 12345.6789m,
                DateTimeProperty = new DateTime(2023, 10, 1)
            };
        }

        public bool BoolProperty { get; set; }
        public double DoubleProperty { get; set; }
        public float FloatProperty { get; set; }
        public long LongProperty { get; set; }
        public short ShortProperty { get; set; }
        public byte ByteProperty { get; set; }
        public char CharProperty { get; set; }
        public string? StringProperty { get; set; } = string.Empty;
        public int IntProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
}
