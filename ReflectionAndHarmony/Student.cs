namespace ReflectionAndHarmony;

public class Student
{
    public string FullName { get; set; }
    public int ClassNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public string GetCharacteristics()
    {
        return "student-characteristics";
    }
}