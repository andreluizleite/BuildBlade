public class GameSimulation
{
    public async Task RunSimulation(Character character, Logger logger)
    {
        int turn = 0;
        while (character.IsAlive())
        {
            logger.LogEvent($"Turn {turn}: Character Health = {character.Health}");
            character.Update(turn, logger);
            await Task.Delay(1000);
            turn++;
        }
    }
}
