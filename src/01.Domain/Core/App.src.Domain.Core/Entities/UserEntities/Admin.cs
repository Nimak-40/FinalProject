using System.ComponentModel.DataAnnotations;

namespace App.src.Domain.Core.Entities.UserEntities
{
    public class Admin
    {
        #region Properties
        [Key]
        public string? AdminCode { get; set; }
        public int Id { get; set; }


        #endregion

        #region NavigationProperties
        public int UserId { get; set; }
        public User? User { get; set; }
        #endregion

    }
}

