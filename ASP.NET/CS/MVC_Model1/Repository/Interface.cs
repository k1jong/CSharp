using MVC_Model2.Models;

namespace MVC_Model2.Repository
{
	public interface Interface
	{
		List<Student> getAllStudents();
		Student getStudent(int id);
	}
}
