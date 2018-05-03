using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = new string[1];
            var families = new string[1];
            var phones = new string[1];


            InitializePhoneBook();
            while (true)
            {
                Console.Clear();
                var selectedMenuItem = ShowMenu();

                Console.Clear();
                switch (selectedMenuItem)
                {
                    case 1:

                        ShowContactList(names, families, phones);
                        break;

                    case 2:
                        if (!AddToContactList(ref names, ref families, ref phones))
                            ShowInvalidPhoneNotification();
                        break;

                    case 3:

                        EditContact(names, families, phones);

                        break;

                    case 4:
                        RemoveContact(names, families, phones);

                        break;

                    case 5:
                        ExitConsole();
                        break;

                }

            }
        }

        private static void ExitConsole()
        {
            System.Environment.Exit(0);
        }

        private static void EditContact(string[] names, string[] families, string[] phones)
        {
            int a = 1;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                    Console.WriteLine($"{a}\t{names[i]}\t{families[i]}\t{phones[i]}");
                a++;
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine("\nWhich item do you want to edit?");
            var choice = int.Parse(Console.ReadLine());
            Console.Clear();
            GetInformation(ref names, ref families, ref phones);
            Console.Clear();
            a = 1;
            for (int i = 0; i < names.Length; i++)
            {
                if (choice == i + 1)
                {
                    names[i] = null;
                    families[i] = null;
                    phones[i] = null;
                    names[i] = names[choice];
                    families[i] = families[choice];
                    phones[i] = phones[choice];
                    ShowContactList(names, families, phones);
                }

                a++;
            }
            Console.ReadKey();
        }

        private static void RemoveContact(string[] names, string[] families, string[] phones)

        {
            int a = 1;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                    Console.WriteLine($"{a}\t{names[i]}\t{families[i]}\t{phones[i]}");
                a++;
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine("\nWhich item do you want to remove?");
            var choice2 = int.Parse(Console.ReadLine().ToLower());
            Console.Clear();

            for (int i = 0; i < names.Length; i++)
            {
                if (choice2 == i + 1)
                {
                    names[i] = null;
                    families[i] = null;
                    phones[i] = null;
                    ShowContactList(names, families, phones);
                }

            }
            Console.ReadKey();
        }

        private static void GetInformation(ref string[] names, ref string[] families, ref string[] phones)
        {
            Console.Write("Name:");
            var name = Console.ReadLine().ToLower();
            Console.Write("Family:");
            var family = Console.ReadLine().ToLower();
            Console.Write("Phone:");
            var phone = Console.ReadLine().ToLower();
            if (Regex.IsMatch(phone, @"^09\d{9}$"))
            {
                AddToStringArray(ref names, name);
                AddToStringArray(ref families, family);
                AddToStringArray(ref phones, phone);

            }
        }

        static void ShowInvalidPhoneNotification()
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Phone Number Is Not Valid!");
            Console.CursorVisible = false;
            Thread.Sleep(3000);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;

        }

        static bool AddToContactList(ref string[] names, ref string[] families, ref string[] phones)
        {
            Console.Write("Name:");
            var name = Console.ReadLine().ToLower();
            Console.Write("Family:");
            var family = Console.ReadLine().ToLower();
            Console.Write("Phone:");
            var phone = Console.ReadLine().ToLower();
            if (Regex.IsMatch(phone, @"^09\d{9}$"))
            {
                AddToStringArray(ref names, name);
                AddToStringArray(ref families, family);
                AddToStringArray(ref phones, phone);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ShowContactList(string[] names, string[] families, string[] phones)
        {

            int a = 1;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                    Console.WriteLine($"{a}\t{names[i]}\t{families[i]}\t{phones[i]}");
                a++;
            }

            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }

        static void InitializePhoneBook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
╦ ╦┌─┐┬  ┌─┐┌─┐┌┬┐┌─┐  ╔╦╗┌─┐  ╔═╗┬ ┬┌─┐┌┐┌┌─┐╔╗ ┌─┐┌─┐┬┌─
║║║├┤ │  │  │ ││││├┤    ║ │ │  ╠═╝├─┤│ ││││├┤ ╠╩╗│ ││ │├┴┐
╚╩╝└─┘┴─┘└─┘└─┘┴ ┴└─┘   ╩ └─┘  ╩  ┴ ┴└─┘┘└┘└─┘╚═╝└─┘└─┘┴ ┴
");
            //var count = int.Parse(Console.ReadLine());
            Thread.Sleep(3000);
            Console.Clear();
        }

        static int ShowMenu()
        {
            Console.WriteLine($"1.Show Contact List\n2.Add New Contact\n3.Edit Contact\n4.Remove Contact\n5.Exit");
            return int.Parse(Console.ReadLine());
        }


        static void AddToStringArray(ref string[] array, string newValue)
        {
            string[] newArray;

            if (array[0] != null)
                newArray = new string[array.Length + 1];
            else
                newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = newValue;
            array = newArray;
        }

    }
}