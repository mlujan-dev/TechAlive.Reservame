using System;

namespace TechAlive.Reservame.Core.Dto
{
	public sealed class ApiResponse
	{
		public int StatusCode { get; }
		public string Message { get; }
		public TimeSpan Time { get; }
		public bool IsSuccess { get; }
		public string RequestOrigin { get; }

		private ApiResponse(bool isSuccess, int statusCode, string message, TimeSpan time, string requestOrigin)
		{
			IsSuccess = isSuccess;
			StatusCode = statusCode;
			Message = message;
			Time = time;
			RequestOrigin = requestOrigin;
		}

		public static ApiResponse Ok(TimeSpan time, string requestOrigin = null)
		{
			return new ApiResponse(true, 200, null, time, requestOrigin);
		}

		public static ApiResponse Fail(int statusCode, string message, TimeSpan time, string requestOrigin)
		{
			return new ApiResponse(false, statusCode, message, time, requestOrigin);
		}
	}
}
