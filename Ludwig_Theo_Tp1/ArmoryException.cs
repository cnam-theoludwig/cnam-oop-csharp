namespace Ludwig_Theo_Tp1;

public enum ArmoryExceptionType
{
    MaximumCapacityReached,
    NoWeaponsAvailable
}

public class ArmoryException : Exception
{
    public ArmoryException()
    {
    }

    public ArmoryException(ArmoryExceptionType type)
        : base("ArmoryException: " + type)
    {
    }
}
