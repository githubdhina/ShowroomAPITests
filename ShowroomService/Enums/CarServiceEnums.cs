
namespace ShowroomService.Enums
{
    public enum CarTypes
    {
        [System.ComponentModel.Description("saloon")]
        Saloon,
        [System.ComponentModel.Description("hatchback")]
        Hatchback,
        [System.ComponentModel.Description("suv")]
        SUV
    }

    public class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            System.ComponentModel.DescriptionAttribute attribute = value.GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)
            .SingleOrDefault() as System.ComponentModel.DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
