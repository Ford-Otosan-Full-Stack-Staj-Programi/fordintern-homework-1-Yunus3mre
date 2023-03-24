using FluentValidation;
using FluentValidation.Results;
using HomeWork1.Data;
using Microsoft.AspNetCore.Mvc;


namespace PatikaHafta1_Hw.Controllers;

[Route("patika/hw1/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private AppDbContext context;
    private IValidator<Staff> validator;

    public StaffController(IUnitOfWork unitOfWork, AppDbContext context, IValidator<Staff> validator)
    {
        this.unitOfWork = unitOfWork;
        this.context = context;
        this.validator = validator;
    }

    [HttpGet]
    public List<Staff> GetAll()
    {
        return unitOfWork.StaffRepository.GetAll();
    }
    [HttpGet("{id}")]
    public dynamic GetById(int id)
    {

        try
        {
            var result= unitOfWork.StaffRepository.GetById(id);
            if (result==null)
            {

                return "Böyle Bir Kullanıcı Bulunmadı.";
            }
            else
            {
                return result;
            }
            
        }
        catch (Exception)
        {

            throw;
        }

       
       
    }
    [HttpPut("{id}")]
    public string Update([FromBody] Staff staff, int id)
    {
        try
        {
            ValidationResult result = validator.Validate(staff);
            if (result.IsValid) 
            {
                staff.Id = id;
                unitOfWork.StaffRepository.Update(staff);
                unitOfWork.Complete();
                return "Güncelleme İşlemi Başarılı";
            }
            else
            {
                return result.ToString();
            }
            
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
        
    }
    [HttpPost]
    public  string Insert([FromBody] Staff staff)
    {
        try
        {
            ValidationResult result = validator.Validate(staff);

            if (result.IsValid)
            {
                unitOfWork.StaffRepository.Insert(staff);
                unitOfWork.Complete();
                return "Kayıt İşlemi Başarılı";

            }
            else
            {
                return result.ToString();

            }
        }
        catch (Exception e)
        {

            return e.ToString();
        }
        
    }
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        try
        {
            unitOfWork.StaffRepository.Remove(id);
            unitOfWork.Complete();
            return "Silme İşlemi Başarılı";
        }
        catch (Exception e)
        {

            return e.Message;
        }
        
    }
   
    [HttpGet("Filter")]
    public IEnumerable<Staff> Filter(string lastName,string firstName)
    {
        return unitOfWork.StaffRepository.Filter(staffUser => staffUser.LastName.Contains(lastName) || staffUser.FirstName.Contains(firstName));
    }


}

