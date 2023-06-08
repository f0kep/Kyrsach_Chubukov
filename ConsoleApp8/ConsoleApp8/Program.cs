using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CW_Chubukov
{
    public struct ProjectInfo
    {
        public string NumberGrop;
        public string FirstName;
        public string MiddleName;
        public string SecondName;
        public int Firstсredits;
        public int Secondсredits;
        public int Thirdсredits;
        public int Fourthсredits;
        public int Fifthсredits;
        public double Firstexam;
        public double Secondexam;
        public double Thirdexam;
        public double Fourthexam;
        public double Fifthexam;
    }
    public class Program
    {
        private static bool IsUser = false;
        private static bool IsAdmin = false;
        public static int arraySize = 0;
        static bool IsProgramRunning = true;
        static string projectsListPath = "ProjectsList.txt";
        public static ProjectInfo[] projects = new ProjectInfo[999];
        public enum MenuChoice
        {
            LoginAsUser = 1,
            LoginAsAdmin = 2,
        }


        public enum AdminOps
        {
            ShowAllStudents = 1,
            ShowIndividualTaskFirstPart = 2,
            ShowIndividualTaskSecondPart = 3,
            Sort = 4,
            AddStudent = 5,
            EditStudents = 6,
            DeleteStudent = 7,
            ClearConsole = 8,
            CloseApps = 9,
        }

        public enum UserOps
        {
            ShowAllStudents = 1,
            ShowIndividualTaskFirstPart = 2,
            ShowIndividualTaskSecondPart = 3,
            Sort = 4,
            ClearConsole = 5,
            CloseApp = 6,
        }

        public enum SortProcessing
        {
            DesreasingSortCredits = 1,
            SortingAverageScore = 2,
            Alphabet = 3,
            SearchStudentsByGrope = 4,
            // = 5,
        }

        static void Main(string[] args)
        {
            LoadStudentsList(projects);
            PrintLoginMenu();
            while (IsProgramRunning)
            {
                if (IsUser == true)
                {
                    PrintUserMenu();
                    int userInput;
                    Console.WriteLine("Номер операции: ");
                    while (!int.TryParse(Console.ReadLine(), out userInput)
                   || userInput <= 0 || userInput > 6)
                    {
                        Console.WriteLine("Введено некорректное значение!");
                    }
                    switch ((UserOps)userInput)
                    {
                        case UserOps.ShowAllStudents:
                            PrintAllStudents();//работает
                            break;
                        case UserOps.ShowIndividualTaskFirstPart:
                            IndividualTaskFirstPart(projects);//работает
                            break;
                        case UserOps.ShowIndividualTaskSecondPart:
                            IndividualTaskSecondPart(projects);//работает
                            break;
                        case UserOps.Sort:
                            SortMenu();
                            break;
                        case UserOps.ClearConsole:
                            Console.Clear();//работает
                            break;
                        case UserOps.CloseApp:
                            SaveProjectsList();//работает
                            IsProgramRunning = false;
                            break;
                        default:
                            Console.WriteLine("Введено некорректное значение!");
                            break;
                    }
                }
                else if (IsAdmin == true)
                {
                    PrintAdminMenu();
                    int userInput;
                    Console.WriteLine("Номер операции: ");
                    while (!int.TryParse(Console.ReadLine(), out userInput)
                   || userInput <= 0 || userInput > 9)
                    {
                        Console.WriteLine("Введено некорректное значение!");
                    }
                    switch ((AdminOps)userInput)
                    {
                        case AdminOps.ShowAllStudents:
                            PrintAllStudents();
                            break;
                        case AdminOps.ShowIndividualTaskFirstPart:
                            IndividualTaskFirstPart(projects);
                            break;
                        case AdminOps.ShowIndividualTaskSecondPart:
                            IndividualTaskSecondPart(projects);
                            break;
                        case AdminOps.Sort:
                            SortMenu();
                            break;
                        case AdminOps.AddStudent:
                            AddStudent();
                            break;
                        case AdminOps.EditStudents:
                            EditStudents(); 
                            break;
                        case AdminOps.DeleteStudent:
                            DeleteStudent();
                            break;
                        case AdminOps.ClearConsole:
                            Console.Clear();
                            break;
                        case AdminOps.CloseApps:
                            SaveProjectsList();
                            IsProgramRunning = false;
                            break;
                        default:
                            Console.WriteLine("Введено некорректное значение!");
                            break;
                    }
                }
            }
        }
        public static void AddStudent()
        {
            string numbergroop;
            Console.WriteLine("Введите номер группы: ");
            numbergroop = Console.ReadLine();
            projects[arraySize].NumberGrop = numbergroop;
            string firstName;
            Console.WriteLine("Введите имя: ");
            firstName = Console.ReadLine();
            projects[arraySize].FirstName = firstName;
            string middleName;
            Console.WriteLine("Введите фамилию: ");
            middleName = Console.ReadLine();
            projects[arraySize].MiddleName = middleName;
            string secondName;
            Console.WriteLine("Введите отчество: ");
            secondName = Console.ReadLine();
            projects[arraySize].SecondName = secondName;

            int firstcredit;
            Console.WriteLine("Введиете сведения о зачете 1 (0 - Зачтенно, 1 - Незачтенно) : ");
            while (!int.TryParse(Console.ReadLine(), out firstcredit) || firstcredit < 0 || firstcredit > 1)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Firstсredits = firstcredit;

            int secondcredit;
            Console.WriteLine("Введиете сведения о зачете 2 (0 - Зачтенно, 1 - Незачтенно) : ");
            while (!int.TryParse(Console.ReadLine(), out secondcredit) || secondcredit < 0 || secondcredit > 1)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Secondсredits = secondcredit;

            int thirdcredit;
            Console.WriteLine("Введиете сведения о зачете 3 (0 - Зачтенно, 1 - Незачтенно) : ");
            while (!int.TryParse(Console.ReadLine(), out thirdcredit) || thirdcredit < 0 || thirdcredit > 1)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Thirdсredits = thirdcredit;

            int fourthcredit;
            Console.WriteLine("Введиете сведения о зачете 4 (0 - Зачтенно, 1 - Незачтенно) : ");
            while (!int.TryParse(Console.ReadLine(), out fourthcredit) || fourthcredit < 0 || fourthcredit > 1)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Fourthсredits = fourthcredit;

            int fifthcredit;
            Console.WriteLine("Введиете сведения о зачете 5 (0 - Зачтенно, 1 - Незачтенно) : ");
            while (!int.TryParse(Console.ReadLine(), out fifthcredit) || fifthcredit < 0 || fifthcredit > 1)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Fifthсredits = fifthcredit;

            double firstexam;
            Console.WriteLine("Введиете оценку за экзамен 1 : ");
            while (!double.TryParse(Console.ReadLine(), out firstexam) || firstexam < 0 || firstexam > 5)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Firstexam = firstexam;

            double secondexam;
            Console.WriteLine("Введиете оценку за экзамен 2 : ");
            while (!double.TryParse(Console.ReadLine(), out secondexam) || secondexam < 0 || secondexam > 5)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Secondexam = secondexam;

            double thirdexam;
            Console.WriteLine("Введиете оценку за экзамен 3 : ");
            while (!double.TryParse(Console.ReadLine(), out thirdexam) || thirdexam < 0 || thirdexam > 5)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Thirdexam = thirdexam;

            double fourthexam;
            Console.WriteLine("Введиете оценку за экзамен 4 : ");
            while (!double.TryParse(Console.ReadLine(), out fourthexam) || fourthexam < 0 || fourthexam > 5)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Fourthexam = fourthexam;

            double fifthexam;
            Console.WriteLine("Введиете оценку за экзамен 5 : ");
            while (!double.TryParse(Console.ReadLine(), out fifthexam) || fifthexam < 0 || fifthexam > 5)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            projects[arraySize].Fifthexam = fifthexam;
            arraySize++;
        }
        public static void DeleteStudent()
        {
            Console.WriteLine("Введите номер студента: ");
            int identifier;
            while (!int.TryParse(Console.ReadLine(), out identifier) || identifier < 0 || identifier > arraySize - 1)
            {
                Console.WriteLine("Некорректный ввод!");
            }
            for (int i = identifier - 1; i < arraySize - 1; i++)
            {
                identifier = i;
                projects[i].NumberGrop = projects[i + 1].NumberGrop;
                projects[i].FirstName = projects[i + 1].FirstName;
                projects[i].MiddleName = projects[i + 1].MiddleName;
                projects[i].SecondName = projects[i + 1].SecondName;
                projects[i].Firstсredits = projects[i + 1].Firstсredits;
                projects[i].Secondсredits = projects[i + 1].Secondсredits;
                projects[i].Thirdсredits = projects[i + 1].Thirdсredits;
                projects[i].Fourthсredits = projects[i + 1].Fourthсredits;
                projects[i].Fifthсredits = projects[i + 1].Fifthсredits;
                projects[i].Fifthexam = projects[i + 1].Fifthexam;
                projects[i].Secondexam = projects[i + 1].Secondexam;
                projects[i].Thirdexam = projects[i + 1].Thirdexam;
                projects[i].Fourthexam = projects[i + 1].Fourthexam;
                projects[i].Fifthexam = projects[i + 1].Fifthexam;

            }
            arraySize--;
        }
        public static void PrintLoginMenu()
        {
            Console.WriteLine("Вход:"
            + "\n1.) Войти от имени пользователя"
            + "\n2.) Войти от имени администратора");
            int userChoice;
            Console.WriteLine("Для выбора операции введите её номер: ");
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Некорректный ввод!");
            }
            switch ((MenuChoice)userChoice)
            {
                case MenuChoice.LoginAsUser:
                    LoginAsUser();
                    break;
                case MenuChoice.LoginAsAdmin:
                    LoginAsAdmin();
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
        public static void PrintUserMenu()
        {
            Console.WriteLine("Меню пользователя:"
            + "\n1.) Вывод списка всех студентов"
            + "\n2.) Индивидуальное задание(1)"
            + "\n3.) Индивидуальное задание(2)"
            + "\n4.) Меню сортировки и поиска"
            + "\n5.) Очистить консоль"
            + "\n6.) Закрыть приложение");
        }
        public static void PrintAdminMenu()
        {
            Console.WriteLine("Меню администратора:"
            + "\n1.) Вывод списка всех студентов"
            + "\n2.) Индивидуальное задание(1)"
            + "\n3.) Индивидуальное задание(2)"
            + "\n4.) Меню сортировки и поиска" 
            + "\n5.) Добавить студента"
            + "\n6.) Редактировать данные о студенте"
            + "\n7.) Удалить студента"
            + "\n8.) Очистить консоль"
            + "\n9.) Закрыть приложение");
        }
        public static void SortMenu()
        {
            Console.WriteLine("Вход:"
            + "\n1.) Сортировать по убыванию задолжностей"
            + "\n2.) Сортировать по среднему баллу"
            + "\n3.) Сортировать по алфавиту"
            + "\n4.) Поиск студентов по группе");

            int userChoice;
            Console.WriteLine("Для выбора операции введите её номер: ");
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Некорректный ввод!");
            }
            switch ((SortProcessing)userChoice)
            {
                case SortProcessing.DesreasingSortCredits:
                    DesreasingSort(projects);
                    break;
                case SortProcessing.SortingAverageScore:
                    SortAverageExams(projects);
                    break;
                case SortProcessing.Alphabet:
                    AlphaSort(projects);
                    break;
                case SortProcessing.SearchStudentsByGrope:
                    GroopSearch(projects);
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }


        public static void LoginAsUser()
        {
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            int countOfAttempts = 3;
            for (int i = 1; i < 4; i++)
            {
                if (password == "user")
                {
                    IsUser = true;
                    Console.WriteLine("Вы вошли от имени пользователя!");
                    break;
                }
                else if (i == 4)
                {
                    PrintLoginMenu();
                }
                else
                {
                    Console.WriteLine($"Пароль введён неверно! У вас осталось {countOfAttempts} попытки!");
                    password = Console.ReadLine();
                    countOfAttempts--;
                }
            }
        }
        public static void LoginAsAdmin()
        {
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            int countOfAttempts = 3;
            for (int i = 1; i <= 4; i++)
            {
                if (password == "admin")
                {
                    IsAdmin = true;
                    Console.WriteLine("Вы вошли от имени администратора!");
                    break;
                }
                else if (i == 4)
                {
                    PrintLoginMenu();
                }
                else
                {
                    Console.WriteLine($"Пароль введён неверно! У вас осталось {countOfAttempts} попытки!");
                    password = Console.ReadLine();
                    countOfAttempts--;
                }
            }
        }
        public static void LoadStudentsList(ProjectInfo[] projects)
        {
            using (StreamReader sr = new StreamReader(projectsListPath))
                while (sr.Peek() != -1)
                {
                    string[] strings = sr.ReadLine().Split("|");
                    projects[arraySize].NumberGrop = strings[0];
                    projects[arraySize].FirstName = strings[1];
                    projects[arraySize].MiddleName = strings[2];
                    projects[arraySize].SecondName = strings[3];
                    projects[arraySize].Firstсredits = int.Parse(strings[4]);
                    projects[arraySize].Secondсredits = int.Parse(strings[5]);
                    projects[arraySize].Thirdсredits = int.Parse(strings[6]);
                    projects[arraySize].Fourthсredits = int.Parse(strings[7]);
                    projects[arraySize].Fifthсredits = int.Parse(strings[8]);
                    projects[arraySize].Firstexam = double.Parse(strings[9]);
                    projects[arraySize].Secondexam = double.Parse(strings[10]);
                    projects[arraySize].Thirdexam = double.Parse(strings[11]);
                    projects[arraySize].Fourthexam = double.Parse(strings[12]);
                    projects[arraySize].Fifthexam = double.Parse(strings[13]);
                    arraySize++;
                }
        }
        public static void SaveProjectsList()
        {
            using StreamWriter sw = new StreamWriter(projectsListPath);
            for (int i = 0; i < arraySize; i++)
            {
                sw.WriteLine($"{projects[i].NumberGrop}|{projects[i].FirstName}|{projects[i].MiddleName}|{projects[i].SecondName}|{projects[i].Firstсredits}|{projects[i].Secondсredits}|{projects[i].Thirdсredits}|{projects[i].Fourthсredits}|{projects[i].Fifthсredits}|{projects[i].Firstexam}|{projects[i].Secondexam}|{projects[i].Thirdexam}|{projects[i].Fourthexam}|{projects[i].Fifthexam}");
            }
        }
        public static void PrintAllStudents()
        {
            int counter = 1;
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"\t№{counter++}\n" +
                $"Номер группы: {projects[i].NumberGrop}\n" +
                $"ФИО: {projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName}\n" +
                $"Сведения о зачетах 1-5: {projects[i].Firstсredits} {projects[i].Secondсredits} {projects[i].Thirdсredits} {projects[i].Fourthсredits} {projects[i].Fifthсredits}\n" +
                $"Оценки по пяти экзаменам: {projects[i].Firstexam} {projects[i].Secondexam} {projects[i].Thirdexam} {projects[i].Fourthexam} {projects[i].Fifthexam}");
            }


        }

        public static void DesreasingSortt(ProjectInfo[] projects) //хуйня полная
        {
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i + 1; j < arraySize; j++)
                {
                    if (projects[i].Firstexam > projects[j].Firstexam)
                    {
                        ProjectInfo temp = projects[i];
                        projects[i] = projects[j];
                        projects[j] = temp;
                    }
                }
            }
            PrintAllStudents();

        }
        public static void IndividualTaskFirstPart(ProjectInfo[] projects)
        {
            
            Array.Sort(projects, (p1, p2) => (p2.Firstсredits + p2.Secondсredits + p2.Thirdсredits + p2.Fourthсredits + p2.Fifthсredits).CompareTo(p1.Firstсredits + p1.Secondсredits + p1.Thirdсredits + p1.Fourthсredits + p1.Fifthсredits));

            for (int i = 0; i < arraySize; i++)
            {
                int credits = projects[i].Firstсredits + projects[i].Secondсredits + projects[i].Thirdсredits + projects[i].Fourthсredits + projects[i].Fifthсredits;
                Console.WriteLine($"\t У студента:{projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName} задолжностей: {credits}\n");
            }
            PrintAllStudents();
        }


        public static void IndividualTaskSecondPart(ProjectInfo[] projects)
        {
            Console.WriteLine("Введите номер группы:");
            string numbergroop = Console.ReadLine();
            Console.WriteLine($"\t Студенты группы {numbergroop}:");
            double allgroopexams = 0;
            double averageExams = 0;
            int count = 0;
            for (int i = 0; i < arraySize; i++)
            {
                double exams = 0;
                if (projects[i].NumberGrop == numbergroop)
                {
                    exams = (projects[i].Firstexam + projects[i].Secondexam + projects[i].Thirdexam + projects[i].Fourthexam + projects[i].Fifthexam) / 5;
                    Console.WriteLine($" {projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName} средний балл:{exams:F2}");
                    allgroopexams += exams;
                    count++;
                }
            }
            averageExams = allgroopexams / count;
            if (averageExams > 0)
            {
                Console.WriteLine($" Средний балл группы: {averageExams:F2}");
            }
            if (count == 0)
            {
                Console.WriteLine("Данной группы нет");

            }

        }
        public static void EditStudents()
        {
            PrintAllStudents();
            int identifier;
            Console.WriteLine("Введите номер студента для редактирования: ");
            while (!int.TryParse(Console.ReadLine(), out identifier) || identifier < 0)
            {
                Console.WriteLine("Некоректный ввод");
            }
            Console.WriteLine("Номер студента" + ":");
            Console.WriteLine($"\t№{identifier}\n" +
            $"Номер группы {projects[identifier - 1].NumberGrop}: \n" +
            $"ФИО: {projects[identifier - 1].FirstName} {projects[identifier - 1].MiddleName} {projects[identifier - 1].SecondName}\n" +
            $"Сведения о зачетах 1-5: {projects[identifier - 1].Firstсredits} {projects[identifier - 1].Secondсredits} {projects[identifier - 1].Thirdсredits} {projects[identifier - 1].Fourthсredits} {projects[identifier - 1].Fifthсredits}\n" +
            $"Оценки по пяти экзаменам: {projects[identifier - 1].Firstexam} {projects[identifier - 1].Secondexam} {projects[identifier - 1].Thirdexam} {projects[identifier - 1].Fourthexam} {projects[identifier - 1].Fifthexam}");
            Console.WriteLine("Нажмите Eter,если не хотите менять!");
            Console.WriteLine("Номер группы: ");
            string numbergroup = Console.ReadLine();
            if (numbergroup != String.Empty)
            {
                projects[identifier - 1].NumberGrop = numbergroup;
            }
            Console.WriteLine("Введите имя: ");
            string firstname = Console.ReadLine();
            if (firstname != String.Empty)
            {
                projects[identifier - 1].FirstName = firstname;
            }
            Console.WriteLine("Введите фамилию ");
            string secondname = Console.ReadLine();
            if (secondname != String.Empty)
            {
                projects[identifier - 1].SecondName = secondname;
            }
            Console.WriteLine("Введите отчество:");
            string middlename = Console.ReadLine();
            if (middlename != String.Empty)
            {
                projects[identifier - 1].MiddleName = middlename;
            }
            bool isValidCredit = false;
            while (!isValidCredit)
            {
                Console.WriteLine("Введите сведения о зачете 1 (0 - Зачтенно, 1 - Незачтенно): ");
                string firstcredit = Console.ReadLine();

                if (firstcredit != String.Empty)
                {
                    int creditValue;
                    if (int.TryParse(firstcredit, out creditValue))
                    {
                        if (creditValue == 0 || creditValue == 1)
                        {
                            projects[identifier - 1].Firstсredits = creditValue;
                            isValidCredit = true;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение зачета. Введите 0 или 1.");
                        }
                    }
                }
            }
            bool isValidCreditTwo = false;
            while (!isValidCreditTwo)
            {
                Console.WriteLine("Введите сведения о зачете 2 (0 - Зачтенно, 1 - Незачтенно): ");
                string secondcredit = Console.ReadLine();

                if (secondcredit != String.Empty)
                {
                    int creditValue;
                    if (int.TryParse(secondcredit, out creditValue))
                    {
                        if (creditValue == 0 || creditValue == 1)
                        {
                            projects[identifier - 1].Secondсredits = creditValue;
                            isValidCreditTwo = true;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение зачета. Введите 0 или 1.");
                        }
                    }
                }
            }
            bool isValidCreditThree = false;
            while (!isValidCreditThree)
            {
                Console.WriteLine("Введите сведения о зачете 3 (0 - Зачтенно, 1 - Незачтенно): ");
                string thirdcredit = Console.ReadLine();

                if (thirdcredit != String.Empty)
                {
                    int creditValue;
                    if (int.TryParse(thirdcredit, out creditValue))
                    {
                        if (creditValue == 0 || creditValue == 1)
                        {
                            projects[identifier - 1].Thirdсredits = creditValue;
                            isValidCreditThree = true;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение зачета. Введите 0 или 1.");
                        }
                    }
                }
            }
            bool isValidCreditFour = false;
            while (!isValidCreditFour)
            {
                Console.WriteLine("Введите сведения о зачете 4 (0 - Зачтенно, 1 - Незачтенно): ");
                string fourthcredit = Console.ReadLine();

                if (fourthcredit != String.Empty)
                {
                    int creditValue;
                    if (int.TryParse(fourthcredit, out creditValue))
                    {
                        if (creditValue == 0 || creditValue == 1)
                        {
                            projects[identifier - 1].Fourthсredits = creditValue;
                            isValidCreditFour = true;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение зачета. Введите 0 или 1.");
                        }
                    }
                }
            }

            bool isValidCreditFive = false;
            while (!isValidCreditFive)
            {
                Console.WriteLine("Введите сведения о зачете 5 (0 - Зачтенно, 1 - Незачтенно): ");
                string fifthcredit = Console.ReadLine();

                if (fifthcredit != String.Empty)
                {
                    int creditValue;
                    if (int.TryParse(fifthcredit, out creditValue))
                    {
                        if (creditValue == 0 || creditValue == 1)
                        {
                            projects[identifier - 1].Fifthсredits = creditValue;
                            isValidCreditFive = true;
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение зачета. Введите 0 или 1.");
                        }
                    }
                }
            }

            bool isValidExamOne = false;
            while (!isValidExamOne)
            {
                Console.WriteLine("Введите оценку за экзамен 1: ");
                string firstexam = Console.ReadLine();

                if (firstexam != String.Empty)
                {
                    double examValue;
                    if (double.TryParse(firstexam, out examValue))
                    {
                        projects[identifier - 1].Firstexam = examValue;
                        isValidExamOne = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат ввода. Введите число.");
                    }
                }
            }

            bool isValidExamTwo = false;
            while (!isValidExamTwo)
            {
                Console.WriteLine("Введите оценку за экзамен 2: ");
                string secondexam = Console.ReadLine();

                if (secondexam != String.Empty)
                {
                    double examValue;
                    if (double.TryParse(secondexam, out examValue))
                    {
                        projects[identifier - 1].Secondexam = examValue;
                        isValidExamTwo = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат ввода. Введите число.");
                    }
                }
            }

            bool isValidExamThree = false;
            while (!isValidExamThree)
            {
                Console.WriteLine("Введите оценку за экзамен 3: ");
                string thirdexam = Console.ReadLine();

                if (thirdexam != String.Empty)
                {
                    double examValue;
                    if (double.TryParse(thirdexam, out examValue))
                    {
                        projects[identifier - 1].Thirdexam = examValue;
                        isValidExamThree = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат ввода. Введите число.");
                    }
                }
            }

            bool isValidExamFour = false;
            while (!isValidExamFour)
            {
                Console.WriteLine("Введите оценку за экзамен 4: ");
                string fourthexam = Console.ReadLine();

                if (fourthexam != String.Empty)
                {
                    double examValue;
                    if (double.TryParse(fourthexam, out examValue))
                    {
                        projects[identifier - 1].Fourthexam = examValue;
                        isValidExamFour = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат ввода. Введите число.");
                    }
                }
            }

            bool isValidExamFive = false;
            while (!isValidExamFive)
            {
                Console.WriteLine("Введите оценку за экзамен 5: ");
                string fifthexam = Console.ReadLine();

                if (fifthexam != String.Empty)
                {
                    double examValue;
                    if (double.TryParse(fifthexam, out examValue))
                    {
                        projects[identifier - 1].Fifthexam = examValue;
                        isValidExamFive = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный формат ввода. Введите число.");
                    }
                }
            }
            SaveProjectsList();
        }

        public static void DesreasingSort(ProjectInfo[] projects)
        {
            Array.Sort(projects, (p1, p2) => (p2.Firstсredits + p2.Secondсredits + p2.Thirdсredits + p2.Fourthсredits + p2.Fifthсredits).CompareTo(p1.Firstсredits + p1.Secondсredits + p1.Thirdсredits + p1.Fourthсredits + p1.Fifthсredits));
            for (int i = 0; i < arraySize; i++)
            {
                int credits = projects[i].Firstсredits + projects[i].Secondсredits + projects[i].Thirdсredits + projects[i].Fourthсredits + projects[i].Fifthсredits;
                Console.WriteLine($"\t№ У студента:{projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName} задолжностей: {credits}\n");
            }
        }

        public static void SortAverageExams(ProjectInfo[] projects)
        {
            Array.Sort(projects, (p1, p2) => (p2.Firstexam + p2.Secondexam + p2.Thirdexam + p2.Fourthexam + p2.Fifthexam).CompareTo(p1.Firstexam + p1.Secondexam + p1.Thirdexam + p1.Fourthexam + p1.Fifthexam));
            for (int i = 0; i < arraySize; i++)
            {
                double exams = (projects[i].Firstexam + projects[i].Secondexam + projects[i].Thirdexam + projects[i].Fourthexam + projects[i].Fifthexam) / 5;
                Console.WriteLine($" {projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName} средний балл:{exams:F2}");

            }
        }
        public static void AlphaSort(ProjectInfo[] projects)
        {
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize - 1; j++)
                {
                    if (needToReOrder(projects[j].MiddleName, projects[j +1].MiddleName))
                    {
                        ProjectInfo temp = projects[j];
                        projects[j] = projects[j + 1];
                        projects[j + 1] = temp;
                    }
                }
            }
            PrintAllStudents();
        }

        static bool needToReOrder(string project1, string project2)
        {
            for (int i = 0; i < (project1.Length > project2.Length ? project2.Length : project1.Length) ; i++)
            {
                if (project1.ToCharArray()[i] < project2.ToCharArray()[i])
                    return false;
                if (project1.ToCharArray()[i] > project2.ToCharArray()[i])
                    return true;
            }
            return false;
        }

        public static void GroopSearch(ProjectInfo[] projects)
        {
            Console.WriteLine("Введите номер группы:");
            string numbergroop = Console.ReadLine();
            Console.WriteLine($"\t Студенты группы {numbergroop}:");
            int count = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (projects[i].NumberGrop == numbergroop)
                {
                    Console.WriteLine($" {projects[i].FirstName} {projects[i].MiddleName} {projects[i].SecondName}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Данной группы нет");

            }

        }
    }
}





