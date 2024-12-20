//public class CombatSimulator
//{
//    private EventManager _eventManager;

//    public CombatSimulator(EventManager eventManager)
//    {
//        _eventManager = eventManager;
//    }

//    public void SimulateTurn(Character attacker, Character defender, Ability ability)
//    {
//        ability.UseAbility(attacker, defender);
//        _eventManager.ScheduleEvent($"Turn executed: {attacker.Name} used {ability.Name} on {defender.Name}");

//        var result = new TurnResult(
//            $"{attacker.Name} attacked {defender.Name}",
//            defender.Health,
//            attacker.Mana,
//            ability.Name,
//            defender.Name
//        );

//        Console.WriteLine(result.Description);
//        Console.WriteLine($"Target Health: {result.Health}, Target Mana: {result.Mana}");
//    }
//}
