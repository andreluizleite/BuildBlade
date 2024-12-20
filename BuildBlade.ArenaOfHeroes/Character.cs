public class Character
{
    public string Name { get; }
    public int Health { get; private set; }
    public List<Ability> Abilities { get; }
    public List<Item> Items { get; }
    private int _currentTime;

    public Character(string name, int initialHealth)
    {
        Name = name;
        Health = initialHealth;
        Abilities = new List<Ability>();
        Items = new List<Item>();
        _currentTime = 0;
    }

    public void AddAbility(Ability ability)
    {
        Abilities.Add(ability);
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void Update(int turn, Logger logger)
    {
        _currentTime++;

        foreach (var ability in Abilities.Where(a => a.CanUse(_currentTime)))
        {
            ability.Use(_currentTime, this, turn, logger);
            logger.LogEvent($"Turn {turn}: Ability = {ability.Name}: Damage = {ability.Damage}");
        }

        if (Items.Any())
        {
            foreach (var item in Items)
            {
                if (item.Duration > 0)
                    item.DecreaseDuration();
                else continue;
                
                    if (item.EffectAmount < 0)
                    {
                        TakeDamage(-item.EffectAmount);
                        logger.LogEvent($"Turn {turn}: Ability = {item.Name}: Amount = {item.EffectAmount}");
                    }
                    else
                    {
                        Heal(item.EffectAmount);
                        logger.LogEvent($"Turn {turn}: Ability = {item.Name}: Amount = {item.EffectAmount}");
                    }
                
            }
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}