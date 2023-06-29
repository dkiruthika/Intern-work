import java.util.ArrayList;

public class MasterData {
    private ArrayList<Employee> empList=new ArrayList<>();
    public void addEmployeeToList(Employee emp){
        empList.add(emp);
    }
    public ArrayList<Employee> getEmpList(){
        return empList;
    }
    public void employeeDetailDisplay(){
        System.out.println("______________________________________________________________________________________");
        System.out.printf("%-10s %-20s %-20s %-20s %-10s\n","Id","Name","Department","Designation","Salary");
        System.out.println("______________________________________________________________________________________");
        for(Employee employee:empList){
            System.out.println(employee.toString());
            System.out.println("______________________________________________________________________________________");
        }
    }


}
