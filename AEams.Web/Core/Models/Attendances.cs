using System.ComponentModel.DataAnnotations.Schema;

namespace AEams.Web.Core.Models;

public class Attendances
{
    public int Id { get; set; }
    public string? EmpNumber { get; set; }
   
    public DateTime? Date { get; set; }
    public TimeSpan? Time { get; set; }
}
