namespace Ludwig_Theo_Tp2;

public class Player : IPlayer
{
    private string FirstName { get; }
    private string LastName { get; }
    public string Alias { get; set; }
    public string Name
    {
        get
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
    public Spaceship BattleShip { get; set; }

    public Player(string firstName, string lastName, string alias)
    {
        this.FirstName = Player.FormatName(firstName);
        this.LastName = Player.FormatName(lastName);
        this.Alias = alias;
        this.BattleShip = Spaceship.Default();
    }

    private static string FormatName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        return char.ToUpper(name[0]) + name[1..].ToLower();
    }

    public override string ToString()
    {
        return $"{this.Alias} ({this.Name})";
    }

    public override bool Equals(object? other)
    {
        Player? otherPlayer = other as Player;
        return otherPlayer is not null && this.Equals(otherPlayer);
    }

    public bool Equals(Player other)
    {
        return other != null && this.Alias == other.Alias;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Alias);
    }
}
