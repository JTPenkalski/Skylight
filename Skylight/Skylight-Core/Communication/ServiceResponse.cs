namespace Skylight.Communication
{
    /// <summary>
    /// Represents a response from an infrastructure layer service.
    /// Used for determining the proper HTTP response in the API controller.
    /// </summary>
    /// <typeparam name="T">The model type in a request.</typeparam>
    public class ServiceResponse<T>
    {
        public bool Success { get; init; }
        public T? Content { get; init; }

        /// <summary>
        /// Constructs a new <see cref="ServiceResponse{T}"/> instance.
        /// </summary>
        /// <param name="success">If the request successfully completed its intended operation.</param>
        /// <param name="content">The model used to complete the request.</param>
        public ServiceResponse(bool success, T? content = default)
        {
            Success = success;
            Content = content;
        }
    }
}