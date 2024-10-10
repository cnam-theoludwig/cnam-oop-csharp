public class Armory
{
    private List<Weapon> weapons;

    public Armory()
    {
        this.weapons = new List<Weapon>();
        this.Init();
    }

    private void Init()
    {
        this.weapons.Add(new Weapon("Laser Beam", 10, 20, EWeaponType.Direct));
        this.weapons.Add(new Weapon("Missile", 30, 50, EWeaponType.Explosive));
        this.weapons.Add(new Weapon("Guided Rocket", 25, 40, EWeaponType.Guided));
    }

    public void ViewArmory()
    {
        Console.WriteLine("Available weapons in the armory:");
        foreach (Weapon weapon in this.weapons)
        {
            Console.WriteLine(weapon);
        }
    }

    public List<Weapon> GetWeapons()
    {
        return this.weapons;
    }

    public void AddWeapon(Weapon weapon)
    {
        this.weapons.Add(weapon);
    }
}
