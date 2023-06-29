using System;
using System.Text.RegularExpressions;
namespace EmployeeList{
    public class Employee{
        private static int empIdCounter = 1001;
        private int empID;
        private string? Name;
        private string? Department;
        private string? Designation;
        private double Salary;

        public int EmpID{
            get{empID = empIdCounter++;
            return empID;}
            set{empID = value;}
        }

        public string EmpName{
            get{return Name;}
            set{
                while(true){
                string? regex="[A-Za-z ]+$";
                Match match = Regex.Match(value, regex);
                if(match.Success && match.Value.Length > 3){
                    Name = match.Value;
                    break;
                }else{
                    Console.WriteLine("Enter a valid name");
                    value=Console.ReadLine();
                }
                }
            }
        }
        public string EmpDepartment{
            get{return Department;}
            set{
               
                Department = value;
            }
        }
        public string EmpDesignation{
            get{return Designation;}
            set{
                Designation=value;
                }
        }
        public double EmpSalary{
            get{return Salary;}
            set{
                while(true){
                    if(value >= 5000){
                        break;
                    }
                    else{
                        System.Console.WriteLine("Enter valid salary greater than 5000\nEnter valid salary\n");
                        value = Convert.ToDouble(Console.ReadLine());
                    }
                }
                Salary = value;
                }
        }
        public override string ToString(){
            string details = "\nID:"+empID+"\nName:"+EmpName+"\nDepartment:"+Department+"\nDesignation:"+Designation+"\nSalary:"+Salary;
            return details;
        }

        public void setAllowance(){
            if(EmpDesignation.ToLower() == "manager"){
                EmpSalary += EmpSalary*0.2;
            }
            else{
                EmpSalary += EmpSalary*0.1;
            }
            System.Console.WriteLine("Salary+Allowance:"+EmpSalary);
        }
    }
}