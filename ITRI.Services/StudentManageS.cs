using System;
using System.Collections.Generic;
using System.Linq;
using ITRI.Models;
using ITRI.Models.Entities;
using ITRI.Models.Helper;
using ITRI.Models.Interface;
using ITRI.Services.Interface;
using ITRI.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using ZXing.Rendering;
using ZXing.Common;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ITRI.Services
{
    public class StudentManageS : IStudentManageS
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IRepository<Student> _repository = new Repository<Student>();

        public StudentManageS(JWTSettings jwtSettings)
        {
            jwtSettings = _jwtSettings;
        }



        public DatatablesVM<Student> GetAll(int start, int length)
        {
            var count = _repository.GetAll().Count();

            var data = _repository.GetAll().Skip(start).Take(length);
            var result = new DatatablesVM<Student>
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = data,
            };
            return result;
        }
        public DatatablesVM<Student> TeacherGetAll(int start, int length, int Id)
        {
            var count = _repository.GetAll().Where(c => c.AccountId == Id).Count();

            var data = _repository.GetAll().Where(c => c.AccountId == Id).Skip(start).Take(length);
            var result = new DatatablesVM<Student>
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = data,
            };
            return result;
        }
        public IEnumerable<Student> GetAllStudent(int AccountId)
        {

            var result = _repository.GetAll().Where(c=>c.AccountId == AccountId);
           
            return result;
        }

        public Student GetStudentData(int Id)
        {

            var result = _repository.Get(c => c.Id == Id);

            return result;
        }
        public static byte[] CreateQrCode(string content)
        {
            var qrWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions { Height = 100, Width = 100, Margin = 1}
            };


            var pixelData = qrWriter.Write(content);

            // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference
            // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB
            // the System.Drawing.Bitmap class is provided by the CoreCompat.System.Drawing package
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                // lock the data area for fast access
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                       pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // save to stream as PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Console.WriteLine(content);
                    return ms.ToArray();
            }
        }
  
        public void Create(Student data)
        {
            // TODO: Exception
            _repository.Create(data);
            var _student = _repository.GetAll().Where(c => c.Number == data.Number).Last();
            var qrstr = "http://163.13.243.125:5500/UserLogin.html?Id=" + data.Id.ToString();

            _student.Qrcode = CreateQrCode(qrstr);
            _repository.Update(_student);

        }

        
        public void Delete(int id)
        {
            // TODO: Exception
            var Student = _repository.Get(c => c.Id == id);
            _repository.Delete(Student);
        }

        public DatatablesVM<Student> GetStudentDetail(int Id)
        {
            var count = _repository.GetAll().Where
                        (c => c.Id == Id).Count();
            var data = _repository.GetAll().Where
                         (c => c.Id == Id);

            ;
            var result = new DatatablesVM<Student>
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = data,
            };
            return result;
        }


        public Student GetById(int id)
        {
            var result = _repository.Get(c => c.Id == id);
            return result;
        }

        public void Update(Student data)
        {
            var student = _repository.Get(c => c.Id == data.Id);
         
      
            student.Status = data.Status;
            student.CardNumber = data.CardNumber;

            student.Number = data.Number;
            student.ChineseName = data.ChineseName;
            student.EnglishName = data.EnglishName;
            student.Gender = data.Gender;
            student.Year = data.Year;
            student.Class = data.Class;
            student.ClassNumber = data.ClassNumber;
            student.GoOutWeekends = data.GoOutWeekends;
            student.OvernightWeekends = data.OvernightWeekends;
            student.GoOutWeekdays = data.GoOutWeekdays;
            student.ModifyDate = DateTime.Now;

            _repository.Update(student);
        }
        public void UpdateStudent(Student data)
        {
            var student = _repository.Get(c => c.Id == data.Id);
            student.GoOutWeekends = data.GoOutWeekends;
            student.OvernightWeekends = data.OvernightWeekends;
            student.GoOutWeekdays = data.GoOutWeekdays;
            student.ModifyDate = DateTime.Now;
            _repository.Update(student);
        }
        public Student TurnStatus(int id)
        {
            var result = _repository.Get(c => c.Id == id);
            result.Status = (result.Status == 0) ? Convert.ToByte(1) : Convert.ToByte(0);
            _repository.Update(result);
            return result;
        }

        public Student TurnGoOutWeekdays(int id) {
            var result = _repository.Get(c => c.Id == id);
            result.GoOutWeekdaysT = (result.GoOutWeekdaysT == 0) ? Convert.ToByte(1) : Convert.ToByte(0);
            result.GoOutWeekdaysTime = DateTime.Now;
            _repository.Update(result);
            return result;
        }
        public Student TurnOvernightWeekends(int id) {
            var result = _repository.Get(c => c.Id == id);
            result.OvernightWeekendsT = (result.OvernightWeekendsT == 0) ? Convert.ToByte(1) : Convert.ToByte(0);
            result.OvernightWeekendsTime = DateTime.Now;
            _repository.Update(result);
            return result;
        }
        public Student TurnGoOutWeekends(int id) {
            var result = _repository.Get(c => c.Id == id);
            result.GoOutWeekendsT = (result.GoOutWeekendsT == 0) ? Convert.ToByte(1) : Convert.ToByte(0);
            result.GoOutWeekendsTime = DateTime.Now;
            _repository.Update(result);
            return result;
        }

    }
}
