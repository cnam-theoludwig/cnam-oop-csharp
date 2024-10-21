namespace Ludwig_Theo_Tp2;

public interface IWeapon
{
    string Name { get; set; }
    EWeaponType Type { get; set; }
    double MinDamage { get; set; }
    double MaxDamage { get; set; }
    double AverageDamage { get; }
    double ReloadTime { get; set; }
    double TimeBeforReload { get; set; }
    bool IsReload { get; }
    double Shoot();
}
