import java.util.HashMap;

public class SalCalculator {
    public void calculateSalary(HashMap<Employee,Integer> employeeDictionary){
        for (Employee employee : employeeDictionary.keySet()) {
            double salary=employee.getSalary();
            employee.setAllowance();
            double pf=salary*0.1;
            double gross=employee.getSalary();
            double net=gross-pf;
            String empDetails=employee.toString();
            empDetails=empDetails+salary+"\t"+pf+"\t"+gross+"\t"+net;
            System.out.println(empDetails);

        }

    }

}
