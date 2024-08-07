using Expect.Timeslots.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Users.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, OperationResult>
    {
        private readonly HttpClient _client;

        public LoginRequestHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<OperationResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var formData = new List<KeyValuePair<string, string>>
            {
                new("client_id", request.Login.Username),
                new("client_secret", request.Login.Password),
                new("grant_type", "client_credentials")
            };

            var content = new FormUrlEncodedContent(formData);

            var response = await _client.PostAsync("http://timelots-auth:8080/connect/token", content);

            if (!response.IsSuccessStatusCode)
                return new OperationResult(StatusCodes.Status400BadRequest, null);

            var resultString = await response.Content.ReadAsStringAsync(cancellationToken);
            var data = JsonConvert.DeserializeObject<AuthToken>(resultString);

            return new OperationResult(StatusCodes.Status200OK, data);
        }
    }
}
