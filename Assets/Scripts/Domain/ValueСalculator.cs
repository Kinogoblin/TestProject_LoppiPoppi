using System;

namespace LoppiPoppi.Domain
{
    public class ValueСalculator
    {
        private string errorMessage = "Error";

        public string CalculateResult(string equation)
        {
            if (equation.Contains('-')) return errorMessage;

            var textVaraibles = GetVariables(equation, '+');
            int[] varaibles = new int[textVaraibles.Length];
            for (var index = 0; index < textVaraibles.Length; index++)
            {
                try
                {
                    varaibles[index] = int.Parse(textVaraibles[index]);
                }
                catch (Exception e)
                {
                    return errorMessage;
                }
            }

            int result = 0;
            foreach (var varaible in varaibles)
            {
                result += varaible;
            }

            return result.ToString();
        }


        public static string[] GetVariables(string equation, char symbol)
        {
            string[] newname = null;
            if (equation.Contains(symbol.ToString()))
                newname = equation.Split(new char[] { symbol });
            return newname;
        }

    }
}
