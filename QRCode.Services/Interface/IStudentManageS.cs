using System.Collections.Generic;
using QRCode.Models.Entities;
using QRCode.ViewModels;
using Newtonsoft.Json.Linq;

namespace QRCode.Services.Interface
{
    public interface IStudentManageS
    {
        DatatablesVM<Student> GetAll(int start, int length);
        DatatablesVM<Student> TeacherGetAll(int start, int length, int Id);

        IEnumerable<Student> GetAllStudent(int AccountId);
        Student GetStudentData(int Id);
        void Create(Student data);
        void Delete(int id);
        DatatablesVM<Student> GetStudentDetail(int Id);
        Student GetById(int id);
        void Update(Student data);
        void UpdateStudent(Student data);
        Student TurnStatus(int id);
        Student TurnGoOutWeekdays(int id);
        Student TurnOvernightWeekends(int id);
        Student TurnGoOutWeekends(int id);
    }
}
