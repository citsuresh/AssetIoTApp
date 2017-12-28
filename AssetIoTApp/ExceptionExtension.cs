using System;

/// <summary>
/// Summary description for ExceptionHelper
/// </summary>
public static class ExceptionExtension
{
	/// <summary>
	/// Gets the exception display message.
	/// </summary>
	/// <param name="ex">The ex.</param>
	/// <returns></returns>
	public static string GetDisplayMessage(this Exception ex)
	{
		string message = string.Empty;
		var exception = ex;
		do
		{
			message += exception.Message;
			exception = exception.InnerException;
		} while (exception != null);

		return message;
	}
}