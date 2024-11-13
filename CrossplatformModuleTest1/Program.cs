using System;
using System.IO;

namespace Module
{
    public class Program
    {
        static void Main()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string inputFilePath = Path.Combine(projectDirectory, "input.txt");
            string outputFilePath = Path.Combine(projectDirectory, "output.txt");

            try
            {
                long n;
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    string input = reader.ReadLine();
                    if (!long.TryParse(input, out n))
                    {
                        throw new FormatException("Некоректний формат вводу. Очікується ціле число.");
                    }
                }

                string result = GetDivisorsCount(n);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine(result);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Помилка: некоректний формат вводу.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Помилка: сталася несподівана помилка.");
                }
            }
        }

        public static string GetDivisorsCount(long n)
        {
            if (n > 1000000000000000000 || n < 1) //10^18
            {
                return "число некоректне";
            }

            int count = 0;
            long sqrtN = (long)Math.Sqrt(n); //для кпащих часових показників не будемо ітерувати до заданого числа n, а до кореня цього числа

            for (long i = 1; i <= sqrtN; i++)
            {
                if (n % i == 0)//якщо залишок від ділення 0
                {
                    count++;//то це дільник (збільшили лічильник)
                    if (i != n / i) //якщо при діленні числа на дільник отримуємо інше число
                    {
                        count++; // то це також дільник
                    }
                }
            }

            return count.ToString();
        }
    }
}
