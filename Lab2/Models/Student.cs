using System;
public class Student {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public DateTime EnrollmentDate {get; set;}
    public DateTime DateOfBirth {get; set;}
    public bool Graduated {get; set;}
    public Faculty Faculty { get; set; }

    public Student(string firstName, string lastName, string email, DateTime enrollmentDate, DateTime dateOfBirth, bool graduated) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        EnrollmentDate = enrollmentDate;
        DateOfBirth = dateOfBirth;
    }

    public string GetName(){
        return $"{FirstName} {LastName}";
    }
}