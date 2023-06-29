import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.Scanner;
public class testEmployee{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        ArrayList<Employee> employeeList = new ArrayList<Employee>();
        int employeeCount = 1;
        String nxtChoice="";
        while (true) {
            System.out.println("1.Add employee detail 2.Exit");
            nxtChoice=sc.nextLine();
            if(nxtChoice.compareTo("1")==0){
                System.out.println("Enter the details of employee  " + employeeCount);
                System.out.println("Enter the employee name");
                String name = "";
                name = sc.nextLine();
                while (true) {
                    String regex = "[A-Za-z ]+";
                    if (name.matches(regex) == false || name.length() <= 2) {
                        System.out.println("Invalid name");
                        System.out.println("Re enter the name");
                        name = sc.nextLine();
                    } else {
                        break;
                    }
                }
                String departmentChoice = "";
                String department = "";
                while (true) {
                    System.out.println("Enter the employee department 1.R&D  2.IT 3.HR 4.Testing 5.Support");
                    departmentChoice = sc.nextLine();
                    if (departmentChoice.compareTo("1") == 0) {
                        department = "R&D";
                        break;
                    } else if (departmentChoice.compareTo("2") == 0) {
                        department = "IT";
                        break;
                    } else if (departmentChoice.compareTo("3") == 0) {
                        department = "HR";
                        break;
                    } else if (departmentChoice.compareTo("4") == 0) {
                        department = "IT";
                        break;
                    } else if (departmentChoice.compareTo("5") == 0) {
                        department = "Support";
                        break;
                    } else {
                        System.out.println("Invalid choice");
                    }
                }
                String designationChoice = "";
                String designation = "";
                while (true) {
                    System.out.println("Enter the employee designation 1.Software Intern 2.Software Developer 3.Manager 4.Director 5.Vice President 6.CEO");
                    designationChoice = sc.nextLine();
                    if (designationChoice.compareTo("1") == 0) {
                        designation = "Software Intern";
                        break;
                    } else if (designationChoice.compareTo("2") == 0) {
                        designation = "Software Developer";
                        break;
                    } else if (designationChoice.compareTo("3") == 0) {
                        designation = "Manager";
                        break;
                    } else if (designationChoice.compareTo("4") == 0) {
                        designation = "Director";
                        break;
                    } else if (designationChoice.compareTo("5") == 0) {
                        designation = "Vice President";
                        break;
                    } else if (designationChoice.compareTo("6") == 0) {
                        designation = "CEO";
                        break;
                    } else {
                        System.out.println("Invalid choice");
                    }
                }
                double salary;
                while (true) {
                    System.out.println("Enter the employee salary");
                    try {
                        salary = sc.nextDouble();
                        sc.nextLine();
                        break;
                    } catch (InputMismatchException mme) {
                        System.out.println("Invalid salary");
                        sc.nextLine();
                    }
                }
                employeeList.add(new Employee(name,department, designation, salary));
                employeeCount++;

            }
            else if(nxtChoice.compareTo("2")==0){
                for (Employee employee : employeeList) {
                    System.out.println(employee.toString()+"  Salary+Allowance:"+employee.setAllowance());
                }
                break;
            }
            else{
                System.out.println("Invalid choice");
            }
        }
    }
}