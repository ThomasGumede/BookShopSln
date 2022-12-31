using AutoMapper;
using Data.Interfaces;
using Data.DTOs;
using Service.Interfaces;

namespace Service;

public class GenreService : IGenreService
{

    private IRepositoryManager _context;
    private IMapper _mapper;

    public GenreService(IRepositoryManager ctx, IMapper mapper)
    {
        _context = ctx;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreDto>> AllGenresAsync(bool trackChanges)
    {
        var genres = await _context.genreRepository.GetAllGenresAsync(trackChanges);

        var GenreDto = _mapper.Map<IEnumerable<GenreDto>>(genres);

        return GenreDto;
    }
}