namespace VCMS.Business.ExceptionHandling
{
    public static class ExceptionHandler
    {
        public static Response<T> HandleDbUpdateException<T>(DbUpdateException exception, string operation, 
            string propertyName = null)
            where T : class
        {
            if (exception.InnerException is SqlException sqlException &&
                    sqlException.Number == SqlServerErrorNumbers.ViolateUniqueConstraint)
            {
                // logging exception

                return Response<T>.Conflict($"An entity with the same {propertyName} already exists.");
            }
            else
            {
                // logging exception

                return Response<T>.InternalServerError($"A database error occurred while {operation} the entity.");
            }
        }

        public static Response<T> HandleGenericException<T>(Exception exception, string operation)
            where T : class
        {
            // logging exception

            return Response<T>.InternalServerError($"An unexpected error occurred while {operation} the entity.");
        }
    }
}
