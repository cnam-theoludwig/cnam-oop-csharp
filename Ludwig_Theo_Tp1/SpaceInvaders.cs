namespace Ludwig_Theo_Tp1;

public class SpaceInvaders
{
    private readonly List<Player> _players;
    private readonly Armory _armory;

    public SpaceInvaders()
    {
        this._players = [];
        this._armory = new();
        this.Init();
    }

    private void Init()
    {
        this._players.Add(new Player("Emmet", "Brown", "EB"));
        this._players.Add(new Player("Jeanne", "Calment", "JC"));
        this._players.Add(new Player("Théo", "Ludwig", "Divlo"));
    }

    public void ShowPlayerShips()
    {
        foreach (Player player in this._players)
        {
            Console.WriteLine(player);
            Console.WriteLine("Spaceship:");
            player.Spaceship.ViewShip();
            Console.WriteLine();
        }
    }

    private Weapon AddWeaponToPlayer(Player player)
    {
        Weapon weapon = this._armory.GetRandomWeapon();
        player.Spaceship.AddWeapon(weapon);
        return weapon;
    }

    private void ViewGame()
    {
        Console.WriteLine();
        Console.WriteLine("Space Invaders");
        Console.WriteLine("---------------");
        this._armory.ViewArmory();
        this.ShowPlayerShips();
        Console.WriteLine("---------------");
    }

    public static void Main()
    {
        SpaceInvaders game = new();
        game.ViewGame();

        Player player = game._players[0];
        Weapon weapon = game.AddWeaponToPlayer(player);
        game.ViewGame();

        Player player2 = game._players[1];
        while (!player2.Spaceship.IsDestroyed)
        {

            player2.Spaceship.TakeDamage(weapon.DealDamage());
            game.ViewGame();
        }
    }
}
