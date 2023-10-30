using Domain.Models.Lectures;

namespace Domain.Models.Courses;

public class UserSaleCourse 
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string UserName { get; set; }
}


 public class UpCommingClasse
{

    public int userId { get; set; }
    public string CourseName { get; set;}
    public List<Lecture> Online { get; set; }
    public List<Lecture> OffLine { get; set; }
}