import java.util.HashMap;

public class SalCalculator {
    public void calculateSalary(HashMap<Employee,Integer> employeeDictionary){
        System.out.println("_________________________________________________________________________________________________________________________________________________");
        System.out.printf("%-19s %-20s %-20s %-20s %-10s %-10s %-10s %-10s %-19s\n","Id","Name","Department","Designation","Salary","Pf","Gross","Net","No of working days");
        System.out.println("________________________________________________________________________________________________________________________________________________");
        for (Employee employee : employeeDictionary.keySet()) {
            double salary=employee.getOriginalSalary();
            double pf=salary*0.1;
            double gross=employee.getSalary();
            double net=gross-pf;
            System.out.printf("%-19d %-20s %-20s %-20s %-10.2f %-10.2f %-10.2f %-10.2f %-22d\n",employee.getEmpId(),employee.getEmpName(),employee.getDepartment(),employee.getDesignation(),salary,pf,gross,net,employeeDictionary.get(employee));
            System.out.println("_________________________________________________________________________________________________________________________________________________");
        }

    }

}
