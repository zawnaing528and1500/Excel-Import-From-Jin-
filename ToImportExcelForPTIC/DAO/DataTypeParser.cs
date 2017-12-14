using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    /// <summary>
    /// Primative data type conversion utility
    /// </summary>
    class DataTypeParser
    {
        /// <summary>
        /// Convert an object to another object and return default value when null or error is found
        /// </summary>
        /// <param name="from">Source object</param>
        /// <param name="to">Type to be converted</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Return object specified by a destination type</returns>
        public static object Parse(object from, Type to, object defaultValue)
        {
            if (from == null && to == typeof(decimal))
                return Convert.ToDecimal(DataTypeParser.Parse(defaultValue, typeof(decimal), 0)); // System.InvalidCastException was found if Convert is not supplied
            else if(from == null)
                return defaultValue;
            else if (to == typeof(string) && from.ToString() == "0" || from.ToString() == "0.0")
                return defaultValue;
            try
            {
                if (to == typeof(int))
                {
                    //int result = 0;
                    //int.TryParse(from.ToString(), out result);
                    //Convert.ToInt32(from.ToString())
                    //return result;                    
                    return Convert.ToInt32(from);
                }
                else if (to == typeof(float))
                {
                    float result = 0;
                    float.TryParse(from.ToString(), out result);
                    return result;
                }
                else if (to == typeof(double))
                {
                    double result = 0;
                    double.TryParse(from.ToString(), out result);
                    return result;
                }
                else if (to == typeof(bool))
                {
                    return Convert.ToBoolean(from);

                    //bool result = false;
                    //bool.TryParse(from.ToString(), out result);
                    //return result;
                }
                else if(to == typeof(string))
                {
                    return from.ToString();
                }
                else if (to == typeof(char))
                {
                    return Convert.ToChar(from);
                }
                else if (to == typeof(DateTime))
                {
                    //DateTime result = DateTime.MinValue;
                    //DateTime.TryParse(from.ToString(), out result);
                    //if (result <= DateTime.MinValue || result >= DateTime.MaxValue)
                    //    result = DateTime.Now;
                    return DateTime.Parse(from.ToString());
                }
                else if (to == typeof(decimal))
                {
                    decimal result =0;
                    if (from != DBNull.Value)
                        decimal.TryParse(from.ToString(), out result);
                    else
                        result = decimal.Parse(defaultValue + string.Empty);
                    return result;
                }
                // else if (to == typeof(bool))
                // else if....
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
            return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static float ParseToFloat(object from)
        {
            float result = 0;
            if (from == null)
                return result;            
            float.TryParse(from.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static decimal PointOnePlace(decimal number)
        {
            decimal result = Math.Round(number, 2);
            return result;
        }
    }
}
