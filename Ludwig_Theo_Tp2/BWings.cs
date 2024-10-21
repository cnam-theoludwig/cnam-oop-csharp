namespace Ludwig_Theo_Tp2;

public class BWings : Spaceship
{
    public override string Name { get; set; } = "B-Wings";

    public BWings() : base(30, 0, 1, false)
    {
        this.AddWeapon(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 1.5));
    }

    public override void ShootTarget(Spaceship target)
    {
        Weapon? hammer = this.Weapons.FirstOrDefault(w => w.Type == EWeaponType.Explosive);
        if (hammer != null)
        {
            double damage = hammer.Shoot();
            Console.WriteLine($"B-Wings shoots with {damage} explosive damage!");
            target.TakeDamages(damage);
        }
    }
}
