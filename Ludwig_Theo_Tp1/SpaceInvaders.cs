public class SpaceInvaders
{
    private List<Player> players;
    private Armory armory;

    public SpaceInvaders()
    {
        this.players = new List<Player>();
        this.armory = new Armory();
        this.Init();
    }

    private void Init()
    {
        this.players.Add(new Player("Emmet", "Brown", "EB", new Spaceship(100, 50)));
        this.players.Add(new Player("Jeanne", "Calment", "JC", new Spaceship(80, 40)));
        this.players.Add(new Player("Théo", "Ludwig", "Divlo", new Spaceship(120, 60)));
    }

    public void ShowPlayerShips()
    {
        foreach (Player player in players)
        {
            Console.WriteLine(player);
            Console.WriteLine("Spaceship:");
            player.SpaceshipDefault.ViewShip();
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        SpaceInvaders game = new SpaceInvaders();
        game.armory.ViewArmory();
        Console.WriteLine();
        game.ShowPlayerShips();
    }
}
