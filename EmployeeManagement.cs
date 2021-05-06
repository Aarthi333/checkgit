using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class EmployeeManagement
    {
        private IRepo<Employee> _repo;
        public EmployeeManagement()
        {

        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;
        }
        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if(_repo.Add(employee))
                    Console.WriteLine("employee created");
                else
                    Console.WriteLine("sorry could not complete adding an employee");
            }
            catch (Exception e)
            {
                Console.WriteLine("could not add employee");
                Console.WriteLine(e.Message);
            }
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;
        }
        public void PrintAllEmployees()
        {
            //var employees = GetAllEmployees();
            var employees = SortEmployees();
            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public List<CompleteEmployee> SortEmployees()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));
            }

            return employees;
        }
        public void PrintEmployeesSortedById()
        {
            var employees = SortEmployees();
            employees.Sort();
            foreach  (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public void ResetPassword()
        {
            Console.WriteLine("please enter the employee id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the old password");
            string password = Console.ReadLine();
            Employee employee = GetAllEmployees().Find(e=>e.Id == id && e.Password== password);
            try
            {
                if(employee!= null)
                {
                    Console.WriteLine("please enter the new password");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("please retype the new password");
                    var repeatPassword = Console.ReadLine();
                    if(newPassword==repeatPassword)
                    {
                        employee.Password = newPassword;
                        if (_repo.Update(employee))
                            Console.WriteLine("password updated");
                        else
                            Console.WriteLine("please try again");
                    }
                    else
                        Console.WriteLine("password mismatch");
                }
                else
                {
                    Console.WriteLine("incorrect username or password");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("could not update password at this moment");
                Console.WriteLine(e.Message);
            }
        }
        public void ResetLocation()
        {
            Console.WriteLine("please enter the employee id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the old location");
            string location = Console.ReadLine();
            Employee employee = GetAllEmployees().Find(e => e.Id == id && e.Location == location);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("please enter the new location");
                    var newLocation = Console.ReadLine();
                    employee.Location = newLocation;
                        if (_repo.UpdateLoc(employee))
                            Console.WriteLine("location updated");
                        else
                            Console.WriteLine("please try again");
                }
                else
                {
                    Console.WriteLine("incorrect ID .couldnt change location ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("could not update location at this moment");
                Console.WriteLine(e.Message);
            }
        }

    }
}
