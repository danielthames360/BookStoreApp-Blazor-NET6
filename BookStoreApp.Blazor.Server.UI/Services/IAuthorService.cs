using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthors();
        Task<Response<AuthorDetailsDto>> GetAuthor(int Id);
        Task<Response<AuthorUpdateDto>> GetAuthorForUpdate(int Id);
        Task<Response<int>> CreateAuthor(AuthorCreateDto author);
        Task<Response<int>> UpdateAuthor(int Id, AuthorUpdateDto author);

        Task<Response<int>> Delete(int Id);
    }
}