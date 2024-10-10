public class SpaceInvaders
{
    private List<Player> players;

    public SpaceInvaders()
    {
        this.players = new List<Player>();
        this.Init();
    }

    private void Init()
    {
        this.players.Add(new Player("Emmet", "Brown", "EB"));
        this.players.Add(new Player("Jeanne", "Calment", "JC"));
        this.players.Add(new Player("Théo", "Ludwig", "Divlo"));
    }

    public static void Main(string[] args)
    {
        SpaceInvaders game = new SpaceInvaders();
        foreach (Player player in game.players)
        {
            Console.WriteLine(player);
        }
    }
}
