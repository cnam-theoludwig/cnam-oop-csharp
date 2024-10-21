namespace Ludwig_Theo_Tp2;

public class SpaceInvaders
{
    private readonly List<Player> _players;
    private readonly List<Spaceship> _enemies;
    private readonly Armory _armory;

    public SpaceInvaders()
    {
        this._players = [];
        this._enemies = [];
        this._armory = new Armory();
        this.Init();
    }

    private void Init()
    {
        this._players.Add(new Player("Emmet", "Brown", "EB"));
        this._players.Add(new Player("Jeanne", "Calment", "JC"));
        this._players.Add(new Player("Théo", "Ludwig", "Divlo"));

        this._enemies.Add(new BWings());
        this._enemies.Add(new Dart());
        this._enemies.Add(new F18());
        this._enemies.Add(new Rocinante());
        this._enemies.Add(new Tardis());
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

    public void PlayRound()
    {
        foreach (var enemy in this._enemies.Where(e => !e.IsDestroyed))
        {
            enemy.ShootTarget(this._players[0].BattleShip);
        }

        var aliveEnemies = this._enemies.Where(e => !e.IsDestroyed).ToList();
        if (aliveEnemies.Count > 0)
        {
            Random rand = new();
            int enemyIndex = rand.Next(aliveEnemies.Count);
            Spaceship targetEnemy = aliveEnemies[enemyIndex];

            this._players[0].BattleShip.ShootTarget(targetEnemy);
            Console.WriteLine($"{this._players[0].BattleShip.Name} attacks {targetEnemy.Name}!");
        }

        foreach (var spaceship in this._players.Select(p => p.BattleShip).Concat(this._enemies))
        {
            if (!spaceship.IsDestroyed)
            {
                spaceship.RepairShield(2);
                Console.WriteLine($"{spaceship.Name} regains shield. Current shield: {spaceship.Shield}/{spaceship.MaxShield}");
            }
        }
    }

    public static void Main()
    {
        SpaceInvaders game = new();
        game.ViewGame();

        Player player = game._players[0];
        Weapon weapon = game.AddWeaponToPlayer(player);
        game.ViewGame();

        game.PlayRound();
        game.ViewGame();
        // while (!player.BattleShip.IsDestroyed && game._enemies.Any(e => !e.IsDestroyed))
        // {
        // }

        Console.WriteLine("Game Over!");
    }
}
