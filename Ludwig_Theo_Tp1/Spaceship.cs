public class Spaceship
{
    public int MaxStructure { get; }
    public int MaxShield { get; }

    public int CurrentStructure { get; set; }
    public int CurrentShield { get; set; }

    public bool IsDestroyed
    {
        get
        {
            return this.CurrentStructure == 0;
        }
    }
}
