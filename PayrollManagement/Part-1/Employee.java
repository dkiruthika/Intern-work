
    class Employee{
        private  int empId;
        public static int empIdCounter=1001;
        private String empName;
        private String empDepartment;
        private String empDesignation;
        private double empSalary;
        public void setEmpId(int id){
            this.empId=id;
        }
        public int getEmpId(){
            return empId;
        }
        public void setEmpName(String name){
            this.empName=name;
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
        public void setSalary(double salary){
            this.empSalary=salary;
        }
        public double getSalary(){
            return empSalary;
        }
        public Employee(){
            this.empId=empIdCounter++;
            this.empName="";
            this.empDepartment="";
            this.empDesignation="";
            this.empSalary=0;

        }
        public Employee(String name,String department,String designation,double salary){
            this.empId=empIdCounter++;
            this.empName=name;
            this.empDepartment=department;
            this.empDesignation=designation;
            this.empSalary=salary;
        }
        public double setAllowance(){
            if(this.empDesignation.toUpperCase().compareTo("MANAGER")==0){
                return this.empSalary+0.2*this.empSalary;

            }else
            {
                return this.empSalary+0.1*this.empSalary;
            }
        }
        public String toString(){
            return "Id:"+this.empId+"  Name:"+this.empName+"  Department:"+this.empDepartment+"  Designation:"+this.empDesignation+"  Salary:"+this.empSalary;
        }
    }
