namespace VCMS.Core.Constants
{
    /// <summary>
    /// Class contains SQL Server error numbers.
    /// </summary>
    public static class SqlServerErrorNumbers
    {
        /// <summary>
        /// Violation of UNIQUE KEY constraint error number.
        /// </summary>
        public const int ViolateUniqueConstraint = 2601;

        /// <summary>
        /// Violation of FOREIGN KEY constraint error number.
        /// </summary>
        public const int ViolateForeignKeyConstraint = 547;
    }
}
