namespace SchoolPortal.Application.Responses;

public class Success: IResponseData
{
    public object Detail { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
}
