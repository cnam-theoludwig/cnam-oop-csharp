namespace Ludwig_Theo_Tp1;

public class Armory
{
    public List<Weapon> Weapons { get; private set; }

    public Armory()
    {
        this.Weapons = [];
        this.Init();
    }

    private void Init()
    {
        this.Weapons.Add(new Weapon("Laser Beam", 10, 20, EWeaponType.Direct));
        this.Weapons.Add(new Weapon("Missile", 30, 50, EWeaponType.Explosive));
        this.Weapons.Add(new Weapon("Guided Rocket", 25, 40, EWeaponType.Guided));
    }

    public void ViewArmory()
    {
        Console.WriteLine("Available weapons in the armory:");
        foreach (Weapon weapon in this.Weapons)
        {
            Console.WriteLine(weapon);
        }
        Console.WriteLine();
    }

    public void AddWeapon(Weapon weapon)
    {
        this.Weapons.Add(weapon);
    }

    public Weapon GetRandomWeapon()
    {
        if (this.Weapons.Count <= 0)
        {
            throw new ArmoryException(ArmoryExceptionType.NoWeaponsAvailable);
        }
        Random random = new();
        int index = random.Next(0, this.Weapons.Count);
        Weapon weapon = this.Weapons[index];
        this.Weapons.RemoveAt(index);
        return weapon;
    }
}
