using System.ComponentModel.DataAnnotations;

namespace Ion.Domain.Enums;

[Flags]
public enum Day
{
    [Display(Name = "Понедельник")]
    Monday = 2,
    [Display(Name = "Вторник")]
    Tuesday = 4,
    [Display(Name = "Среда")]
    Wednesday = 8,
    [Display(Name = "Четверг")]
    Thursday = 16,
    [Display(Name = "Пятница")]
    Friday = 32,
    [Display(Name = "Суббота")]
    Saturday = 64,
    [Display(Name = "Воскресенье")]
    Sunday = 128
}