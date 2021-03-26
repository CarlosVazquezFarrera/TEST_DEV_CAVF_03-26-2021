namespace ApiToka.Core.CustomEntities
{
    public class Response<T>: ResponseBase
    {
        public T Data { get; set; }
    }
}
