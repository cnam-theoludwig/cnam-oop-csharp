namespace Ludwig_Theo_Tp2;

public class Rocinante : Spaceship
{
    public override string Name { get; set; } = "Rocinante";

    private readonly Random _random = new();

    public Rocinante() : base(3, 5, 1, false)
    {
        this.AddWeapon(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
    }

    public override void ShootTarget(Spaceship target)
    {
        Weapon? torpille = this.Weapons.FirstOrDefault(w => w.Type == EWeaponType.Guided);
        if (torpille != null)
        {
            double damage = torpille.Shoot();
            Console.WriteLine($"Rocinante shoots with {damage} guided damage!");
            target.TakeDamages(damage);
        }
    }

    public override void TakeDamages(double damages)
    {
        bool evaded = this._random.NextDouble() < 0.5;
        if (evaded)
        {
            Console.WriteLine("Rocinante evades the attack!");
        }
        else
        {
            base.TakeDamages(damages);
        }
    }
}
