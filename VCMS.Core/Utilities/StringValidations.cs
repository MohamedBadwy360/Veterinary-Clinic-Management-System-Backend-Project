namespace VCMS.Core.Utilities
{
    public static class StringValidations
    {
        /// <summary>
        /// Check if string consists only from letters or not.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>A boolean indicating whether the word consists only of letters or not.</returns>
        public static bool IsAllLetters(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return str.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        /// <summary>
        /// Check if string consists only from numbers or not.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>A boolean indicating whether the word consists only of numbers or not.</returns>
        public static bool IsPhoneNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            
            return (str.All(c => char.IsNumber(c) || char.IsSymbol(c))) && (str.Length <= 15 && str.Length >= 11);
        }
    }
}
