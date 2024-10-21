namespace Ludwig_Theo_Tp2;

public enum EWeaponType
{
    Direct,
    Explosive,
    Guided
}

public class Weapon : IWeapon
{
    public string Name { get; set; }
    public EWeaponType Type { get; set; }
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double ReloadTime { get; set; }
    public double TimeBeforeReload { get; set; }

    private readonly Random _random;

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType weaponType, double reloadTime)
    {
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.Type = weaponType;
        this.ReloadTime = reloadTime;
        this.TimeBeforeReload = reloadTime;
        this._random = new Random();
    }

    public double AverageDamage => (this.MinDamage + this.MaxDamage) / 2;

    public bool IsReloading => this.TimeBeforeReload > 0;

    public void Reload()
    {
        if (this.IsReloading)
        {
            this.TimeBeforeReload--;
        }
    }

    public double Shoot()
    {
        if (this.IsReloading)
        {
            return 0;
        }
        double damage = this._random.NextDouble() * (this.MaxDamage - this.MinDamage) + this.MinDamage;
        switch (this.Type)
        {
            case EWeaponType.Direct:
                if (this._random.Next(10) == 0)
                {
                    damage = 0;
                }
                break;

            case EWeaponType.Explosive:
                if (this._random.Next(4) == 0)
                {
                    damage = 0;
                }
                else
                {
                    damage *= 2;
                    this.ReloadTime *= 2;
                }
                break;

            case EWeaponType.Guided:
                damage = this.MinDamage;
                break;
        }

        this.TimeBeforeReload = this.ReloadTime;
        return damage;
    }

    public override string ToString()
    {
        return $"{this.Name} (Type: {this.Type}, Damage: [{this.MinDamage}, {this.MaxDamage}], ReloadTime: {this.ReloadTime})";
    }
}
