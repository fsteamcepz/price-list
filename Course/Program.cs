using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;    // укр мова в консолі для виведення
            Console.InputEncoding = System.Text.Encoding.Unicode;     // укр мова в консолі для введення

            // Символ "@" дозволяє напряму звернутися до файлу
            string PATH = @"C:\Users\User\source\repos\repos_c#\Course\Course\bin\Debug\Фільм.txt";
            string PATH2 = @"C:\Users\User\source\repos\repos_c#\Course\Course\bin\Debug\Музика.txt";

            Film[] numberOfFilm = new Film[10];                       // до 10 фільмів
            Music[] numberOfMusic = new Music[10];                    // до 10 пісень

            int countFilm;                                            // кількість фільмів
            int countMusic;                                           // кількість пісень

            int menu;                                                 // вибір на головному меню
            int answer1;                                              // вибір в меню музика
            int answer2;                                              // вибір в меню фільми

            countFilm = getItemsFromFileFilm(PATH, numberOfFilm);     // отримати елементи з файлу та присвоїти countFilm
            countMusic = getItemsFromFileMusic(PATH2, numberOfMusic);

            if(countFilm == -1 && countMusic == -2)
            {
                Console.Write("Помилка. Не вдалося відкрити файл 'Фільм.txt'.");
                Console.Write("\nПомилка. Не вдалося відкрити файл 'Музика.txt'.");
                Console.ReadKey();
            }
            else if (countFilm == -1 && countMusic != -2)
            {
                Console.Write("Помилка. Не вдалося відкрити файл 'Фільм.txt'.");
                Console.ReadKey();
            }
            else if (countMusic == -2 && countFilm != -1)
            {
                Console.Write("Помилка. Не вдалося відкрити файл 'Музика.txt'.");
                Console.ReadKey();
            }
            else if(countFilm != -1 && countMusic != -2)
            {
                do
                {
                    showTheMainMenu();                                    // виведення головного меню на екран
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 0:                                           // збереження даних
                            saveItemsToFileFilm(numberOfFilm, countFilm, PATH);
                            saveItemsToFileMusic(numberOfMusic, countMusic, PATH2);
                            break;
                        // Музика
                        case 1:
                            showMusicMenu();                                        // виведення меню фільми на екран
                            answer1 = int.Parse(Console.ReadLine());
                            switch (answer1)
                            {
                                case 0:
                                    saveItemsToFileMusic(numberOfMusic, countMusic, PATH2);
                                    return;
                                case 1:
                                    Console.Clear();
                                    Console.Write("");

                                    if (countMusic == 0)
                                    {
                                        Console.Write("Помилка. Пісні не знайдено!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        printItemsMusic(numberOfMusic, countMusic);
                                        Console.Write("\tНатисніть Enter, щоб продовжити!");
                                        Console.ReadKey();          // пауза
                                    }
                                    continue;
                                case 2:
                                    Console.Clear();
                                    Console.Write("\n");
                                    Console.Write("\n");
                                    countMusic = addItemsMusic(numberOfMusic, countMusic);
                                    break;
                                case 3:
                                    Console.Clear();
                                    if (countMusic == 0)
                                    {
                                        Console.Write("Помилка. Пісні не знайдено!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        getAListOfMusic(numberOfMusic, countMusic);

                                        Console.Write("\n\n\t\t\t\t\tВведіть виконавця(ів) пісні: ");
                                        string artistName = Console.ReadLine();

                                        if (printInfoForNameOfMusic(numberOfMusic, countMusic, artistName))
                                        {
                                            artistInfo(numberOfMusic, countMusic, artistName);
                                            Console.Write("\t\t\t\t\tНатисніть Enter, щоб продовжити");
                                        }
                                        else
                                        {
                                            Console.Write("\n\n\t\t\t\t\tПомилка, такого виконавця не знайдено!\n\n");
                                        }
                                        Console.ReadKey();
                                    }
                                    continue;
                                case 4:
                                    Console.Clear();
                                    if (countMusic == 0)
                                    {
                                        Console.Write("Помилка. Пісні не знайдено!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        printItemsMusic(numberOfMusic, countMusic);

                                        Console.Write("\tВведіть номер пісні яку хочете видалити: ");
                                        int delM = int.Parse(Console.ReadLine());

                                        if (printIdMusic(numberOfMusic, countMusic, delM))
                                        {
                                            countMusic = removalOfMusic(numberOfMusic, countMusic, delM);

                                            Console.Write("\n\tБажаєте переглянути пісні ? (1 / 0)  ");
                                            int revision = char.Parse(Console.ReadLine());

                                            if (revision == '1')
                                            {
                                                printItemsMusic(numberOfMusic, countMusic);
                                                Console.Write("\tНатисніть Enter, щоб продовжити");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Write("\n\t\t\t\t\t\t\t\tВи ввели невірний номер пісні\n\n");
                                            Console.ReadKey();
                                        }
                                    }
                                    continue;
                                case 5:
                                    Console.Clear();

                                    if (countMusic == 0)
                                    {
                                        Console.Write("Помилка. Пісні не знайдено!");
                                    }
                                    else
                                    {
                                        printItemsMusic(numberOfMusic, countMusic);

                                        Console.Write("\tВведіть номер пісні в якій хочете змінити ціну: ");
                                        int numberM = int.Parse(Console.ReadLine());
                                        if (printIdMusic(numberOfMusic, countMusic, numberM))
                                        {
                                            Console.Write("\tВведіть нову ціну: ");
                                            int editM = int.Parse(Console.ReadLine());

                                            editPriceOfMusic(numberOfMusic, countMusic, numberM, editM);

                                            Console.Write("\tЦіну змінено!");
                                        }
                                        else
                                        {
                                            Console.Write("\n\t\t\t\t\t\t\t\tВи ввели невірний номер \n\n");
                                        }
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 6:
                                    showMusicMenu();
                                    continue;
                                default:
                                    Console.Write("\n\t\t\t\t\t\t\t\tНевірно введений код операції.\n\n");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        // Фільми
                        case 2:
                            showFilmsMenu();                                        // виведення меню фільми на екран
                            answer2 = int.Parse(Console.ReadLine());
                            switch (answer2)
                            {
                                case 0:
                                    saveItemsToFileFilm(numberOfFilm, countFilm, PATH);
                                    return;
                                case 1:
                                    Console.Clear();            // очистка екрану
                                    Console.Write("");          // ентер

                                    if (countFilm == 0)
                                    {
                                        Console.Write("Помилка. Фільми не знайдено!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        printItemsFilm(numberOfFilm, countFilm);            // виведення елементів на екран
                                        Console.Write("\tНатисніть Enter, щоб продовжити!");
                                        Console.ReadKey();
                                    }
                                    continue;
                                case 2:
                                    Console.Clear();
                                    Console.Write("\n");
                                    Console.Write("\n");
                                    countFilm = addItemsFilm(numberOfFilm, countFilm);
                                    break;
                                case 3:
                                    Console.Clear();
                                    if (countFilm == 0)
                                    {
                                        Console.Write("Помилка. Фільми не знайдено!");
                                    }
                                    else
                                    {
                                        getAListOfFilm(numberOfFilm, countFilm);

                                        Console.Write("\t\t\t\t\tВведіть назву фільма: ");
                                        string filmTitle = Console.ReadLine();

                                        if (printInfoForNameOfFilm(numberOfFilm, countFilm, filmTitle))
                                        {
                                            filmInfoByName(numberOfFilm, countFilm, filmTitle);
                                            Console.Write("\t\t\t\t\tНатисніть Enter, щоб продовжити");
                                        }
                                        else
                                        {
                                            Console.Write("\t\t\t\t\tПомилка. Ви вказали невірну назву фільма");
                                        }
                                    }

                                    Console.ReadKey();
                                    continue;
                                case 4:
                                    Console.Clear();
                                    if (countFilm == 0)
                                    {
                                        Console.Write("Помилка. Фільми не знайдено!");
                                    }
                                    else
                                    {
                                        getAListOfFilmDirector(numberOfFilm, countFilm);

                                        Console.Write("\t\t\t\t\tВведіть прізвище та ім'я режисера: ");
                                        string director = Console.ReadLine();

                                        if (printInfoOfAllFilmDirectors(numberOfFilm, countFilm, director))
                                        {
                                            filmInfoByDirector(numberOfFilm, countFilm, director);
                                            Console.Write("\t\t\t\t\tНатисніть Enter, щоб продовжити");
                                        }
                                        else
                                        {
                                            Console.Write("\t\t\t\t\tПомилка. Ви вказали невірного режисера");
                                        }
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 5:
                                    Console.Clear();
                                    if (countFilm == 0)
                                    {
                                        Console.Write("Помилка. Фільма не знайдено!");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        printItemsFilm(numberOfFilm, countFilm);

                                        Console.Write("\tВведіть номер фільма який хочете видалити: ");
                                        int delF = int.Parse(Console.ReadLine());

                                        if (printIdFilm(numberOfFilm, countFilm, delF))
                                        {
                                            countFilm = removalOfFilm(numberOfFilm, countFilm, delF);

                                            Console.Write("\n\tБажаєте переглянути фільми ? (1 / 0)  ");
                                            int revision = char.Parse(Console.ReadLine());

                                            if (revision == '1')
                                            {
                                                printItemsFilm(numberOfFilm, countFilm);
                                                Console.Write("\tНатисніть Enter, щоб продовжити");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.Write("\n\t\t\t\t\t\t\t\tВи ввели невірний номер фільма\n\n");
                                            Console.ReadKey();
                                        }
                                    }
                                    continue;
                                case 6:
                                    Console.Clear();

                                    if (countFilm == 0)
                                    {
                                        Console.Write("Помилка. Фільма не знайдено!");
                                    }
                                    else
                                    {
                                        printItemsFilm(numberOfFilm, countFilm);

                                        Console.Write("\tВведіть номер фільма в якому хочете змінити ціну: ");
                                        int numberF = int.Parse(Console.ReadLine());
                                        if (printIdFilm(numberOfFilm, countFilm, numberF))
                                        {
                                            Console.Write("\tВведіть новий бюджет: ");
                                            int editF = int.Parse(Console.ReadLine());

                                            editPriceOfFilm(numberOfFilm, countFilm, numberF, editF);

                                            Console.Write("\tБюджет змінено!");
                                        }
                                        else
                                        {
                                            Console.Write("\n\t\t\t\t\t\t\t\tВи ввели невірний номер фільма\n\n");
                                        }
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 7:
                                    showFilmsMenu();
                                    continue;
                                default:
                                    Console.Write("\n\t\t\t\t\t\t\t\tНевірно введений код операції.\n\n");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        // Впорядкувати пісні за ціною зростання
                        case 3:
                            Console.Clear();
                            if (countMusic == 0)
                            {
                                Console.Write("Помилка. Пісні не знайдено!");
                            }
                            else
                            {
                                watchMusicsSortedByRasingPrice(numberOfMusic, countMusic);
                                Console.Write("\t\t\t\t\tНатисніть Enter, щоб продовжити");
                            }
                            Console.ReadKey();
                            continue;
                        // Впорядкувати фільми за ціною зростання
                        case 4:
                            Console.Clear();
                            if (countFilm == 0)
                            {
                                Console.Write("Помилка. Фільми не знайдено!");
                            }
                            else
                            {
                                watchMoviesSortedByRisingPrice(numberOfFilm, countFilm);
                                Console.Write("\t\t\t\t\tНатисніть Enter, щоб продовжити");
                            }
                            Console.ReadKey();
                            continue;
                        default:
                            Console.Write("\n\t\t\t\t\t\t\t\tНевірно введений код операції.\n\n");
                            Console.ReadKey();
                            break;
                    }
                } while (menu != 0);
            }
        }

        static void showTheMainMenu()
        {
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t\t\t ____________________________МЕНЮ_______________________________\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 1. Музика                                                 *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 2. Фільми                                                 *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 3. Впорядкувати пісні за ціною зростання                  *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 4. Впорядкувати фільми за ціною зростання                 *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 0. Зберегти та вийти з системи                            *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |*___________________________________________________________*|\n");

            Console.Write("\n\t\t\t\t\t\t\tЗробіть свій вибір >>> ");
        }

        static void showMusicMenu()
        {
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t\t\t ___________________________Музика______________________________\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 1. Вивести всі пісні                                      *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 2. Додати пісню                                           *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 3. Пошук пісні вказаного виконавця                        *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 4. Видалити пісню                                         *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 5. Редагувати ціну пісні                                  *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 6. Повернутися до головного меню                          *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 0. Зберегти та вийти з системи                            *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |*___________________________________________________________*|\n");

            Console.Write("\n\t\t\t\t\t\t\tЗробіть свій вибір >>> ");
        }

        static void showFilmsMenu()
        {
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t\t\t ___________________________Фільми______________________________\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 1. Вивести всі фільми                                     *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 2. Додати фільм                                           *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 3. Пошук фільму за назвою                                 *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 4. Пошук фільму вказаного режисера                        *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 5. Видалити фільм                                         *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 6. Редагувати бюджет фільму                               *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 7. Повернутися до головного меню                          *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |* 0. Зберегти та вийти з системи                            *|\n");
            Console.WriteLine("\t\t\t\t\t\t\t |*___________________________________________________________*|\n");

            Console.Write("\n\t\t\t\t\t\t\tЗробіть свій вибір >>> ");
        }

        // Музика
        static Music getItemFromStrMusic(string path2)
        {
            Music music = new Music();

            string text = path2;
            char[] delimiterChars = { '|' };

            string[] words = text.Split(delimiterChars);

            for (int i = 0; i < 1; i++)
            {
                music.Id = int.Parse(words[0]);
                music.Name = words[1];
                music.Composer = words[2];
                music.Executor = words[3];
                music.Duration = words[4];
                music.RecordingFormat = words[5];
                music.YearOfRelease = int.Parse(words[6]);
                music.Cost = int.Parse(words[7]);
            }

            return music;
        }

        static int getItemsFromFileMusic(string path2, Music[] arr)
        {
            int a = 0;
            string linem;

            if (!File.Exists(path2))
            {
                return -2;
            }

            StreamReader finm = new StreamReader(path2, Encoding.Default);

            using (finm)
            {
                while ((linem = finm.ReadLine()) != null)
                {
                    arr[a] = getItemFromStrMusic(linem);
                    a++;
                }
            }

            finm.Close();
            return a;
        }

        static void saveItemsToFileMusic(Music[] arr, int a, string path2)
        {
            string text = "";

            using (StreamWriter mus = new StreamWriter(path2, true, Encoding.Default))
            {
                mus.WriteLine(text);
                mus.Close();
            }
            using (StreamWriter mus2 = new StreamWriter(path2, false, Encoding.Default))
            {
                for (int i = 0; i < a; i++)
                {
                    mus2.Write(arr[i].Id + "|" + arr[i].Name + "|" + arr[i].Composer + "|" +
                               arr[i].Executor + "|" + arr[i].Duration + "|" + arr[i].RecordingFormat + "|" +
                               arr[i].YearOfRelease + "|" + arr[i].Cost + "\n");
                }
                mus2.Close();
            }
        }

        static int addItemsMusic(Music[] arr, int a)
        {
            char answer;
            string name, composer, executor, duration, recordingFormat;
            int id, yearOfRelease, cost;

            do
            {
                id = a + 1;

                Console.Write("\n\t\t\t\t\t\t\tВведіть назву пісні: ");
                name = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть автора(ів) пісні: ");
                composer = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть виконавця(ів) пісні: ");
                executor = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть тривалість пісні (ХХ:СС): ");
                duration = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть формат запису: ");
                recordingFormat = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть рік випуску пісні: ");
                yearOfRelease = int.Parse(Console.ReadLine());

                Console.Write("\n\t\t\t\t\t\t\tВведіть ціну пісні: ");
                cost = int.Parse(Console.ReadLine());

                Music music = new Music(id, name, composer, executor, duration, recordingFormat, yearOfRelease, cost);

                arr[a] = music;
                a++;

                Console.Write("\n\t\t\t\t\t\tДані збережено! Бажаєте додати ще пісню? (y/n)  ");
                answer = char.Parse(Console.ReadLine());
            } while (answer != 'n');

            return a;
        }

        static void printItemsMusic(Music[] arr, int a)
        {
            Console.WriteLine("\n\n\t|----------------------------------------------------------" +
                "---------------------------------------------------------------------------" +
                "-----------------------------------------------------------------|\n");

            Console.Write("\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,18:D}", "Назва пісні");
            Console.Write("{0,8:D}", "|");

            Console.Write("{0,27:D}", "Автор(и)");
            Console.Write("{0,20:D}", "|");

            Console.Write("{0,22:D}", "Виконавець(ці)");
            Console.Write("{0,9:D}", "|");

            Console.Write("{0,14:D}", "Тривалість");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,17:D}", "Формат запису");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,15:D}", "Рік випуску");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,23:D}", "Вартість (тис, грн)");
            Console.Write("{0,7:D}", "|\n\n");

            Console.WriteLine("\t|----------------------------------------------------------" +
                "---------------------------------------------------------------------------" +
                "-----------------------------------------------------------------|\n");

            for (int i = 0; i < a; i++)
            {
                Console.Write("\t|{0,3:D}", arr[i].Id);
                Console.Write("{0,3:D}", "|");

                Console.Write("{0,21:D}", arr[i].Name);
                Console.Write("{0,5:D}", "|");

                Console.Write("{0,37:D}", arr[i].Composer);
                Console.Write("{0,10:D}", "|");

                Console.Write("{0,25:D}", arr[i].Executor);
                Console.Write("{0,6:D}", "|");

                Console.Write("{0,11:D}", arr[i].Duration);
                Console.Write("{0,8:D}", "|");

                Console.Write("{0,13:D}", arr[i].RecordingFormat.ToUpper());
                Console.Write("{0,9:D}", "|");

                Console.Write("{0,11:D}", arr[i].YearOfRelease);
                Console.Write("{0,9:D}", "|");

                Console.Write("{0,15:D}", arr[i].Cost);
                Console.Write("{0,15:D}", "|\n\n");
            }    
            
            Console.WriteLine("\t|----------------------------------------------------------" +
                "---------------------------------------------------------------------------" +
                "-----------------------------------------------------------------|\n\n");
        }

        static void getAListOfMusic(Music[] arr, int a)
        {
            Console.WriteLine("\n\n\n\n");
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("\t\t\t\t\t" + arr[i].Id + ". " + arr[i].Executor);

            }
        }

        static bool printInfoForNameOfMusic(Music[] arr, int a, string executor)
        {
            bool flagM = false;

            for (int i = 0; i < a; i++)
            {
                if (arr[i].Executor == executor)
                {
                    flagM = true;
                }
            }
            return flagM;
        }

        static void artistInfo(Music[] arr, int a, string executor)
        {
            Console.WriteLine("\n\n\t\t\t\t\t|----------------------------------------------------------" +
                "-----------------------------------------|\n");

            Console.Write("\t\t\t\t\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,18:D}", "Назва пісні");
            Console.Write("{0,8:D}", "|");

            Console.Write("{0,22:D}", "Виконавець(ці)");
            Console.Write("{0,9:D}", "|");

            Console.Write("{0,14:D}", "Тривалість");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,14:D}", "Рік випуску");
            Console.Write("{0,5:D}", "|\n");

            Console.WriteLine("\n\t\t\t\t\t|----------------------------------------------------------" +
                "-----------------------------------------|\n");

            for (int i = 0; i < a; i++)
            {
                if (arr[i].Executor == executor)
                {
                    Console.Write("\t\t\t\t\t|{0,3:D}", arr[i].Id);
                    Console.Write("{0,3:D}", "|");

                    Console.Write("{0,21:D}", arr[i].Name);
                    Console.Write("{0,5:D}", "|");

                    Console.Write("{0,25:D}", arr[i].Executor);
                    Console.Write("{0,6:D}", "|");

                    Console.Write("{0,11:D}", arr[i].Duration);
                    Console.Write("{0,8:D}", "|");

                    Console.Write("{0,11:D}", arr[i].YearOfRelease);
                    Console.Write("{0,9:D}", "|\n\n");
                }
            }

            Console.WriteLine("\t\t\t\t\t|----------------------------------------------------------" +
                "-----------------------------------------|\n");
        }

        static bool printIdMusic(Music[] arr, int a, int id)
        {
            bool flagId = false;

            for (int i = 0; i < a; i++)
            {
                if (arr[i].Id == id)
                {
                    flagId = true;
                }
            }
            return flagId;
        }

        static int removalOfMusic(Music[] arr, int a, int del)
        {
            for (int i = del - 1; i < a - 1; i++)
            {
                arr[i] = arr[i + 1];
                arr[i].Id--;
            }

            return a-1;
        }

        static void watchMusicsSortedByRasingPrice(Music[] arr, int a)
        {

            string name, composer, executor, duration, recordingFormat;
            int yearOfRelease, cost;

            // сортування за зростанням
            for (int i = 0; i < a; i++)
            {
                for (int j = i + 1; j < a; j++)
                {
                    if (arr[i].Cost > arr[j].Cost)
                    {
                        name = arr[i].Name;
                        arr[i].Name = arr[j].Name;
                        arr[j].Name = name;

                        composer = arr[i].Composer;
                        arr[i].Composer = arr[j].Composer;
                        arr[j].Composer = composer;

                        executor = arr[i].Executor;
                        arr[i].Executor = arr[j].Executor;
                        arr[j].Executor = executor;

                        duration = arr[i].Duration;
                        arr[i].Duration = arr[j].Duration;
                        arr[j].Duration = duration;

                        recordingFormat = arr[i].RecordingFormat;
                        arr[i].RecordingFormat = arr[j].RecordingFormat;
                        arr[j].RecordingFormat = recordingFormat;

                        yearOfRelease = arr[i].YearOfRelease;
                        arr[i].YearOfRelease = arr[j].YearOfRelease;
                        arr[j].YearOfRelease = yearOfRelease;

                        cost = arr[i].Cost;
                        arr[i].Cost = arr[j].Cost;
                        arr[j].Cost = cost;
                    }
                }
            }

            Console.WriteLine("\n\n\t\t\t\t\t|------------------------------------------------------------|");

            Console.Write("\t\t\t\t\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,18:D}", "Назва пісні");
            Console.Write("{0,8:D}", "|");

            Console.Write("{0,23:D}", "Вартість (тис, грн)");
            Console.Write("{0,6:D}", "|");

            Console.WriteLine("\n\t\t\t\t\t|------------------------------------------------------------|");

            for (int i = 0; i < a; i++)
            {
                Console.Write("\t\t\t\t\t|{0,3:D}", arr[i].Id);
                Console.Write("{0,3:D}", "|");

                Console.Write("{0,21:D}", arr[i].Name);
                Console.Write("{0,5:D}", "|");

                Console.Write("{0,15:D}", arr[i].Cost);
                Console.Write("{0,15:D}", "|\n");
            }

            Console.WriteLine("\t\t\t\t\t|------------------------------------------------------------|\n");
        }

        static void editPriceOfMusic(Music[] arr, int a, int id, int price)
        {
            for (int i = 0; i < a; i++)
            {
                if (arr[i].Id == id)
                {
                    arr[i].Cost = price;
                    break;
                }
            }
        }


        // Фільми
        static Film getItemFromStrFilm(string path)
        {
            Film film = new Film();

            string text = path;                             //Console.WriteLine($"Original text: '{text}'");
            char[] delimiterChars = { '|' };

            string[] words = text.Split(delimiterChars);

            for(int i = 0; i < 1; i++)
            {
                // Console.WriteLine(word);
                film.Id = int.Parse(words[0]);
                film.Name = words[1];
                film.FilmDirector = words[2];
                film.Actor = words[3];
                film.RecordingFormat = words[4];
                film.YearOfRelease = int.Parse(words[5]);
                film.Cost = int.Parse(words[6]);
            }

            return film;
        }
        
        static int getItemsFromFileFilm(string path, Film[] mas)
        {
            int m = 0;                  // повертає кількість рядків
            string line;                // рядок фільмів

            if (!File.Exists(path))     // якщо не вдалося відкрити файл
            {
                return -1;
            }

            StreamReader fin = new StreamReader(path, Encoding.Default);

            using (fin)
            {
                while ((line = fin.ReadLine()) != null)
                {
                    mas[m] = getItemFromStrFilm(line);
                    m++;
                }
            }

            fin.Close();
            return m;
        }

        static void saveItemsToFileFilm(Film[] mas, int m, string path)
        {
            // для дозапису
            string text = "";

            using (StreamWriter sw1 = new StreamWriter(path, true, Encoding.Default))
            {
                sw1.WriteLine(text);
                sw1.Close();
            }
            using (StreamWriter sw2 = new StreamWriter(path, false, Encoding.Default))
            {
                for (int i = 0; i < m; i++)
                {
                    sw2.Write(mas[i].Id + "|" + mas[i].Name + "|" +
                                      mas[i].FilmDirector + "|" + mas[i].Actor + "|" +
                                      mas[i].RecordingFormat + "|" + mas[i].YearOfRelease + "|" + mas[i].Cost + "\n");
                }
                sw2.Close();
            }
        }
        
        static int addItemsFilm(Film[] mas, int m)
        {
            char choice;
            string name, filmDirector, actor, recordingFormat;
            int id, yearOfRelease, cost;

            do
            {
                id = m + 1;
                
                Console.Write("\n\t\t\t\t\t\t\tВведіть назву фільму: ");
                name = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть прізвище та ім'я режисера фільму: ");
                filmDirector = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть прізвище та ім'я головного актора: ");
                actor = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть формат запису: ");
                recordingFormat = Console.ReadLine();

                Console.Write("\n\t\t\t\t\t\t\tВведіть рік випуску фільму: ");
                yearOfRelease = int.Parse(Console.ReadLine());

                Console.Write("\n\t\t\t\t\t\t\tВведіть бюджет фільму: ");
                cost = int.Parse(Console.ReadLine());

                
                Film film = new Film(id, name, filmDirector, actor, recordingFormat, yearOfRelease, cost);

                mas[m] = film;
                m++;

                Console.Write("\n\t\t\t\t\t\tДані збережено! Бажаєте додати ще фільм? (y/n)  ");
                choice = char.Parse(Console.ReadLine());
            } while (choice != 'n');

            return m;       // повертає кількість рядків
        }

        static void printItemsFilm(Film[] mas, int m)
        {
            Console.WriteLine("\n\n\t|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\n");

            Console.Write("\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,28:D}", "Назва фільма");
            Console.Write("{0,17:D}", "|");

            Console.Write("{0,13:D}", "Режисер");
            Console.Write("{0,7:D}", "|");

            Console.Write("{0,25:D}", "Актор на головну роль");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,17:D}", "Формат запису");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,15:D}", "Рік випуску");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,21:D}", "Вартість (млн, $)");
            Console.Write("{0,7:D}", "|\n\n");

            Console.WriteLine("\t|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\n");

            for (int i = 0; i < m; i++)
            {
                Console.Write("\t|{0,3:D}", mas[i].Id);
                Console.Write("{0,3:D}", "|");

                Console.Write("{0,40:D}", mas[i].Name);
                Console.Write("{0,5:D}", "|");

                Console.Write("{0,15:D}", mas[i].FilmDirector);
                Console.Write("{0,5:D}", "|");

                Console.Write("{0,23:D}", mas[i].Actor);
                Console.Write("{0,7:D}", "|");

                Console.Write("{0,13:D}", mas[i].RecordingFormat.ToUpper());
                Console.Write("{0,9:D}", "|");
                
                Console.Write("{0,11:D}", mas[i].YearOfRelease);
                Console.Write("{0,9:D}", "|");

                Console.Write("{0,14:D}", mas[i].Cost);
                Console.Write("{0,14:D}", "|\n\n");
            }
            Console.WriteLine("\t|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\n\n");
        }

        static void getAListOfFilm(Film[] mas, int m)
        {
            Console.WriteLine("\n\n\n\n\t\t\t\t\t---------------------------------------");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("\t\t\t\t\t" + mas[i].Id + ". " + mas[i].Name);
            }
            Console.WriteLine("\t\t\t\t\t---------------------------------------\n");
        }

        static bool printInfoForNameOfFilm(Film[] mas, int m, string name)
        {
            bool flag2 = false;

            for (int i = 0; i < m; i++)
            {
                if (mas[i].Name == name)
                {
                    flag2 = true;
                }
            }
            return flag2;
        }

        static void filmInfoByName(Film[] mas, int m, string name)
        {
            Console.WriteLine("\n\n\t\t\t\t\t|-------------------------------------------------" +
                "------------------------------------------------------------------------|\n");

            Console.Write("\t\t\t\t\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,28:D}", "Назва фільма");
            Console.Write("{0,17:D}", "|");

            Console.Write("{0,25:D}", "Актор на головну роль");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,17:D}", "Формат запису");
            Console.Write("{0,5:D}", "|");

            Console.Write("{0,15:D}", "Рік випуску");
            Console.Write("{0,5:D}", "|\n");

            Console.WriteLine("\n\t\t\t\t\t|---------------------------------------------------" +
                "----------------------------------------------------------------------|\n");

            for (int i = 0; i < m; i++)
            {
                if (mas[i].Name == name)
                {
                    Console.Write("\t\t\t\t\t|{0,3:D}", mas[i].Id);
                    Console.Write("{0,3:D}", "|");

                    Console.Write("{0,40:D}", mas[i].Name);
                    Console.Write("{0,5:D}", "|");

                    Console.Write("{0,23:D}", mas[i].Actor);
                    Console.Write("{0,7:D}", "|");

                    Console.Write("{0,13:D}", mas[i].RecordingFormat.ToUpper());
                    Console.Write("{0,9:D}", "|");

                    Console.Write("{0,11:D}", mas[i].YearOfRelease);
                    Console.Write("{0,9:D}", "|\n");
                }
            }
            Console.WriteLine("\n\t\t\t\t\t|-----------------------------------------------------" +
                "--------------------------------------------------------------------|\n\n");
        }

        static void getAListOfFilmDirector(Film[] mas, int m)
        {
            Console.WriteLine("\n\n\n\n\t\t\t\t\t---------------------------------------");
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("\t\t\t\t\t" + mas[i].Id + ". " + mas[i].FilmDirector);
            }
            Console.WriteLine("\t\t\t\t\t---------------------------------------\n");
        }

        static bool printInfoOfAllFilmDirectors(Film[] mas, int m, string director)
        {
            bool flag2 = false;

            for (int i = 0; i < m; i++)
            {
                if (mas[i].FilmDirector == director)
                {
                    flag2 = true;
                }
            }
            return flag2;
        }
        
        static void filmInfoByDirector(Film[] mas, int m, string director)
        {
            Console.WriteLine("\n\n\t\t\t\t\t|-----------------------------------------------------------------------------------------|\n");

            Console.Write("\t\t\t\t\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,13:D}", "Режисер");
            Console.Write("{0,7:D}", "|");

            Console.Write("{0,28:D}", "Назва фільма");
            Console.Write("{0,17:D}", "|");

            Console.Write("{0,15:D}", "Рік випуску");
            Console.Write("{0,5:D}", "|\n");

            Console.WriteLine("\n\t\t\t\t\t|-----------------------------------------------------------------------------------------|\n");

            for (int i = 0; i < m; i++)
            {
                if (mas[i].FilmDirector == director)
                {
                    Console.Write("\t\t\t\t\t|{0,3:D}", mas[i].Id);
                    Console.Write("{0,3:D}", "|");

                    Console.Write("{0,15:D}", mas[i].FilmDirector);
                    Console.Write("{0,5:D}", "|");

                    Console.Write("{0,40:D}", mas[i].Name);
                    Console.Write("{0,5:D}", "|");

                    Console.Write("{0,11:D}", mas[i].YearOfRelease);
                    Console.Write("{0,9:D}", "|\n");
                }
            }
            Console.WriteLine("\n\t\t\t\t\t|-----------------------------------------------------------------------------------------|\n\n");
        }

        static void watchMoviesSortedByRisingPrice(Film[] mas, int m)
        {
            string name, filmDirector, actor, recordingFormat;
            int yearOfRelease, cost;

            // сортування за зростанням
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (mas[i].Cost > mas[j].Cost)
                    {
                        name = mas[i].Name;
                        mas[i].Name = mas[j].Name;
                        mas[j].Name = name;

                        filmDirector = mas[i].FilmDirector;
                        mas[i].FilmDirector = mas[j].FilmDirector;
                        mas[j].FilmDirector = filmDirector;

                        actor = mas[i].Actor;
                        mas[i].Actor = mas[j].Actor;
                        mas[j].Actor = actor;

                        recordingFormat = mas[i].RecordingFormat;
                        mas[i].RecordingFormat = mas[j].RecordingFormat;
                        mas[j].RecordingFormat = recordingFormat;

                        yearOfRelease = mas[i].YearOfRelease;
                        mas[i].YearOfRelease = mas[j].YearOfRelease;
                        mas[j].YearOfRelease = yearOfRelease;

                        cost = mas[i].Cost;
                        mas[i].Cost = mas[j].Cost;
                        mas[j].Cost = cost;
                    }
                }
            }

            Console.WriteLine("\n\n\t\t\t\t\t|-----------------------------------------------------------------------------|");

            Console.Write("\t\t\t\t\t|{0,3:D}", "№");
            Console.Write("{0,3:D}", "|");

            Console.Write("{0,28:D}", "Назва фільма");
            Console.Write("{0,17:D}", "|");

            Console.Write("{0,21:D}", "Вартість (млн, $)");
            Console.Write("{0,6:D}", "|");

            Console.WriteLine("\n\t\t\t\t\t|-----------------------------------------------------------------------------|");

            for (int i = 0; i < m; i++)
            {
                Console.Write("\t\t\t\t\t|{0,3:D}", mas[i].Id);
                Console.Write("{0,3:D}", "|");

                Console.Write("{0,40:D}", mas[i].Name);
                Console.Write("{0,5:D}", "|");

                Console.Write("{0,14:D}", mas[i].Cost);
                Console.Write("{0,14:D}", "|\n");
            }
            Console.WriteLine("\t\t\t\t\t|-----------------------------------------------------------------------------|\n\n");
        }

        static bool printIdFilm(Film[] mas, int m, int id)
        {
            bool flagId = false;

            for (int i = 0; i < m; i++)
            {
                if (mas[i].Id == id)
                {
                    flagId = true;
                }
            }
            return flagId;
        }

        static int removalOfFilm(Film[] mas, int m, int del)
        {
            for (int i = del - 1; i < m - 1; i++)
            {
                mas[i] = mas[i + 1];
                mas[i].Id--;
            }

            return m - 1;
        }
    
        static void editPriceOfFilm(Film[] mas, int m, int id, int price)
        {
            for(int i = 0; i < m; i++)
            {
                if(mas[i].Id == id)
                {
                    mas[i].Cost = price;
                    break;
                }
            }
        }
    }
}