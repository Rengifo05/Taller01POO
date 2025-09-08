namespace POO.Concepts.Core;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time() : this(0, 0, 0, 0) { }
    public Time(int hour) : this(hour, 0, 0, 0) { }
    public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour
    {
        get => _hour;
        set => _hour = ValidHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }

    public override string ToString()
    {
        int displayHour = Hour % 12;
        if (displayHour == 0) displayHour = 12;
        string period = Hour >= 12 ? "PM" : "AM";
        return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

    public long ToMilliseconds() => (Hour * 3600000L) + (Minute * 60000L) + (Second * 1000L) + Millisecond;
    public long ToSeconds() => ToMilliseconds() / 1000;
    public long ToMinutes() => ToMilliseconds() / 60000;

    public bool IsOtherDay(Time other)
    {
        return (this.ToMilliseconds() + other.ToMilliseconds()) >= 24 * 3600000L;
    }

    public Time Add(Time other)
    {
        int h = this.Hour + other.Hour;
        int m = this.Minute + other.Minute;
        int s = this.Second + other.Second;
        int ms = this.Millisecond + other.Millisecond;

        if (ms > 999)
        {
            s += ms / 1000;
            ms %= 1000;
        }
        if (s > 59)
        {
            m += s / 60;
            s %= 60;
        }
        if (m > 59)
        {
            h += m / 60;
            m %= 60;
        }
        h %= 24;

        return new Time(h, m, s, ms);
    }

    private int ValidHour(int value)
    {
        if (value < 0 || value > 23) throw new Exception($"The hour: {value}, is not valid.");
        return value;
    }

    private int ValidMinute(int value)
    {
        if (value < 0 || value > 59) throw new Exception($"The minute: {value}, is not valid.");
        return value;
    }

    private int ValidSecond(int value)
    {
        if (value < 0 || value > 59) throw new Exception($"The second: {value}, is not valid.");
        return value;
    }

    private int ValidMillisecond(int value)
    {
        if (value < 0 || value > 999) throw new Exception($"The millisecond: {value}, is not valid.");
        return value;
    }
}
