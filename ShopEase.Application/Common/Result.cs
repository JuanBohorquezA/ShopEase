namespace ShopEase.Application.Common;



public class Result
{
    public bool Success { get; private set; }
    public string ErrorMessage { get; private set; } = string.Empty;

    protected Result(bool success, string errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public static Result SuccessResult()
    {
        return new Result(true, string.Empty);
    }

    public static Result FailureResult(string errorMessage)
    {
        return new Result(false, errorMessage);
    }
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    private Result(bool success, T? data, string errorMessage) : base(success, errorMessage)
    {
        Data = data;
    }

    public static Result<T> SuccessResult(T data)
    {
        return new Result<T>(true, data, string.Empty);
    }

    public static Result<T?> FailureResult(T data, string errorMessage)
    {
        return new Result<T?>(false, data, errorMessage);
    }
}
