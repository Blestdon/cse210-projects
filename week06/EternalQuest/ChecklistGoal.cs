public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int count = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _count = count;
    }

    public override int RecordEvent()
    {
        if (_count < _target)
        {
            _count++;
            if (_count == _target)
            {
                Console.WriteLine("🎉 You completed a checklist goal! Bonus awarded!");
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    public override string Display()
    {
        string status = _count >= _target ? "X" : " ";
        return $"[{status}] {_name} - {_description} (Completed {_count}/{_target})";
    }

    public override string SaveData()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_count}";
    }
}
