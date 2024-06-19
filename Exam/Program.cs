using System;

namespace Exam
{
    internal class Program
    {
        static Random rand = new Random();
        static int score = 0;
        static string[] questions = new string[]
        {
            "What is the capital of Azerbaijan?",
            "What is the capital of France?",
            "What is the capital of Japan?",
            "What is the capital of Russia?",
            "What is the capital of Germany?",
            "What is the capital of Canada?",
            "What is the capital of Australia?",
            "What is the capital of Brazil?",
            "What is the capital of China?",
            "What is the capital of Egypt?"
        };

        static string[,] answers = new string[,]
        {
            { "Baku", "Ganja", "Naxcivan" },
            { "Paris", "Lyon", "Marseille" },
            { "Tokyo", "Osaka", "Kyoto" },
            { "Moscow", "Saint Petersburg", "Novosibirsk" },
            { "Berlin", "Munich", "Frankfurt" },
            { "Ottawa", "Toronto", "Vancouver" },
            { "Canberra", "Sydney", "Melbourne" },
            { "Brasília", "Rio de Janeiro", "São Paulo" },
            { "Beijing", "Shanghai", "Shenzhen" },
            { "Cairo", "Alexandria", "Giza" }
        };

        static int[] correctAnswers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        static void Main(string[] args)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                bool answeredCorrectly = false;
                while (!answeredCorrectly)
                {
                    int[] shuffledIndexes = ShuffleAnswers(i);
                    Console.WriteLine(questions[i]);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"{(char)('a' + j)}) {answers[i, shuffledIndexes[j]]}");
                    }
                    Console.Write("Choose an option (a, b, c): ");
                    char userChoice = Console.ReadLine()[0];
                    int userAnswerIndex = userChoice - 'a';

                    if (shuffledIndexes[userAnswerIndex] == correctAnswers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct!");
                        score += 10;
                        answeredCorrectly = true; // Move to the next question
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong!");
                        score = Math.Max(0, score - 10);
                    }

                    Console.ResetColor();
                    Console.WriteLine($"Current Score: {score}\n");
                }
            }

            Console.WriteLine("The exam is over. You have collected " + score + " points.");
        }

        static int[] ShuffleAnswers(int questionIndex)
        {
            int[] indexes = new int[] { 0, 1, 2 };
            for (int i = 0; i < indexes.Length; i++)
            {
                int randomIndex = rand.Next(i, indexes.Length);
                int temp = indexes[i];
                indexes[i] = indexes[randomIndex];
                indexes[randomIndex] = temp;
            }
            return indexes;
        }
    }
}
