public class Ability
{
    public string Name { get; }
    public int Damage { get; }
    public int Cooldown { get; }
    private int _lastUsedTime;

    public Ability(string name, int damage, int cooldown)
    {
        Name = name;
        Damage = damage;
        Cooldown = cooldown;
        _lastUsedTime = -cooldown;
    }

    public bool CanUse(int currentTime)
    {
        return currentTime - _lastUsedTime >= Cooldown;
    }

    public void Use(int currentTime, Character character, int turn, Logger logger)
    {
        character.TakeDamage(Damage);
        _lastUsedTime = currentTime;
    }
}