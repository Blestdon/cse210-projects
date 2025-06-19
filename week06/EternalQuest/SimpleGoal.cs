public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;
        _isComplete = true;
        return _points;
    }

    public override string Display()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";
    }

    public override string SaveData()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
