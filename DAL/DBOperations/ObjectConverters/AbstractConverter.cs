namespace DAL.DBOperations.ObjectConverters
{
    public abstract class AbstractConverter<T, R> where T : class
    {
        public abstract R TransFromDbToBusiness(T dbObj);
        public abstract T TransFromBusinessToDb(R obj, T newDbObj);
    }
}
