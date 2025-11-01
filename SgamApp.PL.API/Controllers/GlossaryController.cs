using Microsoft.AspNetCore.Mvc;
using SgamApp.BLL.Interfaces;
using SgamApp.BLL.Models;

namespace BookManager.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlossaryController : ControllerBase
    {
        private readonly IGlossaryService _glossaryService;

        public GlossaryController(IGlossaryService glossaryService)
        {
            _glossaryService = glossaryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var glossaries = _glossaryService.GetAll();
                if (glossaries == null || !glossaries.Any())
                {
                    return NotFound("No glossaries found.");
                }
                else
                {
                    return Ok(glossaries);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var glossary = _glossaryService.GetById(id);
                if (glossary == null)
                {
                    return NotFound("Glossary not found.");
                }
                else
                {
                    return Ok(glossary);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByWord/{word}")]
        public IActionResult GetByWord(string word)
        {
            try
            {
                var glossary = _glossaryService.GetByWord(word);
                if (glossary == null)
                {
                    return NotFound("Glossary not found.");
                }
                else
                {
                    return Ok(glossary);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] GlossaryModel glossary)
        {
            try
            {
                if (glossary == null)
                {
                    return BadRequest("Glossary data is null.");
                }
                _glossaryService.Add(glossary);
                return Ok("Glossary added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(GlossaryModel glossary)
        {
            try
            {
                if (glossary == null)
                {
                    return BadRequest("Glossary data is invalid.");
                }
                _glossaryService.Update(glossary);
                return Ok("Glossary updated successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var glossary = _glossaryService.GetById(id);
                if (glossary == null)
                {
                    return NotFound("Glossary not found.");
                }
                _glossaryService.Delete(id);
                return Ok("Glossary deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}