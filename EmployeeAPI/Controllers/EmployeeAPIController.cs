using AutoMapper;
using Employee.Models;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTO;
using EmployeeAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace EmployeeAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeRepository _dbEmployee;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public EmployeeAPIController(IEmployeeRepository dbEmployee, IMapper mapper)
        {
            _dbEmployee = dbEmployee;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEmployees(int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                IEnumerable<Employees> employeeList = await _dbEmployee.GetAllAsync(pageSize: pageSize,
                        pageNumber: pageNumber);

                Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize };

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                _response.Result = _mapper.Map<List<EmployeesDTO>>(employeeList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpGet("{id:int}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var employee = await _dbEmployee.GetAsync(x => x.Id == id);
                if (employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<EmployeesDTO>(employee);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateEmployee(EmployeesCreateDTO employee)
        {
            try
            {
                if (employee == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model = _mapper.Map<Employees>(employee);
                await _dbEmployee.CreateAsync(model);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<EmployeesCreateDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetEmployee", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var employee = await _dbEmployee.GetAsync(x => x.Id == id);
                if (employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbEmployee.RemoveAsync(employee);
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> UpdateEmployee(int id, [FromBody] EmployeesUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model = _mapper.Map<Employees>(updateDTO);

                await _dbEmployee.UpdateEmployeeAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

    }
}
