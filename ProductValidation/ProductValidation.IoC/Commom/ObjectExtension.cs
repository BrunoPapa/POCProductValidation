using System;

namespace ProductValidation.IoC.Commom
{
    public static class ObjectExtension
    {
        public static int? ToInt(this object obj)
        {
            int result;
            if (int.TryParse(obj.ToString(), out result))
                return result;
            else return null;
        }

        public static DateTime? ToDateTime(this object obj)
        {
            DateTime result;
            if (DateTime.TryParse(obj.ToString(), out result))
                return result;
            else return null;
        }

        public static Decimal? ToDecimal(this object obj)
        {
            Decimal result;
            if (Decimal.TryParse(obj.ToString(), out result))
                return result;
            else return null;
        }

        public static float? ToFloat(this object obj)
        {
            float result;
            if (float.TryParse(obj.ToString(), out result))
                return result;
            else return null;
        }
    }
}
