using MVC_Model2.Models;

namespace MVC_Model2.Repository
{
	public class StudentRepository : Interface
	{
		public List<Student> getAllStudents()
		{
			return DataSource();
		}

		public List<Student> DataSource()
		{
			int i = 1;
			var students = new List<Student>()
			{
				new Student() {Id=i++,Name="Kim",HP="010-1111-1111",Major="CS"},
				new Student() {Id=i++,Name="Lee",HP="010-1111-1111",Major="CS"},
				new Student() {Id=i++,Name="Park",HP="010-1111-1111",Major="CS"},
				new Student() {Id=i++,Name="Choi",HP="010-1111-1111",Major="CS"}
			};

			return students;
		}

		public Student getStudent(int id)
		{
			return DataSource().Where(x => x.Id == id).FirstOrDefault();
		}
	}
}
