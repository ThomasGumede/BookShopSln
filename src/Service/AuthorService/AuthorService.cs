using Core.Exceptions;
using Data.Interfaces;
using Data.DTOs;
using Core;
using AutoMapper;
using Service.Interfaces;

namespace Service;

public class AuthorService : IAuthorService
{
    private IRepositoryManager _context;
    // private readonly ILoggerManager _logger;
    private IMapper _mapper;

    public AuthorService(IRepositoryManager ctx,  IMapper mapper)
    {
        _context = ctx;
        // _logger = logger;
        _mapper = mapper;

    }

    public async Task<IEnumerable<AuthorDto>> AllAuthorsAsync(bool trackChanges)
    {
        var authors = await _context.authorRepository.GetAllAuthorsAsync(trackChanges);

        var AuthorDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

        return AuthorDto;
    }
}