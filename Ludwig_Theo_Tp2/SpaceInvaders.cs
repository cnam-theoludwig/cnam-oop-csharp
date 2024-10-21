namespace Ludwig_Theo_Tp2;

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
            player.BattleShip.ViewShip();
            Console.WriteLine();
        }
    }

    private Weapon AddWeaponToPlayer(Player player)
    {
        Weapon weapon = this._armory.GetRandomWeapon();
        player.BattleShip.AddWeapon(weapon);
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
        while (!player2.BattleShip.IsDestroyed)
        {
            player2.BattleShip.ShootTarget(player.BattleShip);
            game.ViewGame();
        }
    }
}
