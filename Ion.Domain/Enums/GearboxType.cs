using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ion.Domain.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
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