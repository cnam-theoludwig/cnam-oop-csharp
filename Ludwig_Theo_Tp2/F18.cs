namespace Ludwig_Theo_Tp2;

public class F18 : Spaceship, IAbility
{
    public F18() : base(15, 0, 0, false)
    {
    }

    public override string Name { get; set; } = "F-18 Kamikaze";

    public override void ShootTarget(Spaceship target)
    {
    }

    public void UseAbility(List<Spaceship> spaceships)
    {
        int index = spaceships.IndexOf(this);

        if (index >= 0)
        {
            if (index > 0 && !spaceships[index - 1].IsDestroyed)
            {
                Console.WriteLine($"{this.Name} explodes and deals 10 damage to the enemy ship in front!");
                spaceships[index - 1].TakeDamages(10);
            }

            if (index < spaceships.Count - 1 && !spaceships[index + 1].IsDestroyed)
            {
                Console.WriteLine($"{this.Name} explodes and deals 10 damage to the enemy ship behind!");
                spaceships[index + 1].TakeDamages(10);
            }
            this.TakeDamages(this.Structure);
            spaceships.RemoveAt(index);
            Console.WriteLine($"{this.Name} has been destroyed in the explosion.");
        }
    }
}
