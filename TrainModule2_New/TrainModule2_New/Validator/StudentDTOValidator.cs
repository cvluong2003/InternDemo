using FluentValidation;

using TrainModule2_New.DTOs;
namespace TrainModule2_New.Validator
{
    public class StudentDTOValidator:AbstractValidator<SinhVienDTO>
    {

        public StudentDTOValidator() {
            RuleFor(sv => sv.masv)
                .NotEmpty().WithMessage("Student code is not blank")
                .Length(2).WithMessage("Student code must have 2 charaters");

            RuleFor(sv => int.Parse(sv.namsinh.Substring(0,4)))
                //.Must(ns=>ns==null).WithMessage("Vui lòng điền đầy đử năm sinh")
                //.Transform(ns =>customNamSinh(ns)!=0?customNamSinh(ns):null)
                    
                .GreaterThanOrEqualTo(1999).WithMessage("Age is invalid (Greater)")
                .LessThanOrEqualTo(2003).WithMessage("Age is invalid (Lower)");
            //.Must( GreaterThanOrEqualNamSinh).WithMessage("Age is invalid")
            //.Must( LessThanOrEqualNamSinh).WithMessage("Age is invalid");
            RuleFor(sv => sv.tensv)
                .NotEmpty().WithMessage("Studen name is not blank");
           
               
        }
        //public bool GreaterThanOrEqualNamSinh(string namsinh)
        //{
        //    try
        //    {
        //        DateTime timeInput = DateTime.Parse(namsinh);
        //        DateTime timeHook = new DateTime(1999, 01, 01);
        //        if (timeInput >= timeHook)
        //            return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return false;

            
        //}
        //public bool LessThanOrEqualNamSinh(string namsinh)
        //{
        //    try
        //    {
        //        DateTime timeInput = DateTime.Parse(namsinh);
        //        DateTime timeHook = new DateTime(2006, 30, 12);
        //        if (timeInput <= timeHook)
        //            return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return false;


        //}
    }
}
