using Application.Contracts.Menus;
using AutoMapper;
using Domain.Models.Menus;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Menus;

[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMapper _mapper;

    public MenuController(IMenuRepository menuRepository, IMapper mapper)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("api/menus")]
    public async Task<ActionResult<List<MenuDto>>> Getlist()
    {
        var data = await _menuRepository.ListAsync();
        var output = data.Where(x => x.IsDeleted == false);

        var Result = _mapper.Map<List<MenuDto>>(output);
        return Ok(Result);
    }
    [HttpGet]
    [Route("api/menus/{id}")]

    public async Task<ActionResult<MenuDto>> GetById(int id)
    {
        var data = await _menuRepository.GetByIdAsync(id);
        if (data == null || data.IsDeleted == true)
        {
            return NotFound("data not found");
        }
        var output = _mapper.Map<MenuDto>(data);
        return Ok(output);
    }
    [HttpPost]
    [Route("api/menus")]
    public async Task<ActionResult<MenuDto>> Create(CreateMenuDto command)
    {
        var data = _mapper.Map<CreateMenuDto, Menu>(command);
        var menu = await _menuRepository.AddAsync(data);
        var result = _mapper.Map<MenuDto>(menu);
        return Ok(result);
    }

    [HttpGet]
    [Route("api/menus/{parentId}")]
    public async Task<ActionResult<List<MenuDto>>> GetParentById(int parentid)
    {
        var data = await _menuRepository.GetbyParentId(parentid);
        if (data == null)
        {
            return NotFound("data not found");
        }
        var output = _mapper.Map<List<MenuDto>>(data);
        return Ok(output);
    }

    [HttpGet]
    [Route("api/menus/typeId")]
    public async Task<ActionResult<List<MenuDto>>> Get(int typeId)
    {
        var data = await _menuRepository.GetbyTypeId(typeId);
        if (data == null)
        {
            return NotFound();
        }
        var output = _mapper.Map<List<MenuDto>>(data);
        return Ok(output);
    }

    [HttpPut]
    [Route("api/menus/{id}")]
    public async Task<ActionResult<MenuDto>> Update(UpdateMenuDto input, int id)
    {
        Menu menu = await _menuRepository.GetByIdAsync(id);
        if (menu == null)
        {
            return BadRequest("data not found");
        }
        menu.Name = input.Name;
        menu.NavigateUrl = input.NavigateUrl;
        menu.Icon = input.Icon;
        menu.ParentId = input.ParentId;
        menu.TypeId = input.TypeId;
        menu.IsNew = input.IsNew;
        menu.IsActive = input.IsActive;
        menu.UpdatedDate = DateTime.Now;
        await _menuRepository.UpdateAsync(menu);
        await _menuRepository.SaveChangesAsync();

        var output = await _menuRepository.GetByIdAsync(menu.Id);
        return _mapper.Map<MenuDto>(output);
    }

    [HttpDelete]
    [Route("api/menus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var menu = await _menuRepository.GetByIdAsync(id);
        if (menu == null || menu.IsDeleted == true)
        {
            return BadRequest("Data not Found");
        }
        else
        {
            menu.IsDeleted = true;
            await _menuRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}











