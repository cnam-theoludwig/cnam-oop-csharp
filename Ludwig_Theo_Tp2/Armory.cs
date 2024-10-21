namespace Ludwig_Theo_Tp2;

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
        this.Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.Direct, 2));
        this.Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 1.5));
        this.Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        this.Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
        this.Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5));
        this.Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
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
