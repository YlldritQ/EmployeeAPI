namespace EmployeeApi.Core.Dtos
{
    public class GeneralServiceResponseDto
    {
        public bool IsSucceed { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class GeneralServiceResponseDto<T> : GeneralServiceResponseDto
    {
        public T? Data { get; set; }
    }
}
