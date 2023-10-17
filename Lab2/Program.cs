using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();
    static List<Faculty> faculties = new List<Faculty>();
    private static Dictionary<string, StudyFieldEnum> facultyToField = new Dictionary<string, StudyFieldEnum>
    {
        { "Stiinta Datelor", StudyFieldEnum.SoftwareEngineering},
        { "Automatica si Informatica", StudyFieldEnum.SoftwareEngineering },
        { "Calculatoare si retele", StudyFieldEnum.SoftwareEngineering },
        { "Electronica Aplicata", StudyFieldEnum.SoftwareEngineering },
        { "Informatica Aplicata", StudyFieldEnum.SoftwareEngineering },
        { "Ingineria software", StudyFieldEnum.SoftwareEngineering },
        { "Indinerie Biomedicala", StudyFieldEnum.SoftwareEngineering },
        { "Managementul Informational", StudyFieldEnum.SoftwareEngineering },
        { "Microelectronica si nanotehnologii", StudyFieldEnum.SoftwareEngineering },
        { "Robotica si mecatronica", StudyFieldEnum.SoftwareEngineering },
        { "Securitate Informationala", StudyFieldEnum.SoftwareEngineering },
        { "Tehnologia Informatiei", StudyFieldEnum.SoftwareEngineering },
        { "Urbanism si Design Urban", StudyFieldEnum.UrbanismArchitecture },
        { "Alimentari cu Caldura, Apa, Gaze si Protectia Mediului", StudyFieldEnum.UrbanismArchitecture },
        { "Departamentul Ingineria Infrastructurii Transporturilor", StudyFieldEnum.UrbanismArchitecture },
        { "Arhitectura", StudyFieldEnum.UrbanismArchitecture },
    };

    static List<Faculty> GetFaculties()
    {
        return faculties;
    }

    static bool IsStudentInFaculty(string studentEmail, string facultyAbbreviation)
    {
        Student student = students.FirstOrDefault(s => s.Email == studentEmail);
        if (student != null && student.Faculty != null)
        {
            return student.Faculty.Abbreviation == facultyAbbreviation;
        }
        return false;
    }
    static string GetFacultyForStudent(string studentEmail)
    {
        Student student = students.FirstOrDefault(s => s.Email == studentEmail);

        if (student != null && student.Faculty != null)
        {
            return student.Faculty.Name;
        }

        return "Студент не найден или не учится на каком-либо факультете.";
    }


    static void Main()
    {
        students = DataStorage.LoadStudents();
        faculties = DataStorage.LoadFaculties();
        
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Добавить факультет");
            Console.WriteLine("3. Приписать студента к факультету");
            Console.WriteLine("4. Отметить студента как выпускника");
            Console.WriteLine("5. Просмотреть список учащихся");
            Console.WriteLine("6. Просмотреть список выпускников");
            Console.WriteLine("7. Просмотреть список факультетов");
            Console.WriteLine("8. Проверить принадлежность студентов к факультету");
            Console.WriteLine("9. Найти факультет студента по его почте");
            Console.WriteLine("10. Вывести список специальностей в зависимоcти от направления");
            Console.WriteLine("11. Выйти из программы");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddFaculty();
                    break;
                case "3":
                    AssignStudentToFaculty();
                    break;
                case "4":
                    MarkStudentAsGraduated();
                    break;
                case "5":
                    List<Student> enrolledStudents = GetEnrolledStudents();
                    Console.WriteLine("Список учащихся:");
                    foreach (var student in enrolledStudents)
                    {
                        Console.WriteLine($"{student.GetName()} - Email: {student.Email}");
                    }
                    break;
                case "6":
                    List<Student> graduatedStudents = GetGraduatedStudents();
                    GetGraduatedStudents();
                    Console.WriteLine("Список выпускников:");
                    foreach (var student in graduatedStudents)
                    {
                        Console.WriteLine($"{student.GetName()} - Email: {student.Email}");
                    }
                    break;
                case "7":
                    List<Faculty> facultyList = GetFaculties();

                    if (facultyList.Count > 0)
                    {
                        Console.WriteLine("Список факультетов:");
                        foreach (var faculty in facultyList)
                        {
                            Console.WriteLine($"{faculty.Name} - Аббревиатура: {faculty.Abbreviation}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Нет зарегистрированных факультетов.");
                    }
                    break;
                case "8":
                    Console.Write("Введите адрес электронной почты студента: ");
                    string studentEmail1 = Console.ReadLine();
                    Console.Write("Введите аббревиатуру факультета для проверки: ");
                    string facultyAbbreviation = Console.ReadLine();

                    if (IsStudentInFaculty(studentEmail1, facultyAbbreviation))
                    {
                        Console.WriteLine($"Студент с адресом {studentEmail1} относится к факультету {facultyAbbreviation}.");
                    }
                    else
                    {
                        Console.WriteLine($"Студент с адресом {studentEmail1} не относится к факультету {facultyAbbreviation}.");
                    }
                    break;
                case "9":
                    Console.Write("Введите адрес электронной почты студента: ");
                    string studentEmail2 = Console.ReadLine();

                    string facultyName = GetFacultyForStudent(studentEmail2);

                    Console.WriteLine($"Студент с адресом {studentEmail2} учится на факультете: {facultyName}");
                    break;
                case "10":
                    DisplayAbbreviationsByField();
                    break;
                case "11":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 1 до 11.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Введите имя студента: ");
        string firstName = Console.ReadLine();
        Console.Write("Введите фамилию студента: ");
        string lastName = Console.ReadLine();
        Console.Write("Введите адрес электронной почты студента: ");
        string email = Console.ReadLine();
        Console.Write("Введите дату поступления студента (гггг-мм-дд): ");
        DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Введите дату рождения студента (гггг-мм-дд): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        Student student = new Student(firstName, lastName, email, enrollmentDate, dateOfBirth, false);
        students.Add(student);
        DataStorage.SaveStudents(students);

        Console.WriteLine("Студент успешно добавлен.");
    }

    static void AssignStudentToFaculty()
    {
        Console.Write("Выберите студента по номеру (от 1 до " + students.Count + "): ");
        int studentIndex = int.Parse(Console.ReadLine()) - 1;

        if (studentIndex >= 0 && studentIndex < students.Count)
        {
            Console.Write("Введите название факультета: ");
            string facultyName = Console.ReadLine();
            Console.Write("Введите сокращение факультета: ");
            string facultyAbbreviation = Console.ReadLine();

            Faculty faculty = new Faculty(facultyName, facultyAbbreviation);
            students[studentIndex].Faculty = faculty;
            DataStorage.SaveStudents(students);

            Console.WriteLine("Студент успешно приписан к факультету.");
        }
        else
        {
            Console.WriteLine("Неверный номер студента.");
        }
    }

    static void MarkStudentAsGraduated()
    {
        Console.Write("Выберите студента по номеру (от 1 до " + students.Count + "): ");
        int studentIndex = int.Parse(Console.ReadLine()) - 1;

        if (studentIndex >= 0 && studentIndex < students.Count)
        {
            students[studentIndex].Graduated = true;
            DataStorage.SaveStudents(students);
            Console.WriteLine("Студент успешно отмечен как выпускник.");
        }
        else
        {
            Console.WriteLine("Неверный номер студента.");
        }
    }
    
    static List<Student> GetEnrolledStudents()
    {
        return students.Where(student => student.Graduated == false).ToList();
    }

    static List<Student> GetGraduatedStudents()
    {
        return students.Where(student => student.Graduated == true).ToList();
    }

   static void AddFaculty()
    {
        Console.Write("Введите название факультета: ");
        string name = Console.ReadLine();
        Console.Write("Введите аббревиатуру факультета: ");
        string abbreviation = Console.ReadLine();
        Faculty faculty = new Faculty(name, abbreviation);
        faculties.Add(faculty);
        Console.WriteLine("Факультет успешно добавлен.");
        DataStorage.SaveFaculties(faculties);
    }

   static void DisplayAbbreviationsByField()
   {
        Console.Write("Введите направление \n 1 - MechanicalEngineering \n 2 - SoftwareEngineering \n 3 - FoodTechnology \n 4 - UrbanismArchitecture \n 5 - VeterinaryMedicine: ");
        if (Enum.TryParse(Console.ReadLine(), out StudyFieldEnum field))
        {
            Console.WriteLine($"Факультеты в направлении {field}:");
            bool found = false;

            foreach (var pair in facultyToField)
            {
                if (pair.Value == field)
                {
                    Console.WriteLine($"{pair.Key}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Нет факультетов в направлении {field}.");
            }
        }
        else
        {
            Console.WriteLine("Неверное направление. Пожалуйста, используйте одно из: 1 (MechanicalEngineering), 2 (SoftwareEngineering), 3 (FoodTechnology), 4 (UrbanismArchitecture), 5 (VeterinaryMedicine).");
        }
    }
}
