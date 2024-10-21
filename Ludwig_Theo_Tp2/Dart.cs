namespace Ludwig_Theo_Tp2;

public class Dart : Spaceship
{
    public override string Name { get; set; } = "Dart";

    public Dart() : base(10, 3, 1, false)
    {
        this.AddWeapon(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
    }

    public override void ShootTarget(Spaceship target)
    {
        Weapon? laser = this.Weapons.FirstOrDefault(w => w.Type == EWeaponType.Direct);
        if (laser != null)
        {
            double damage = laser.Shoot();
            Console.WriteLine($"Dart shoots with {damage} damage!");
            target.TakeDamages(damage);
        }
    }
}
