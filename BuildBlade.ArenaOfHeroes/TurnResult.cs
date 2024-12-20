public class TurnResult
{
    public string Description { get; }
    public int Health { get; }
    public int Mana { get; }
    public string Action { get; }
    public string Target { get; }

    public TurnResult(string description, int health, int mana, string action, string target)
    {
        Description = description;
        Health = health;
        Mana = mana;
        Action = action;
        Target = target;
    }
}
