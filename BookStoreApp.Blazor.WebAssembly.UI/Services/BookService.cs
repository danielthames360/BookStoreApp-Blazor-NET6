﻿using AutoMapper;
using Blazored.LocalStorage;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services
{
    public class BookService : BaseHttpService, IBookService
    {
        private readonly IClient client;
        private readonly IMapper mapper;

        public BookService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<Response<int>> CreateBook(BookCreateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPOSTAsync(book);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }
            return response;
        }

        public async Task<Response<BookUpdateDto>> GetBookForUpdate(int Id)
        {
            Response<BookUpdateDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(Id);
                response = new Response<BookUpdateDto>
                {
                    Data = mapper.Map<BookUpdateDto>(data),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<BookUpdateDto>(ex);
            }
            return response;
        }

        public async Task<Response<BookDetailsDto>> GetBook(int Id)
        {
            Response<BookDetailsDto> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksGETAsync(Id);
                response = new Response<BookDetailsDto>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<BookDetailsDto>(ex);
            }
            return response;
        }

        public async Task<Response<List<BookReadOnlyDto>>> GetBooks()
        {
            Response<List<BookReadOnlyDto>> response;

            try
            {
                await GetBearerToken();
                var data = await client.BooksAllAsync();
                response = new Response<List<BookReadOnlyDto>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<List<BookReadOnlyDto>>(ex);
            }
            return response;
        }

        public async Task<Response<int>> UpdateBook(int Id, BookUpdateDto book)
        {
            Response<int> response = new();
            try
            {
                await GetBearerToken();
                await client.BooksPUTAsync(Id, book);
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
                await client.BooksDELETEAsync(Id);
            }
            catch (ApiException ex)
            {
                response = ConvertApiExceptions<int>(ex);
            }
            return response;
        }
    }
}
