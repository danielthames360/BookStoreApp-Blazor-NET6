using BookStoreApp.Blazor.Server.UI.Services.Base;

namespace BookStoreApp.Blazor.Server.UI.Services
{
    public interface IBookService
    {
        Task<Response<List<BookReadOnlyDto>>> GetBooks();
        Task<Response<BookDetailsDto>> GetBook(int Id);
        Task<Response<BookUpdateDto>> GetBookForUpdate(int Id);
        Task<Response<int>> CreateBook(BookCreateDto book);
        Task<Response<int>> UpdateBook(int Id, BookUpdateDto book);

        Task<Response<int>> Delete(int Id);
    }
}