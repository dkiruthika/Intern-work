import java.util.HashMap;
import java.util.Iterator;
public class AttendanceMaster {
    private HashMap<Employee,Integer> empAttendancedict=new HashMap<Employee,Integer>();
    public HashMap<Employee,Integer> getEmpAttendancedict(){return empAttendancedict;}
    public void showEligibleList(){
        System.out.println("______________________________________________________________________________________");
        System.out.printf("%-10s %-20s %-20s %-20s %-10s\n","Id","Name","Department","Designation","Salary");
        System.out.println("______________________________________________________________________________________");
            for (Employee employee : empAttendancedict.keySet()) {
                if (empAttendancedict.get(employee) > 10) {
                    System.out.println(employee.toString());
                    System.out.println("______________________________________________________________________________________");
                }
            }

    }
    public void filterEmployeeList() {
        Iterator<Employee> it = empAttendancedict.keySet().iterator();
        while (it.hasNext()) {
            Employee employee = it.next();
            int attendance = empAttendancedict.get(employee);
            if (attendance < 10) {
                it.remove();
            }
        }

    }
}
