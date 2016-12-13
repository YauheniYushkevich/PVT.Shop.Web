using System.ComponentModel.DataAnnotations;

namespace PVT.Shop.Infrastructure.Common
{
    public abstract class BaseModel
    {
        [Required(ErrorMessage = "Пустое поле Id")]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}