using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public class AuthorService : BaseHttpService, IAuthorService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public AuthorService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateAuthor(AuthorCreateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsPOSTAsync(author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }
            return response;
        }

        public async Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int Id)
        {
            Response<AuthorUpdateDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(Id);
                response = new Response<AuthorUpdateDto>
                {
                    Data = mapper.Map<AuthorUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorUpdateDto>(ex);
            }
            return response;
        }

        public async Task<Response<AuthorDetailsDto>> GetAuthor(int Id)
        {
            Response<AuthorDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsGETAsync(Id);
                response = new Response<AuthorDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<AuthorDetailsDto>(ex);
            }
            return response;
        }

        public async Task<Response<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            Response<List<AuthorReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.AuthorsAllAsync();
                response = new Response<List<AuthorReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<List<AuthorReadOnlyDto>>(ex);
            }
            return response;
        }

        public async Task<Response<int>> UpdateAuthor(int Id, AuthorUpdateDto author)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsPUTAsync(Id, author);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }
            return response;
        }

        public async Task<Response<int>> Delete(int Id)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.AuthorsDELETEAsync(Id);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }
            return response;
        }
    }
}
