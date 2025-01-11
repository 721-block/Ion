using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ion.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BodyType
{
    [Display(Name = "Седан")]
    Sedan,
    [Display(Name = "Хэтчбек")]
    Hatchback,
    [Display(Name = "Лифтбэк")]
    Liftback,
    [Display(Name = "Универсал")]
    Universal,
    [Display(Name = "Пикап")]
    Pickup,
    [Display(Name = "Минивэн")]
    Minivan,
    [Display(Name = "Кроссовер")]
    Crossover,
    [Display(Name = "Внедорожник")]
    Offroad,
    [Display(Name = "Купе")]
    Coupe,
    [Display(Name = "Родстер")]
    Roadster,
    [Display(Name = "Кабриолет")]
    Cabriolet
}