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
        for(Employee employee:empList){
            System.out.println("-------------Employee detail of "+employee.getEmpId()+"-------------");
            System.out.println(employee.toString());
        }
    }


}
