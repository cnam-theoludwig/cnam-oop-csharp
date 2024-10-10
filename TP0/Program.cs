namespace TP0;

public class Program
{
    const int HAIR_MINIMUM_COUNT = 100_000;
    const int HAIR_MAXIMUM_COUNT = 150_000;
    const int SLEEP_MILLISECONDS = 3_000;
    const int SLEEP_COUNT_MILLISECONDS = 1_000;
    const int COUNT_MAXIMUM = 10;

    enum ProgramOption
    {
        EXIT = 1,
        RESTART = 2,
        COUNT_TO_TEN = 3,
        PHONE_JACQUELINE = 4,
    }

    public static void Main()
    {
        ProgramOption option = ProgramOption.RESTART;
        while (true)
        {
            if (option == ProgramOption.EXIT)
            {
                Console.WriteLine("Au revoir !");
                Thread.Sleep(SLEEP_MILLISECONDS);
                break;
            }
            else if (option == ProgramOption.RESTART)
            {
                MainProgram();
                Console.WriteLine("1 - Quitter le programme");
                Console.WriteLine("2 - Recommencer le programme");
                Console.WriteLine("3 - Compter jusqu'à 10");
                Console.WriteLine("4 - Téléphoner à Tata Jacqueline");
                option = (ProgramOption)SecureIntegerInput("Veuillez choisir une option : ", 4);
            }
            else if (option == ProgramOption.COUNT_TO_TEN)
            {
                CountProgram();
                option = ProgramOption.EXIT;
            }
            else
            {
                PhoneJacqueline();
                option = ProgramOption.EXIT;
            }
        }
    }

    public static void CountProgram()
    {
        for (int count = 1; count <= COUNT_MAXIMUM; count++)
        {
            Console.WriteLine(count);
            Thread.Sleep(SLEEP_COUNT_MILLISECONDS);
        }
    }

    public static void PhoneJacqueline()
    {
        Console.WriteLine("Message d'absence de Tata Jacqueline");
        Console.WriteLine("(je ne suis pas inventif)");
    }

    public static void MainProgram()
    {
        Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe !");
        string lastname = SecureStringInput("Donne moi ton nom, vil chenapan : ");
        string firstname = SecureStringInput("Et quel est ton prénom, petit galopin : ");
        Console.WriteLine("Bonjour " + FormatFirstnameLastname(firstname, lastname) + " !");

        int heightCm = SecureIntegerInput("Taille (cm) : ");
        int weightKg = SecureIntegerInput("Poids (kg) : ");
        int ageYear = SecureIntegerInput("Âge (année) : ");

        if (ageYear < 18)
        {
            Console.WriteLine("Morveux puéril et immature qui n'a même pas le droit d'acheter de l'alcool en grande surface.");
        }

        float bmi = CalculateBMI(heightCm, weightKg);
        Console.WriteLine("Votre IMC (Indice de Masse Corporelle) : " + bmi.ToString("0.0"));
        PrintCommentBMI(bmi);

        Console.WriteLine("Estimez le nombre de cheveux sur votre tête :");
        do
        {
            int hairNumber = 0;
            if (int.TryParse(Console.ReadLine(), out hairNumber) && hairNumber > HAIR_MINIMUM_COUNT && hairNumber < HAIR_MAXIMUM_COUNT)
            {
                Console.WriteLine($"Bravo, il y a environ {HAIR_MINIMUM_COUNT} à {HAIR_MAXIMUM_COUNT} cheveux sur votre tête !");
                break;
            }
            Console.WriteLine("Non, c'est faux. Essayez encore !");

        } while (true);
    }

    public static string SecureStringInput(string message)
    {
        string input = "";
        do
        {
            Console.Write(message);
            input = Console.ReadLine() ?? "";
        } while (string.IsNullOrEmpty(input) || input.Any(char.IsDigit));
        return input;
    }

    public static int SecureIntegerInput(string message, int? maximumValue = null)
    {
        int input = 0;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out input) || input <= 0 || (maximumValue != null && input > maximumValue));
        return input;
    }

    public static string FormatFirstnameLastname(string firstname, string lastname)
    {
        return firstname + " " + lastname.ToUpper();
    }

    public static float CalculateBMI(int heightCm, int weightKg)
    {
        float heightM = (float)heightCm / 100;
        return weightKg / (heightM * heightM);
    }

    public static void PrintCommentBMI(float bmi)
    {
        const string BMI_LEVEL_0 = "Attention à l'anorexie!";
        const string BMI_LEVEL_1 = "Vous êtes un peu maigrichon !";
        const string BMI_LEVEL_2 = "Vous êtes de corpulence normale !";
        const string BMI_LEVEL_3 = "Vous êtes en surpoids !";
        const string BMI_LEVEL_4 = "Obésité modérée !";
        const string BMI_LEVEL_5 = "Obésité sévère !";
        const string BMI_LEVEL_6 = "Obésité morbide !";

        if (bmi < 16.5)
        {
            Console.WriteLine(BMI_LEVEL_0);
        }
        else if (bmi < 18.5)
        {
            Console.WriteLine(BMI_LEVEL_1);
        }
        else if (bmi < 25)
        {
            Console.WriteLine(BMI_LEVEL_2);
        }
        else if (bmi < 30)
        {
            Console.WriteLine(BMI_LEVEL_3);
        }
        else if (bmi < 35)
        {
            Console.WriteLine(BMI_LEVEL_4);
        }
        else if (bmi < 40)
        {
            Console.WriteLine(BMI_LEVEL_5);
        }
        else
        {
            Console.WriteLine(BMI_LEVEL_6);
        }
    }
}
