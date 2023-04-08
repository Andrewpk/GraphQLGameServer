namespace GameServer.Entities;

public abstract class BaseResponse<T>
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public T? ResponseData { get; }
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? ErrorMessage { get; set; }

    // ReSharper disable once PublicConstructorInAbstractClass
    public BaseResponse(T? responseData = default, string? errorMessage = null)
    {
        if (responseData == null && errorMessage == null)
        {
            throw new ArgumentNullException(nameof(responseData) +  "or " + nameof(errorMessage) + " must be specified");
        }

        ResponseData = responseData;
        ErrorMessage = errorMessage;
    }
}
