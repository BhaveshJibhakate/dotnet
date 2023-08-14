namespace BOL
{

    public enum Department { HR,SALES}

    public class Employee
    {
        public int id;
        public string firstname;
        public string lastname;
        public Department department;
        public DateOnly joindate;

        public Employee() {
        }

        public Employee(int id, string firstname, string lastname, Department department, DateOnly joindate)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.department = department;
            this.joindate = joindate;
        }

        public int ID {
            get { return this.id; }
            set { this.id = value; }
        }

        public string FIRSTNAME{
            get { return this.firstname; }
             set { this.firstname = value; }
        }

        public string LASTNAME { 
           get { return this.lastname; }
           set { this.lastname = value; }
        }

        public Department DEPARTMENT { 
             get { return this.department; }
             set { this.department = value; }
        }

        public DateOnly JOINDATE
        {
            get { return this.joindate ; }
            set { this.joindate = value ; }
        
        }

        public override string ToString()
        {
            return $"{this.id} {this.firstname} {this.lastname} {this.department} {this.joindate}";
        }
    }
}