public class Spaceship
{
    public int MaxStructure { get; }
    public int MaxShield { get; }

    public int CurrentStructure { get; set; }
    public int CurrentShield { get; set; }

    private static readonly int WEAPONS_CAPACITY = 3;

    private List<Weapon> weapons;

    public bool IsDestroyed
    {
        get
        {
            return this.CurrentStructure == 0;
        }
    }

    public static Spaceship Default()
    {
        return new Spaceship(100, 50);
    }

    public Spaceship(int maxStructure, int maxShield)
    {
        this.MaxStructure = maxStructure;
        this.MaxShield = maxShield;
        this.CurrentStructure = maxStructure;
        this.CurrentShield = maxShield;
        this.weapons = new List<Weapon>();
    }

    public void AddWeapon(Weapon weapon)
    {
        if (this.weapons.Count >= WEAPONS_CAPACITY)
        {
            throw new ArmoryException(ArmoryExceptionType.MaximumCapacityReached);
        }
        this.weapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        this.weapons.Remove(weapon);
    }

    public void ClearWeapons()
    {
        this.weapons.Clear();
    }

    public void ViewWeapons()
    {
        if (this.weapons.Count == 0)
        {
            Console.WriteLine("  No weapons on this spaceship.");
            return;
        }
        Console.WriteLine("  Weapons on this spaceship:");
        foreach (Weapon weapon in this.weapons)
        {
            Console.WriteLine("    " + weapon);
        }
    }

    public void ViewShip()
    {
        Console.WriteLine($"  Max Structure: {this.MaxStructure}");
        Console.WriteLine($"  Current Structure: {this.CurrentStructure}");
        Console.WriteLine($"  Max Shield: {this.MaxShield}");
        Console.WriteLine($"  Current Shield: {this.CurrentShield}");
        Console.WriteLine($"  Is Destroyed: {this.IsDestroyed}");
        Console.WriteLine($"  Average Damages: {this.AverageDamages()}");
        this.ViewWeapons();
    }

    public double AverageDamages()
    {
        if (this.weapons.Count == 0)
        {
            return 0.0;
        }
        double totalMinDamage = 0;
        double totalMaxDamage = 0;
        foreach (Weapon weapon in this.weapons)
        {
            totalMinDamage += weapon.MinDamage;
            totalMaxDamage += weapon.MaxDamage;
        }
        return (totalMinDamage + totalMaxDamage) / (2 * this.weapons.Count);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= this.CurrentShield)
        {
            this.CurrentShield -= damage;
        }
        else
        {
            int remainingDamage = damage - this.CurrentShield;
            this.CurrentShield = 0;
            this.CurrentStructure = Math.Max(0, this.CurrentStructure - remainingDamage);
        }
    }

    public void RepairStructure(int repairPoints)
    {
        this.CurrentStructure = Math.Min(this.MaxStructure, this.CurrentStructure + repairPoints);
    }

    public void RepairShield(int repairPoints)
    {
        this.CurrentShield = Math.Min(this.MaxShield, this.CurrentShield + repairPoints);
    }
}
