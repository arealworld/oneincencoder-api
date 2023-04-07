namespace OneInc.Encoder.API.DTOs
{
    public class OperationResultDTO<T>
    {
        public bool Err { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = default;
    }
}
