public class GameSimulationTests
{
    [Fact]
    public async Task CharacterUsesAbilitiesCorrectly()
    {
        var logger = new Logger();
        var character = new Character("Hero", 100);

        var basicAtttack = new Ability("Basic Attack", 10, 2);
        var fireball = new Ability("Fireball", 40, 60);
        var heal = new Ability("Heal", 2, 5);
        var shield = new Ability("Shield", 3, 10);

        character.AddAbility(fireball);
        character.AddAbility(basicAtttack);
        character.AddAbility(heal);
        character.AddAbility(shield);

        var healthPotion = new Item("Health Potion", 2, 10);
        var damagePotion = new Item("Damage Poison", 2, -10);

        character.AddItem(healthPotion);
        character.AddItem(damagePotion);

        var simulation = new GameSimulation();
        await simulation.RunSimulation(character, logger);

        // Test if events were logged correctly
        var events = logger.GetEvents();

        // Example checks (this can be expanded)
        Assert.Contains(events, e => e.Contains("Turn 0: Character Health = 100"));
    }

    [Fact]
    public void AbilityCooldownsTriggerCorrectly()
    {
        var character = new Character("Hero", 100);
        var logger = new Logger();

        var fireball = new Ability("Fireball", 30, 3);
        var heal = new Ability("Heal", -10, 5);
        var shield = new Ability("Shield", -5, 10);

        character.AddAbility(fireball);
        character.AddAbility(heal);
        character.AddAbility(shield);

        var simulation = new GameSimulation();

        // Simulate until cooldown times pass and check that abilities are triggered
        for (int i = 0; i < 15; i++) // simulate 15 turns
        {
            character.Update(i, logger);
        }

        // Verify that abilities were used at the right time based on their cooldowns
        var events = logger.GetEvents();
        Assert.Contains(events, e => e.Contains("Ability Fireball triggered at time 3s"));
        Assert.Contains(events, e => e.Contains("Ability Heal triggered at time 5s"));
        Assert.Contains(events, e => e.Contains("Ability Shield triggered at time 10s"));
    }
}