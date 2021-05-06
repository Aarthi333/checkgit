using System;
using TransportBLLibrary;

namespace TransportFEApplication
{
    class Program
    {
        EmployeeLogin login;
        EmployeeManagement management;
        EmployeeBL bl;
        public Program()
        {
            bl = new EmployeeBL();
            login = new EmployeeLogin(bl);
            management = new EmployeeManagement(bl);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.REGISTER");
                Console.WriteLine("2.LOGIN");
                Console.WriteLine("3.PRINTALL");
                Console.WriteLine("4.SORT AND PRINT ALL");
                Console.WriteLine("5.RESET PASSWORD");
                Console.WriteLine("6.RESET LOCATION");
                Console.WriteLine("10.EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        login.RegisterEmployee();
                        break;
                    case 2:
                        login.UserLogin();
                        break;
                    case 3:
                        management.PrintAllEmployees();
                        break;
                    case 4:
                        management.PrintEmployeesSortedById();
                        break;
                    case 5:
                        management.ResetPassword();
                        break;
                    case 6:
                        management.ResetLocation();
                        break;
                    case 10:
                        Console.WriteLine("exiting...");
                        break;
                    default:
                        Console.WriteLine("invalid choice ...try again");
                        break;
                }

            } while (choice!=10);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().PrintMenu();
        }
    }
}
