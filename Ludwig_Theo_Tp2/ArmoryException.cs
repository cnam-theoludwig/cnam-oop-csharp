namespace Ludwig_Theo_Tp2;

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
