import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.Scanner;
public class testEmployee{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        MasterData masterData=new MasterData();
        AttendanceMaster attendanceMaster=new AttendanceMaster();
        ArrayList<Employee> empList=new ArrayList<>();
        int employeeCount = 1001;
        String nxtChoice="";
        while (true) {
            System.out.println("--------------Enter the choice--------------");
            System.out.println("1.Add employee detail  \n2.Other option");
            nxtChoice=sc.nextLine();
            if(nxtChoice.compareTo("1")==0){
                System.out.println("Enter the details of employee  " + employeeCount);
                Employee employee=new Employee();
                System.out.println("Enter the employee name");
                String name = "";
                name = sc.nextLine();
                employee.setEmpName(name);
                String departmentChoice ;
                String[] departmentList={"R&D","IT","HR","Testing","Support"};
                while (true) {
                    System.out.println("Enter the employee department \n1.R&D  \n2.IT \n3.HR \n4.Testing \n5.Support");
                    try {
                        departmentChoice = sc.nextLine();
                        int convertedIntchoice=Integer.parseInt(departmentChoice);
                        if (convertedIntchoice > 0 && convertedIntchoice <= 5) {
                            employee.setDepartment(departmentList[convertedIntchoice - 1]);
                            break;
                        } else {
                            System.out.println("Invalid choice1");
                        }
                    } catch (NumberFormatException e) {
                        System.out.println("Invalid choice");
                    }
                }
                String designationChoice;
                String[] designationList={"Software Intern","Software Developer","Manager","Director","Vice President","CEO"};
                while (true) {
                    System.out.println("Enter the employee designation \n1.Software Intern \n2.Software Developer \n3.Manager \n4.Director \n5.Vice President \n6.CEO");
                    try {
                        designationChoice= sc.nextLine();
                        int convertedDesigChoice=Integer.parseInt(designationChoice);
                        if(convertedDesigChoice>0 && convertedDesigChoice<=6){
                            employee.setDesignation(designationList[convertedDesigChoice-1]);
                            break;
                        }
                        else{
                            System.out.println("Invalid choice");
                        }
                    }
                    catch (NumberFormatException e){
                        System.out.println("Invalid choice");
                    }
                }
                Double salary=0.0;
                try {
                    System.out.println("Enter the employee salary");
                    salary = sc.nextDouble();
                    sc.nextLine();
                    employee.setSalary(salary);
                }
                catch (InputMismatchException e){
                    System.out.println("Salary should be a number");
                    sc.nextLine();
                    employee.setSalary(salary);
                }
                masterData.addEmployeeToList(employee);
                employee.setAllowance();
                System.out.println("Employee detail added to the list");
                employeeCount++;
                empList.add(employee);

            }
            else if(nxtChoice.compareTo("2")==0) {
                boolean toContinue = true;
                while (true) {
                    if(masterData.getEmpList().size()==0){
                        System.out.println("The employee list is empty");
                        break;
                    }
                    else {
                        System.out.println("--------------Enter the coice--------------");
                        System.out.println("1.Display employee details   \n2.Add attendance to the employee  \n3.Show eligible employee list  \n4.Go back\n5.Update attendance to the employee\n6.Exit");
                        String displayChoice = sc.nextLine();
                        if (displayChoice.compareTo("1") == 0) {
                            masterData.employeeDetailDisplay();
                        } else if (displayChoice.compareTo("2") == 0) {
                            if(empList.size()==0){
                                System.out.println("You already added the attendance of all employee");
                            }
                            else{
                            int noOfWorkingDays;
                            for(Employee emp:empList) {
                                while (true) {
                                    System.out.println("Enter the number of working day for the employee " + emp.getEmpId());
                                    try {
                                        noOfWorkingDays = sc.nextInt();
                                        sc.nextLine();
                                        if (noOfWorkingDays > 0) {
                                            attendanceMaster.empAttendancedict.put(emp, noOfWorkingDays);
                                            break;
                                        }
                                        else{
                                            System.out.println("Number of working days should not be negative");
                                        }
                                    } catch (InputMismatchException exception) {
                                        System.out.println("Number of working days should be number");
                                        sc.nextLine();
                                    }

                                }
                            }
                            empList.clear();
                            }
                        }
                        else if(displayChoice.compareTo("3")==0){

                            attendanceMaster.showEligibleList();
                        }
                        else if(displayChoice.compareTo("4")==0){
                            break;
                        }
                        else if (displayChoice.compareTo("5") == 0) {
                            int empId;
                            int updatedWorkingDays;
                            boolean toBreak=false;
                            if (attendanceMaster.empAttendancedict.size()>0) {
                                while (true) {
                                    try {
                                        System.out.println("Enter the employee id");
                                        empId = sc.nextInt();
                                        sc.nextLine();
                                        if (empId >= 1001 && empId <= attendanceMaster.empAttendancedict.size() + 1000) {
                                            while (true) {
                                                try {
                                                    System.out.println("Enter the number of working days");
                                                    updatedWorkingDays = sc.nextInt();
                                                    sc.nextLine();
                                                    if (updatedWorkingDays >= 0) {
                                                        attendanceMaster.empAttendancedict.put(masterData.getEmpList().get(empId-1001), updatedWorkingDays);
                                                        //attendanceMaster.addAttendance(masterData.getEmpList().get(empId-1001), updatedWorkingDays);
                                                        toBreak = true;
                                                        break;
                                                    } else {
                                                        System.out.println("Working days cannot be negative");
                                                    }
                                                } catch (InputMismatchException ex) {
                                                    System.out.println("Working days should be value");
                                                    sc.nextLine();
                                                }
                                            }
                                            if (toBreak) {
                                                break;
                                            }
                                        } else {
                                            System.out.println("The employee id is not found");
                                        }
                                    } catch (InputMismatchException ex) {
                                        System.out.println("Employee id should be value");
                                    }
                                }
                            }
                            else{
                                System.out.println("Inorder to update the attendance you should enter the attendance to the employee");
                                break;
                            }
                        } else if (displayChoice.compareTo("6") == 0) {
                            toContinue = false;
                            break;

                        }else {
                            System.out.println("Invalid choice");
                        }
                    }
                }
                if (!toContinue) {
                    break;
                }
            }
            else{
                System.out.println("Invalid choice");
            }
        }
    }
}