namespace Ludwig_Theo_Tp2;

public class Tardis : Spaceship, IAbility
{
    private readonly Random _random = new();

    public Tardis() : base(1, 0, 0, false)
    {
    }

    public override string Name { get; set; } = "Tardis";

    public override void ShootTarget(Spaceship target)
    {
    }

    public void UseAbility(List<Spaceship> spaceships)
    {
        int targetIndex = this._random.Next(spaceships.Count);
        int newPosition = this._random.Next(spaceships.Count);

        Spaceship target = spaceships[targetIndex];
        spaceships.RemoveAt(targetIndex);
        spaceships.Insert(newPosition, target);

        Console.WriteLine($"{this.Name} teleports {target.Name} to position {newPosition}!");
    }
}
