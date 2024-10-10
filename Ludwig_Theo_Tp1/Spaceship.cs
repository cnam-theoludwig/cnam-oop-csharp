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
            throw new InvalidOperationException($"Maximum capacity of weapons reached: {WEAPONS_CAPACITY}");
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
            Console.WriteLine("No weapons on this spaceship.");
            return;
        }
        Console.WriteLine("Weapons on this spaceship:");
        foreach (Weapon weapon in this.weapons)
        {
            Console.WriteLine(weapon);
        }
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
}
