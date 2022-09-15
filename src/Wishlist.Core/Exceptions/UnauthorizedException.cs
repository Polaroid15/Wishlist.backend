namespace Wishlist.Core.Exceptions; 

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string? message)
        : base(message)
    {
    }

    public UnauthorizedException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}