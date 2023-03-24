using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using HomeWork1.Base;
namespace HomeWork1.Data;

public class Staff : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    [NotMapped]
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}
public class StaffValidator : AbstractValidator<Staff> 
{
    public StaffValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.CreatedBy).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(p => p.FirstName)
        .NotEmpty()
        .Length(2, 25).WithMessage("{PropertyName} En Az 2 En Fazla 5 Karakterden Oluşmalıdır.");
        RuleFor(x => x.LastName).Length(2, 50).WithMessage("{PropertyName} En Az 2 En Fazla 5 Karakterden Oluşmalıdır.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Giriniz.");
        RuleFor(x => x.Phone).Length(10).WithMessage("Lütfen başında sıfır(0) olmadan telefon numaranızı giriniz.");
        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz.");
        RuleFor(x => x.Province).NotEmpty().WithMessage("{PropertyName} Alanı Boş Bırakılamaz."); ;

        
    }

}

