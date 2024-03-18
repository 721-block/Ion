namespace Ion.Domain.Enums;

[Flags]
public enum Day
{
    Monday = 2,
    Tuesday = 4,
    Wednesday = 8,
    Thursday = 16,
    Friday = 32,
    Saturday = 64,
    Sunday = 128
}