namespace SchoolPortal.Application.Responses;

public class Error: IResponseData
{
    public object Detail { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
}
