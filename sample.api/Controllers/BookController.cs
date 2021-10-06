using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OB_Net_Core_Tutorial.DTO;
using OB_Net_Core_Tutorial.Model;

namespace OB_Net_Core_Tutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, UnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all book
        /// </summary>
        /// <response code="200">Request ok.</response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<BookDTO>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> GetAllAsync()
        {
            var result = await _unitOfWork.BookRepository.GetAll().ProjectTo<BookDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get book by title
        /// </summary>
        /// <param name="isbn">user Model.</param>
        /// <response code="200">Request ok.</response>
        /// <response code="405">Request not found.</response>
        [HttpGet]
        [Route("{isbn}")]
        [ProducesResponseType(typeof(BookDTO), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> GetByTitleAsync([FromRoute]string isbn)
        {
            var book = await _unitOfWork.BookRepository.GetAll().Where(b => b.ISBN == isbn).FirstOrDefaultAsync();
            if (book != null)
            {
                var bookDto = _mapper.Map<BookDTO>(book);
                return new OkObjectResult(bookDto);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Create book 
        /// </summary>
        /// <param name="bookDto">book data.</param>
        /// <response code="200">Request ok.</response>
        /// <response code="400">Request failed because of an exception.</response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> CreateAsync([FromBody]BookDTO bookDto)
        {
            var isExist = _unitOfWork.BookRepository.GetAll().Where(x => x.ISBN == bookDto.ISBN).Any();
            if (!isExist)
            {
                var book = _mapper.Map<Book>(bookDto);
                await _unitOfWork.BookRepository.AddAsync(book);
                await _unitOfWork.SaveAsync();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        /// <summary>
        /// Create book 
        /// </summary>
        /// <param name="isbn">book data.</param>
        /// <response code="200">Request ok.</response>
        [HttpDelete]
        [Route("{isbn}")]
        [ProducesResponseType(typeof(BookDTO), 200)]
        public ActionResult Delete([FromRoute]string isbn)
        {
            _unitOfWork.BookRepository.Delete(x => x.ISBN == isbn);
            return new OkResult();
        }
    }
}
