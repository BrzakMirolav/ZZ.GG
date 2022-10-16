namespace BusinessModel.GlobalModels
{
    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiResponse()
        {
            Data = default;
        }
    }
}
