namespace VCMS.Business.Helpers
{
    public static class CheckingDbConstraints<T> where T : class
    {
        public static Response<T> CheckViolateUniqueConstraint(DbUpdateException exception)
        {
            if (exception.InnerException is SqlException sqlException &&
                    sqlException.Number == SqlServerErrorNumbers.ViolateUniqueConstaint)
            {
                return Response<T>.Failure(EResponseStatusCode.Conflict,
                    "A species with the same name already exists.");
            }
            else
            {
                //logging

                return Response<T>.Failure(EResponseStatusCode.InternalServerError,
                    "An unexpected error occurred while updating the species.");
            }
        }
    }
}
