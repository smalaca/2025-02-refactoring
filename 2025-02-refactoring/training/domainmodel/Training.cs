namespace _2025_02_refactoring.training;

public class Training
{
    private readonly string _name;
    private readonly int _trainerId;
    private readonly DateTime _dateTime;
    private readonly Description _description;

    public Training(string name, int trainerId)
    {
        _name = name;
        _trainerId = trainerId;
    }

    public void Schedule(DateTime dateTime)
    {
        // if dateTime is in the past, throw exception
        // if dateTime is in the weekend, throw exception
        // if dateTime is available schedule training
    }

    public string asJson()
    {
        return null;
    }
}