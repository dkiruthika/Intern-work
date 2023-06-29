
import java.util.HashMap;
import java.util.Scanner;

public class AttendanceMaster {
    HashMap<Employee,Integer> empAttendancedict=new HashMap<Employee,Integer>();;

    public void showEligibleList(){
        if(empAttendancedict.size()==0){
            System.out.println("Number of working days is not entered");
        }
        else {
            System.out.println("Eligible employee list:");
            for (Employee employee : empAttendancedict.keySet()) {
                if (empAttendancedict.get(employee) > 10) {
                    System.out.println("-------------Employee detail of "+employee.getEmpId()+"-------------");
                    System.out.println(employee.toString());
                    System.out.println("Number of working days:"+empAttendancedict.get(employee));
                }
            }
        }
    }
}
