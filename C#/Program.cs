using EmployeeList;
using System;
public class Program{
    public static void Main(string[] args){
        List<Employee> employeeList = new List<Employee>();
        double salary ;
        string choice = "";
        while(true){
            Console.WriteLine("1.Add employee detail\n2.Exit");
            choice=Console.ReadLine();
            if(choice == "1"){
                Employee employee = new Employee();
                Console.WriteLine("Enter the detail of "+employee.EmpID);
                Console.WriteLine("Enter the name:");
                string? name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name is required");
                }
                employee.EmpName =  name;
                string[] departments = {"R&D","IT","HR","Testing","Support"}; 
                while(true){
                     Console.WriteLine("Enter the employee department\n1.R&D\n2.IT\n3.HR\n4.Testing\n5.Support");
                     if (!int.TryParse(Console.ReadLine(), out int department))
                    {
                    Console.WriteLine("Invalid choice");
                }
                else{
                    if( department>0 && department<= departments.Length){
                    employee.EmpDepartment = departments[ department-1];
                    break;}
                    else{
                        Console.WriteLine("Invalid department");
                    }
                }
                }
                string[] designationArray = {"Software Intern","Software Developer","Manager","Director","Vice President","CEO"};
                while(true){
                    Console.WriteLine("\nEnter the employee designation\n1.Software Intern\n2.Software developer\n3.Manager\n4.Director\n5.Vice President\n6.CEO");
                if (!int.TryParse(Console.ReadLine(), out int designation))
                {
                    Console.WriteLine("Invalid designation");
                }
                else{
                    if(designation>0 && designation<=designationArray.Length){
                    employee.EmpDesignation = designationArray[ designation-1];
                    break;
                    }
                    else{
                        Console.WriteLine("Invalid designation");
                    }
                }
                }
                while(true){
                    try{
                        Console.WriteLine("Enter Salary:");
                        salary = Convert.ToDouble(Console.ReadLine());
                        employee.EmpSalary = salary;
                        break;
                    }
                    catch(FormatException){
                        Console.WriteLine("Enter valid Salary");
                        continue;
                    }

                }
                employeeList.Add(employee);
                System.Console.WriteLine("Employee details added successfully");
            }
            else if (choice == "2")
            {
                if(employeeList.Count!=0){
                    for(int i=0; i<employeeList.Count;i++){
                        System.Console.WriteLine(employeeList[i].ToString());
                        employeeList[i].setAllowance();
                    }
                }
                break;
            }
            else{
                Console.WriteLine("Invalid choice");
            }
        }
    }
}