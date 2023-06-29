import java.util.*;
public class TestEmployee{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        MasterData masterData=new MasterData();
        AttendanceMaster attendanceMaster=new AttendanceMaster();
        ArrayList<Employee> empList=new ArrayList<>();//to iterate through the employee detail while adding attendance
        SalCalculator salCalculator=new SalCalculator();
        boolean toCalculateSalary=false;//flag variable to denote that the hashmap is been filtered before calculating
        String nxtChoice="";
        while (true) {
            System.out.println("\n-----------------Menu-----------------");
            System.out.println("1.Add employee detail  \n2.Display employee details   \n3.Add attendance to the employee  \n4.Filter and show eligible employee list\n5.Update attendance to the employee\n6.Sort\n7.Calculate salary for eligible employee\n8.Exit");
            System.out.println("Enter the choice:");
            nxtChoice=sc.nextLine();
            if(nxtChoice.compareTo("1")==0){
                Employee employee=new Employee();
                System.out.println("Enter the details of employee  " + employee.getEmpId());
                System.out.println("Enter the employee name:");
                String name = "";
                name = sc.nextLine();
                employee.setEmpName(name);
                String departmentChoice ;
                System.out.println();
                String[] departmentList={"R&D","IT","HR","Testing","Support"};
                while (true) {
                    System.out.println("--------List of department-------- \n1.R&D  \n2.IT \n3.HR \n4.Testing \n5.Support");
                    try {
                        System.out.println("Enter the choice of department:");
                        departmentChoice = sc.nextLine();
                        int convertedIntchoice=Integer.parseInt(departmentChoice);
                        if (convertedIntchoice > 0 && convertedIntchoice <= 5) {
                            employee.setDepartment(departmentList[convertedIntchoice - 1]);
                            break;
                        } else {
                            System.out.println("Invalid choice(Enter the choice between 1-5)\n");
                        }
                    } catch (NumberFormatException e) {
                        System.out.println("Choice should be a value\n");
                    }
                }
                System.out.println();
                String designationChoice;
                String[] designationList={"Software Intern","Software Developer","Manager","Director","Vice President","CEO"};
                while (true) {
                    System.out.println("List of designation \n1.Software Intern \n2.Software Developer \n3.Manager \n4.Director \n5.Vice President \n6.CEO");
                    try {
                        System.out.println("Enter the choice of designation:");
                        designationChoice= sc.nextLine();
                        int convertedDesigChoice=Integer.parseInt(designationChoice);
                        if(convertedDesigChoice>0 && convertedDesigChoice<=6){
                            employee.setDesignation(designationList[convertedDesigChoice-1]);
                            break;
                        }
                        else{
                            System.out.println("Invalid choice(Enter the choice between 1-6)\n");
                        }
                    }
                    catch (NumberFormatException e){
                        System.out.println("Choice should be a value\n");
                    }
                }
                Double salary=0.0;
                try {
                    System.out.println("Enter the employee salary:");
                    salary = sc.nextDouble();
                    sc.nextLine();
                    if(salary<5000) {
                        System.out.println("Salary should be atleast 5000\n");
                        employee.setSalary(salary);
                    }
                    else{
                        employee.setSalary(salary);
                    }
                }
                catch (InputMismatchException e){
                    System.out.println("Salary should be a number\n");
                    sc.nextLine();
                    employee.setSalary(salary);
                }
                masterData.addEmployeeToList(employee);
                System.out.println("\n--------Employee detail added to the list--------");
                empList.add(employee);
                toCalculateSalary=false;
                employee.setAllowance();
            }
            else if(nxtChoice.compareTo("2")==0) {
                if (masterData.getEmpList().size() == 0) {
                    System.out.println("No employee detail is entered yet");
                } else {
                    System.out.println("Employee List:");
                    masterData.employeeDetailDisplay();
                }
            }
            else if(nxtChoice.compareTo("3")==0){
                if(masterData.getEmpList().size()==0){
                    System.out.println("No employee detail is entered yet\n");
                }
                else if(empList.size()==0){
                    System.out.println("You already added the attendance of all employee\n");
                }
                else{
                    int noOfWorkingDays;
                    for(Employee emp:empList) {
                        while (true) {
                            System.out.println("Enter the number of working day for the employee " + emp.getEmpId());
                            try {
                                noOfWorkingDays = sc.nextInt();
                                sc.nextLine();
                                if (noOfWorkingDays >= 0 && noOfWorkingDays<=30) {
                                    attendanceMaster.getEmpAttendancedict().put(emp, noOfWorkingDays);
                                    break;
                                }
                                else{
                                    System.out.println("Number of working days should be within 0-30\n");
                                }
                            } catch (InputMismatchException exception) {
                                System.out.println("Number of working days should be number\n");
                                sc.nextLine();
                            }

                        }
                    }
                    empList.clear();//after adding the attendance we can clear the list so that nxt time we can start adding attendance for newly entered emp
                }
            } else if (nxtChoice.compareTo("4")==0) {
                if (attendanceMaster.getEmpAttendancedict().size() != 0) {
                    if(empList.size()==0) {
                        attendanceMaster.filterEmployeeList();
                        if (attendanceMaster.getEmpAttendancedict().size() != 0) {
                            System.out.println("The eligible employee list:");
                            attendanceMaster.showEligibleList();
                            toCalculateSalary = true;
                        } else {
                            System.out.println("There is no eligible employee in the list\n");
                            toCalculateSalary = true;
                        }
                    }
                    else{
                        System.out.println("The attendance is not been entered to all the employee\n");
                    }
                } else if (masterData.getEmpList().size() == 0) {
                    System.out.println("No employee detail is entered yet\n");
                } else {
                    System.out.println("The attendance is not been entered yet\n");
                }
            }
            else if (nxtChoice.compareTo("5")==0) {
                int empId;
                int updatedWorkingDays;
                boolean toBreak=false;
                if (masterData.getEmpList().size()!=0){
                    while (true) {
                        try {
                            System.out.println("Enter the employee id:");
                            empId = sc.nextInt();
                            sc.nextLine();
                            if (empId >= 1001 && empId <= masterData.getEmpList().size()+1000) {
                                while (true) {
                                    try {
                                        System.out.println("Enter the number of working days:");
                                        updatedWorkingDays = sc.nextInt();
                                        sc.nextLine();
                                        if (updatedWorkingDays >= 0 && updatedWorkingDays<=30) {
                                            Employee employee=masterData.getEmpList().get(empId-1001);
                                            attendanceMaster.getEmpAttendancedict().put(employee, updatedWorkingDays);
                                            toBreak=true;
                                            toCalculateSalary=false;
                                            empList.remove(employee);
                                            break;
                                        }else if(updatedWorkingDays>=31){
                                            System.out.println("Number of working days should be in the range 0-30\n");
                                        } else {
                                            System.out.println("Working days cannot be negative\n");
                                        }
                                    } catch (InputMismatchException ex) {
                                        System.out.println("Working days should be value\n");
                                        sc.nextLine();
                                    }
                                }
                                if(toBreak){
                                    break;
                                }
                            }
                            else {
                                System.out.println("The employee id is not found\n");
                            }

                        } catch (InputMismatchException ex) {
                            System.out.println("Employee id should be value\n");
                            sc.nextLine();
                        }
                    }
                }
                else{
                    System.out.println("No employee detail is entered yet\n");
                }
            }
            else if (nxtChoice.compareTo("6")==0) {
                if (masterData.getEmpList().size() > 0) {
                    String sortChoice;
                    while (true) {
                        System.out.println("\n1.Sort by name ascending\n2.Sort by name descending\n3.Sort by designation ascending\n4.Sort by designation descending\n5.Sort by department ascending\n6.Sort by department descending\n7.Exit");
                        System.out.println("Enter the choice");
                        sortChoice = sc.nextLine();
                        if (sortChoice.compareTo("1") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h1.getEmpName().compareTo(h2.getEmpName()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        } else if (sortChoice.compareTo("2") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h2.getEmpName().compareTo(h1.getEmpName()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        } else if (sortChoice.compareTo("3") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h1.getDesignation().compareTo(h2.getDesignation()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        } else if (sortChoice.compareTo("4") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h2.getDesignation().compareTo(h1.getDesignation()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        } else if (sortChoice.compareTo("5") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h1.getDepartment().compareTo(h2.getDepartment()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        } else if (sortChoice.compareTo("6") == 0) {
                            masterData.getEmpList().sort((Employee h1, Employee h2) -> h2.getDepartment().compareTo(h1.getDepartment()));
                            System.out.println("Sorted List:");
                            masterData.employeeDetailDisplay();
                        }else if(sortChoice.compareTo("7")==0){
                            break;
                        } else {
                            System.out.println("Invalid choice(Enter the choice 1-6)\n");
                        }
                    }
                }
                else{
                    System.out.println("No employee detail is entered yet\n");
                }
            }
            else if (nxtChoice.compareTo("7")==0) {
                if(masterData.getEmpList().size()==0){
                    System.out.println("No employee detail is entered yet\n");
                }
                else if(attendanceMaster.getEmpAttendancedict().size()==0 && toCalculateSalary){
                    System.out.println("There is no eligible employee in the list\n");
                }
                else if(empList.size()!=0){
                    System.out.println("The attendance is not been entered yet\n");
                }
                else if(toCalculateSalary ) {
                    salCalculator.calculateSalary(attendanceMaster.getEmpAttendancedict());
                }
                else{
                    System.out.println("First filter the eligible employees\n");
                }
            }
            else if (nxtChoice.compareTo("8")==0) {
                break;
            }
            else{
                System.out.println("Invalid choice(Enter choice between 1-8)\n");
            }
        }
    }
}