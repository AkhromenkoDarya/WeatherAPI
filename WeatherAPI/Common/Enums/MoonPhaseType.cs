using System.Runtime.Serialization;

namespace WeatherAPI.Common.Enums
{
    public enum MoonPhaseType
    {
        [EnumMember(Value = "First Quarter")]
        FirstQuarter,

        [EnumMember(Value = "Full Moon")]
        FullMoon,

        [EnumMember(Value = "Last Quarter")]
        LastQuarter,

        [EnumMember(Value = "New Moon")]
        NewMoon,

        [EnumMember(Value = "Waning Crescent")]
        WaningCrescent,

        [EnumMember(Value = "Waning Gibbous")]
        WaningGibbous,

        [EnumMember(Value = "Waxing Crescent")]
        WaxingCrescent,

        [EnumMember(Value = "Waxing Gibbous")]
        WaxingGibbous
    }
}