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
            RuleFor(sv => sv.namsinh)
                .GreaterThanOrEqualTo(1999).WithMessage("Age is invalid")
                .LessThanOrEqualTo(2006).WithMessage("Age is invalid");
            RuleFor(sv => sv.tensv)
                .NotEmpty().WithMessage("Studen name is not blank");    

        }
    }
}
