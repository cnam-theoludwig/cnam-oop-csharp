namespace Ludwig_Theo_Tp2;

public abstract class Spaceship : ISpaceship
{
    public double MaxStructure { get; }
    public double MaxShield { get; }
    public double Structure { get; set; }
    public double Shield { get; set; }
    public bool BelongsPlayer { get; set; }
    public List<Weapon> Weapons { get; }
    public int MaxWeapons { get; }

    public Spaceship(double maxStructure, double maxShield, int maxWeapons, bool belongsPlayer)
    {
        this.MaxStructure = maxStructure;
        this.MaxShield = maxShield;
        this.Structure = maxStructure;
        this.Shield = maxShield;
        this.MaxWeapons = maxWeapons;
        this.BelongsPlayer = belongsPlayer;
        this.Weapons = [];
    }

    public bool IsDestroyed => this.Structure == 0;

    public abstract string Name { get; set; }

    public abstract void ShootTarget(Spaceship target);

    public virtual void TakeDamages(double damages)
    {
        if (this.Shield >= damages)
        {
            this.Shield -= damages;
        }
        else
        {
            double remainingDamage = damages - this.Shield;
            this.Shield = 0;
            this.Structure = Math.Max(0, this.Structure - remainingDamage);
        }
    }

    public void ReloadWeapons()
    {
        foreach (Weapon weapon in this.Weapons)
        {
            weapon.Reload();
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        if (this.Weapons.Count < this.MaxWeapons)
        {
            this.Weapons.Add(weapon);
        }
        else
        {
            Console.WriteLine("Cannot add more weapons, limit reached.");
        }
    }

    public void RemoveWeapon(Weapon oWeapon)
    {
        this.Weapons.Remove(oWeapon);
    }

    public void ClearWeapons()
    {
        this.Weapons.Clear();
    }

    public void ViewShip()
    {
        Console.WriteLine($"Structure: {this.Structure}/{this.MaxStructure}, Shield: {this.Shield}/{this.MaxShield}");
        this.ViewWeapons();
    }

    public void ViewWeapons()
    {
        foreach (Weapon weapon in this.Weapons)
        {
            Console.WriteLine($"Weapon: {weapon.Name} (Damage: {weapon.MinDamage}-{weapon.MaxDamage}, Type: {weapon.Type})");
        }
    }

    public double AverageDamages => this.Weapons.Count != 0 ? this.Weapons.Average(w => (w.MinDamage + w.MaxDamage) / 2) : 0;

    public void RepairShield(double repair)
    {
        this.Shield = Math.Min(this.MaxShield, this.Shield + repair);
    }

    public static Spaceship Default()
    {
        return new ViperMKII();
    }
}
