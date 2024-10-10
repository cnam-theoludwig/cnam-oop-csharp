public enum EWeaponType
{
    Direct,
    Explosive,
    Guided
}

public class Weapon
{
    public string Name { get; }
    public int MinDamage { get; }
    public int MaxDamage { get; }
    public EWeaponType WeaponType { get; }

    public Weapon(string name, int minDamage, int maxDamage, EWeaponType weaponType)
    {
        this.Name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.WeaponType = weaponType;
    }

    public int DealDamage()
    {
        Random random = new Random();
        return random.Next(this.MinDamage, this.MaxDamage + 1);
    }

    public override string ToString()
    {
        return $"{this.Name} (Type: {this.WeaponType}, Damage: [{this.MinDamage}, {this.MaxDamage}]";
    }
}
