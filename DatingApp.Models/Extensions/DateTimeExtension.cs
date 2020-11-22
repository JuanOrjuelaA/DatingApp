namespace DatingApp.Models.Extensions
{
    using System;

    public static class DateTimeExtension
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfBirth"></param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime dayOfBirth)
        {
            var age = DateTime.Today.Year - dayOfBirth.Year;
            if (dayOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}