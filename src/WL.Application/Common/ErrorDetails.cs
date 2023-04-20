using WL.Application.Common.Extensions;

namespace WL.Application.Common;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public override string ToString() => this.ToJson();
}