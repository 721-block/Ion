using System.ComponentModel.DataAnnotations;

namespace Ion.Domain.Enums;

public enum GearboxType
{
    [Display(Name = "Механика")]
    Mechanic,
    [Display(Name = "Автомат")]
    Automatic,
    [Display(Name = "Вариатор")]
    Stepless,
    [Display(Name = "Робот")]
    Robotic
}