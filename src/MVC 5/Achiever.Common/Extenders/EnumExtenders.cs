namespace Achiever.Common.Extenders
{
    using System;

    public static class EnumExtenders
    {
        public static T RandomEnumValue<T>()
        {
            Array enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(new Random().Next(enumValues.Length));
        }
    }
}