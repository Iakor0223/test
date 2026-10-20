using System;

class Program
{
    static void Main()
    {
        // 1. Инициализируем массивы данных
        int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] monthNames = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };

        // 2. Безопасный ввод года
        Console.Write("Введите год: ");
        if (!int.TryParse(Console.ReadLine(), out int year) || year < 1)
        {
            Console.WriteLine("Ошибка! Пожалуйста, введите корректный год.");
            return;

        }

        // 3. Проверяем год на високосность по правилу
        int maxDaysInYear = 365; 
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            daysInMonths[1] = 29; // В високосном году в феврале 29 дней
            maxDaysInYear = 366;  // Максимальное число дней увеличивается до 366
        }

        // 4. Безопасный ввод номера дня с учетом типа года
        Console.Write($"Введите номер дня в году (от 1 до {maxDaysInYear}): ");
        if (int.TryParse(Console.ReadLine(), out int daysLeft) && daysLeft >= 1 && daysLeft <= maxDaysInYear)
        {
            int originalDay = daysLeft; // Сохраняем исходное число для вывода
            int monthIndex = 0;         // Индекс текущего месяца (0 - январь)

            // 5. Цикл while: вычитаем дни месяцев
            while (daysLeft > daysInMonths[monthIndex])
            {
                daysLeft -= daysInMonths[monthIndex]; // Вычитаем дни текущего месяца
                monthIndex++;                        // Переходим к следующему месяцу
            }

            // 6. Выводим результат
            Console.WriteLine($"Число {originalDay} в {year} году соответствует: {daysLeft} {monthNames[monthIndex]}");
        }
        else
        {
            Console.WriteLine($"Ошибка! Пожалуйста, введите корректное число от 1 до {maxDaysInYear}.");
        }
    }
}
