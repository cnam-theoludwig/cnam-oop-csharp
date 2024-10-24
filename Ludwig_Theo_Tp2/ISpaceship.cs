﻿namespace Ludwig_Theo_Tp2;

public interface ISpaceship
{
    string Name { get; set; }
    double Structure { get; set; }
    double Shield { get; set; }
    bool IsDestroyed { get; }
    int MaxWeapons { get; }
    List<Weapon> Weapons { get; }
    double AverageDamages { get; }
    bool BelongsPlayer { get; }
    void TakeDamages(double damages);
    void RepairShield(double repair);
    void ShootTarget(Spaceship target);
    void ReloadWeapons();
    void AddWeapon(Weapon weapon);
    void RemoveWeapon(Weapon oWeapon);
    void ClearWeapons();
    void ViewShip();
    void ViewWeapons();
}
