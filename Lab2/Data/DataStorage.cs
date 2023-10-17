using System.IO;
using System.Text.Json;

class DataStorage
{
    private static string studentsDataFile = "students.json";
    private static string facultiesDataFile = "faculties.json";

    public static void SaveStudents(List<Student> students)
    {
        string studentsJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentsDataFile, studentsJson);
    }

    public static List<Student> LoadStudents()
    {
        if (File.Exists(studentsDataFile))
        {
            string studentsJson = File.ReadAllText(studentsDataFile);
            return JsonSerializer.Deserialize<List<Student>>(studentsJson);
        }
        else
        {
            return new List<Student>();
        }
    }

    public static void SaveFaculties(List<Faculty> faculties)
    {
        string facultiesJson = JsonSerializer.Serialize(faculties);
        File.WriteAllText(facultiesDataFile, facultiesJson);
    }

    public static List<Faculty> LoadFaculties()
    {
        if (File.Exists(facultiesDataFile))
        {
            string facultiesJson = File.ReadAllText(facultiesDataFile);
            return JsonSerializer.Deserialize<List<Faculty>>(facultiesJson);
        }
        else
        {
            return new List<Faculty>();
        }
    }
}
