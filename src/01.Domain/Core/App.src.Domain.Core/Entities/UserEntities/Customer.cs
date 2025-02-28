using App.src.Domain.Core.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.UserEntities
{
    public class Customer
{
    #region Properties
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    #endregion


    #region NavigationProperties
    public int CityId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Order> Orders { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    #endregion
}
}

