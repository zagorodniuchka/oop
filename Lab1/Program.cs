using System;
public class Person {
    public string Name {get; set;}
    public int Age {get; set;}
    public string Work {get; set;}
    public bool IsMarried {get; set;}
	
	public Person(string name, int age, string work, bool isMarried) {
        Name = name;
        Age = age;
        Work = work;
        IsMarried = isMarried;
    }

    public void Hello(){
        Console.WriteLine($"Hello! My name is {Name}. I am {Age} years old. I work at {Work}.");
    }
    public void Marriage(){
        if (IsMarried){
            System.Console.WriteLine("I am married");
        }else{
            System.Console.WriteLine("I am not married");
        }
    }
}

public class Program {
    public static void Main() {
        Person person = new Person("Anastasia", 19, "Galex Studio", false);
        person.Hello();
        person.Marriage();
    }
}