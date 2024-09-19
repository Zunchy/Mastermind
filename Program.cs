const short _attempts = 10;
const short _challangeLength = 4;
const short _minInclusiveChallengeDigit = 1;
const short _maxExclusiveChallengeDigit = 7;

PrintInstructions();
var result = Play();

if (result)
{
    Console.WriteLine("Congatulations! You have guessed the correct value.");
}
else
{
    Console.WriteLine("All attempts have been used. Game Over.");
}

Environment.Exit(0);

/// <summary>
/// Displays Game Instructions to the Player.
/// </summary>
void PrintInstructions()
{
    Console.WriteLine("Hello, Welcome to Mastermind! The instructions are as follows:");
    Console.WriteLine($"You will have to guess a randomly generated {_challangeLength} digit number, you will have {_attempts} attempts to guess this number correctly. Each digit will be in the range of 1 to 6 (inclusive). Once a guess is submitted, a minus (-) sign will be displayed for every digit that is correct but in the wrong position, and a plus (+) sign will be printed for every digit that is both correct and in the correct position. Nothing will be displayed for digits that are not present in the answer.");
}

/// <summary>
/// Enters the main game loop.
/// </summary>
/// <returns>True if the player successfully guess the correct number; false otherwise.</returns>
bool Play()
{
    var userAttempts = _attempts;

    var challengeNumber = GenerateChallengeNumber();

    Console.WriteLine("Please enter your first guess:");
    var userGuess = string.Empty;

    while (userAttempts != 0)
    {
        userGuess = Console.ReadLine();

        // Ensure input is valid and matches the challenge number's length
        while (userGuess != null && userGuess.Length != challengeNumber.Length)
        {
            Console.WriteLine($"Input not valid, please ensure input contains a value and matches the challenge number's length of {challengeNumber.Length}:");

            userGuess = Console.ReadLine();
        }

        // User guessed correct value, return success.
        if (userGuess == challengeNumber)
        {
            return true;
        }

        // Generate Hint
        for (var i = 0; i < _challangeLength; i++)
        {
            if (userGuess[i] == challengeNumber[i])
            {
                Console.Write('+');
            }
            else if (challengeNumber.Contains(userGuess[i]))
            {
                Console.Write('-');
            }
        }

        // Move to new line after Hint
        Console.WriteLine();

        userAttempts -= 1;
        Console.WriteLine($"{userAttempts} guesses remaining.");
    }

    return false;
}

/// <summary>
/// Generates a 4 digit number in string format ranging from 1 to 6 (inclusive).
/// </summary>
/// <returns>The randomly generated number.</returns>
string GenerateChallengeNumber()
{
    var generatedValue = string.Empty;
    var randomGenerator = new Random();

    for (var i = 0; i < _challangeLength; i++)
    {
        var digit = randomGenerator.Next(_minInclusiveChallengeDigit, _maxExclusiveChallengeDigit);

        generatedValue += digit;
    }

    return generatedValue;
}
