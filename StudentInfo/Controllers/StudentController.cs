using Microsoft.AspNetCore.Mvc;
using StudentInfo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.Controllers
{
    
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DbHelper _db;

        public  StudentController(StudentDbContext studentDb)
        {
            _db=new DbHelper(studentDb);
        }
        // GET: api/<StudentController>
        [HttpGet]
        [Route("api/[controller]/GetStudents")]
        public IActionResult GetStudentsInfo()
        {
            ResponseType type=new ResponseType();
            type = ResponseType.Success;
            try
            {
                IEnumerable<Student>data=_db.GetStudents();
                if(data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type,data + " Record retrieved Successfully !!!"));
            }
            catch(Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<StudentController>/5
        [HttpGet]
        [Route("api/[controller]/GetStudentById/{StudentId}")]
        public  IActionResult Get(int StudentId)
        {
            ResponseType type = new ResponseType();
            type = ResponseType.Success;
            try
            {
                Student data = _db.GetStudentById(StudentId);
                if (data==null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data + " Record Retrieved Successfully !!!"));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
        
        // POST api/<StudentController>
        [HttpPost]
        [Route("api/[controller]/SaveStudent")]
        public IActionResult Post([FromBody] Student student)
        {
            try
            { 
                
                if (student.StudentId!=0)
                {
                    _db.SaveStudent(student);
                    ResponseType type = ResponseType.Success;
                    return Ok(ResponseHandler.GetApiResponse(type, student + " Record Saved Successfully !!!"));
                }
                else
                {
                    ResponseType type = ResponseType.Failure;
                    return Ok(ResponseHandler.GetApiResponse(type, " Record Not Saved Successfully !!!"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateStudent")]
        public IActionResult Put([FromBody] Student student)
        {
            try
            {
                
                
                if(student!=null) {
                    _db.SaveStudent(student);
                    ResponseType type = ResponseType.Success;
                    return Ok(ResponseHandler.GetApiResponse(type, student + " Record Updated Successfully !!!"));
                }
                else
                {
                    ResponseType type = ResponseType.Failure;
                    return Ok(ResponseHandler.GetApiResponse(type, " Record Not Updated Successfully !!!"));
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
            // DELETE api/<StudentController>/5
            [HttpDelete]
            [Route("api/[controller]/DeleteStudent/{StudentId}")]
        public IActionResult Delete(int StudentId)
        {
            try
            { 
            ResponseType type=_db.DeleteStudent(StudentId);
                if(type== ResponseType.Success)
                { return Ok(ResponseHandler.GetApiResponse(type, "Record Deleted Successfully !!!")); }
                return Ok(ResponseHandler.GetApiResponse(type, "Record Not Found !!!"));

            }
            catch (Exception ex) {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
