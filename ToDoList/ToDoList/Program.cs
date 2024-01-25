// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


DateTime d1 = new DateTime(638418256350515030); // today
DateTime d2 = new DateTime(638417392912518866); // yesterday

Console.WriteLine(d1);
Console.WriteLine(d2);
Console.WriteLine(d1.CompareTo(d2));
