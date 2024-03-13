namespace AlRayan.ViewModel.Student
{
    public class StudentIndexViewModel
    {
        public string Name { get; set; }
        public string Photo { get; set; }

        public List<CourseName> CoursesName{ get; set; }=new List<CourseName>();

    }
    public class CourseName
    {
        public string Name { get; set; }
    }
}
