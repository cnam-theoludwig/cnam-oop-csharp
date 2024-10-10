public enum EWeaponType
{
    Direct,
    Explosive,
    Guided
}

public class Weapon
{
    public string Name { get; set; } = string.Empty;
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public EWeaponType WeaponType { get; set; }
}
