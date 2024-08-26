using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Data;
public class StudentMetadata{

    [Display(Name ="First Name")]
    public string FirstName { get; set; } = null!;
    [Display(Name ="Last Name")]
    public string LasrtName { get; set; } = null!;

    [Display(Name ="Date Of Birth ")]
    public DateOnly? DateOfBirth { get; set; }
}
[ModelMetadataType(typeof(StudentMetadata))]
public partial class Student{}