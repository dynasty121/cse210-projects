using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime GetDate() => _date;
    public int GetLengthInMinutes() => _lengthInMinutes;

    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min per mile

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}

class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}

class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0 * 0.62; // convert to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 3), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
