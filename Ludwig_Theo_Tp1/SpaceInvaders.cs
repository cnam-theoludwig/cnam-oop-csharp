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
        this.players.Add(new Player("Emmet", "Brown", "EB"));
        this.players.Add(new Player("Jeanne", "Calment", "JC"));
        this.players.Add(new Player("Théo", "Ludwig", "Divlo"));
    }

    public void ShowPlayerShips()
    {
        foreach (Player player in players)
        {
            Console.WriteLine(player);
            Console.WriteLine("Spaceship:");
            player.Spaceship.ViewShip();
            Console.WriteLine();
        }
    }

    private Weapon AddWeaponToPlayer(Player player)
    {
        Weapon weapon = this.armory.GetRandomWeapon();
        player.Spaceship.AddWeapon(weapon);
        return weapon;
    }

    private void ViewGame()
    {
        Console.WriteLine();
        Console.WriteLine("Space Invaders");
        Console.WriteLine("---------------");
        this.armory.ViewArmory();
        this.ShowPlayerShips();
        Console.WriteLine("---------------");
    }

    public static void Main(string[] args)
    {
        SpaceInvaders game = new SpaceInvaders();
        game.ViewGame();

        Player player = game.players[0];
        Weapon weapon = game.AddWeaponToPlayer(player);
        game.ViewGame();

        Player player2 = game.players[1];
        while (!player2.Spaceship.IsDestroyed)
        {

            player2.Spaceship.TakeDamage(weapon.DealDamage());
            game.ViewGame();
        }
    }
}
