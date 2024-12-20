public class Item
{
    public string Name { get; }
    public int Duration { get; private set; }
    public int EffectAmount { get; }

    public Item(string name, int duration, int effectAmount)
    {
        Name = name;
        Duration = duration;
        EffectAmount = effectAmount;
    }
    public void DecreaseDuration()
    {
        Duration --;
    }
}
