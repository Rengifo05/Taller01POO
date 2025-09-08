using POO.Concepts.Core;

void PrintTime(Time time, Time t3, Time t4)
{
    Console.WriteLine($"Time: {time}");
    Console.WriteLine($"Milliseconds : {time.ToMilliseconds():N0}");
    Console.WriteLine($"Seconds     : {time.ToSeconds():N0}");
    Console.WriteLine($"Minutes     : {time.ToMinutes():N0}");
    Console.WriteLine($"Add         : {time.Add(t3)}");
    Console.WriteLine($"Is Other day: {time.IsOtherDay(t4)}");
    Console.WriteLine();
}

Time t1 = new Time();
Time t2 = new Time(2);
Time t3 = new Time(9, 34);
Time t4 = new Time(7, 8);
Time t5 = new Time(11, 3, 45, 678);

PrintTime(t1, t3, t4);
PrintTime(t2, t3, t4);
PrintTime(t3, t3, t4);
PrintTime(t4, t3, t4);
PrintTime(t5, t3, t4);

try
{
    Time invalid = new Time(45, 30, 0);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
