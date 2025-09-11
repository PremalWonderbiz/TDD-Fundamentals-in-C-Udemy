
namespace AgeCalculatorApplication
{
    public class AgeCalculator
    {
        public object GetAge(DateTime birthDate, DateTime targetDate)
        {
            var differenceInYears = targetDate.Year - birthDate.Year;
            if (birthDate.Month >  targetDate.Month)
                return differenceInYears - 1;
            if(birthDate.Month == targetDate.Month && birthDate.Day > targetDate.Day)
                return differenceInYears - 1;
            return differenceInYears;
        }
    }
}
