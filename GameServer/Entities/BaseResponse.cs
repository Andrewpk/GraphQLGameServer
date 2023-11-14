namespace GameServer.Entities;

public abstract class BaseResponse<T>
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public T? ResponseData { get; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? ErrorMessage { get; set; }

    protected BaseResponse(T? responseData = default, string? errorMessage = null)
    {
        if (responseData == null && errorMessage == null)
        {
            throw new ArgumentNullException(nameof(responseData) + "or " + nameof(errorMessage) + "must be specified");
        }

        ResponseData = responseData;
        ErrorMessage = errorMessage;
    }
}
