import java.util.InputMismatchException;
import java.util.Scanner;
    class Employee{
        Scanner sc=new Scanner(System.in);
        private  int empId;
        public static int empIdCounter=1001;
        private String empName;
        private String empDepartment;
        private String empDesignation;
        private double empSalary;
        public int getEmpId(){
            return empId;
        }
        public void setEmpName(String name){
            while (true) {
                String regex = "[A-Za-z ]+";
                if (name.matches(regex) == false || name.length() <= 2) {
                    System.out.println("Invalid name");
                    System.out.println("Re enter the name");
                    name = sc.nextLine();
                } else {
                    empName=name;
                    return;
                }
            }
        }
        public String getEmpName(){
            return empName;
        }
        public void setDepartment(String department){
            this.empDepartment=department;
        }
        public String getDepartment(){
            return empDepartment;
        }
        public void setDesignation(String designation){
            this.empDesignation=designation;
        }
        public String getDesignation(){
            return empDesignation;
        }
        public void setSalary(Double salary) {
            double validatedSalary=0.0;
            if (salary == 0.0 || salary<5000) {
                while (validatedSalary<5000){
                    try {
                        System.out.println("Re-enter the employee salary");
                        validatedSalary = sc.nextDouble();
                        sc.nextLine();
//                        System.out.println("Salary should be atleast 5000");
                        if (validatedSalary >= 5000) {
                            break;
                        } else {
                            System.out.println("Salary should be atleast 5000\n");
                            System.out.println("Re-enter the employee salary");
                            validatedSalary = sc.nextDouble();
                            sc.nextLine();
                        }
                    } catch (InputMismatchException mme) {
                        System.out.println("Salary should be a number\n");
                        sc.nextLine();

                    }
                }
                empSalary = validatedSalary;
            }
            else{
                empSalary=salary;
            }
        }
        public double getSalary(){
            return empSalary;
        }
        public Employee(){
            this.empId=empIdCounter++;
        }
        public Employee(String name,String department,String designation,double salary){
            this.empId=empIdCounter++;
            this.empName=name;
            this.empDepartment=department;
            this.empDesignation=designation;
            this.empSalary=salary;
        }
        public void setAllowance() {
            if (empDesignation.toUpperCase().compareTo("MANAGER") == 0) {
                empSalary = empSalary + 0.2 * empSalary;
            } else {
                empSalary = empSalary + 0.1 * empSalary;
            }
        }
        public double getOriginalSalary(){
            double originalSalary;
            if(empDesignation.compareTo("Manager")==0){
                originalSalary=empSalary/1.2;
            }
            else{
                originalSalary=empSalary/1.1;
            }
            return originalSalary;
        }
        public String toString(){
            return String.format("%-10d %-20s %-20s %-20s %-10.2f", empId, empName, empDepartment,empDesignation,getOriginalSalary());
        }
    }
