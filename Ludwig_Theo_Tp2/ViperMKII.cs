namespace Ludwig_Theo_Tp2;

public class ViperMKII : Spaceship
{
    public override string Name { get; set; } = "ViperMKII";

    private readonly Random _random = new();

    public ViperMKII() : base(10, 15, 3, true)
    {
        this.AddWeapon(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
        this.AddWeapon(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
        this.AddWeapon(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
    }

    public override void ShootTarget(Spaceship target)
    {

        List<Weapon> weaponsAvailable = this.Weapons.FindAll(w => !w.IsReloading);
        Weapon? weaponToFire = weaponsAvailable.Count > 0 ? weaponsAvailable[this._random.Next(0, weaponsAvailable.Count)] : null;
        if (weaponToFire != null)
        {
            double damage = weaponToFire.Shoot();
            Console.WriteLine($"ViperMKII shoots with {damage} damage from {weaponToFire.Name}!");
            target.TakeDamages(damage);
        }
        else
        {
            Console.WriteLine("ViperMKII has no weapons ready to fire!");
        }
    }

    public override void TakeDamages(double damages)
    {
        base.TakeDamages(damages);
    }
}
