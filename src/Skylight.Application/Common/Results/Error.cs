namespace Skylight.Application.Common.Results;

public class Error
{
	public string Message { get; set; }

	public Error(string message) =>
		Message = message;

	public Error(Exception exception) =>
		Message = $"{exception.Message} => {exception.StackTrace}";

	public override string ToString() =>
		Message;
}
