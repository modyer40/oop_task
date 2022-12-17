using System;
public class Person{
    private string _name;   
    public string Name
    {
        get 
        {
            return _name;
        }
        set
        {
            if(value == null || value == "" || value.Length >= 32)
            {
                throw new Exception("Invalid name");
            } 

            _name = value;
        }
    }

    private int _Age;
    public Person(string name, int age)
    {
        if(name == null || name == "" || name.Length >= 32)
        {
            throw new Exception("Invalid name");
        } 
        if (age <= 0 || age >= 128)
        {
            Console.WriteLine("Invalid age");
            return;
        }

        Name = name;
        _Age = age;
    }
 
    public int Getage() =>_Age;
 
 
    public virtual void Print()
    {
      Console.WriteLine($"My name is {Name}, My age is {_Age}");
    }

}

public class Student : Person
{
    private int _Year;
    public int Year
    {
        get 
        {
            return _Year;
        } 
        set
        {
            _Year=value;
        }   
    }
    private float _Gpa;
    public float Gpa
    {
       get 
        {
            return _Gpa;
        } 
        set
        {
            _Gpa=value;
        }      
    }
    public Student(string name, int age, int year, float gpa):base(name, age)
    {
        if (year < 1 || year > 5)
        {
            throw new Exception("Invalid year");
        }
        if(gpa < 0 || gpa > 4)
        {
            throw new Exception("Invalid gpa");
        }
        Year = year;
        Gpa = gpa; 
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, My age is {Getage()},and My gpa is {Gpa}");
    }
}

public class Staff :Person 
{
    private int _JoinYear;
    public int JoinYear
    {
        get 
        {
            return _JoinYear;
        } 
        set
        {
            _JoinYear=value;
        }   
    }
    private double _Salary;
    public double Salary
    {
        get 
        {
            return _Salary;
        } 
        set
        {
            _Salary=value;
        }   
    }
    public Staff(string name, int age, int joinyear, double salary):base(name, age)
    
    {
        if(salary <= 0 || salary > 120000)
        {
           throw new Exception("Invalid salary");  
        }
        if(joinyear != (age+21))
        {
             throw new Exception("Invalid join year");
        }
        Salary = salary;
        JoinYear = joinyear;
    }
     public override void Print()
    {
        Console.WriteLine($"My name is {Name}, My age is {Getage()} and My salary is {Salary:C}");
    }
}
public class Database
{
    private int _current = 0;   
    public Person [] People = new Person [50];

    public void Addperson (Person person)
    {
        // if (_current==49) return; 
        People[_current++] = person; 
    }

    public void Addstudent (Student student)
    {
        // if (_current==49) return; 
        People[_current++] = student; 
    }

    public void Addstaff (Staff staff)
    {
        // if (_current==49) return; 
        People[_current++] = staff; 
    }

    public void PrintAll()
    {
        for(var i = 0 ; i < _current; i++)
        {
            People[i].Print();
        }
    } 
}

public class program{
    private static void Main(string[] args) 
    {
        var database = new Database();

        var number = 0;
        while (number != 5)
        {
            Console.WriteLine("==========================================================");
            Console.Write("1- Student\n2- Staff\n3- Person\n4- Print\n5- Exit\nEnter your choice: ");
            number = Convert.ToInt32( Console.ReadLine());

            if (number == 1)
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Age: ");
                var age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Year: ");
                var year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Gpa: ");
                var gpa = Convert.ToSingle(Console.ReadLine());

                try
                {
                    Student student = new Student(name, age, year, gpa);
                    database.Addstudent(student);
                }
                catch
                {
                    Console.WriteLine("Invalid input"); 
                }
            }
            else if(number == 2)
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Age: ");
                var age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Join year: ");
                var joinyear = Convert.ToInt32(Console.ReadLine());

                Console.Write("Salary: "); 
                var salary = Convert.ToDouble(Console.ReadLine());

                try
                {
                    var staff = new Staff (name, age, joinyear, salary);
                    database.Addstaff(staff);  
                }
                catch
                {
                    Console.WriteLine("Invalid input");      
                }
            }
            else if(number == 3)
            {
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Age: ");
                var age = Convert.ToInt32(Console.ReadLine());

                try
                {
                    var person = new Person (name, age);
                    database.Addperson(person);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            else if(number == 4) 
            {
                database.PrintAll();  
            }

            else if(number == 5)
            {
                Console.WriteLine("Thanks for using the program.");
            }

            else
            {
                Console.WriteLine("Wrong input.");
            }
        }
    }
}
