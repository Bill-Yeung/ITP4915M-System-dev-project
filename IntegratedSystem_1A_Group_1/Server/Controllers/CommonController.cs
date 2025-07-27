using DatabaseAccessController;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Upload")]
        [Consumes("multipart/form-data")]
        public async Task<string> UploadFile([FromForm] string nextFileID, IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return "false";
            }

            string uploadsFolder = Path.Combine(_configuration["WebRootPath"], "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filePath = Path.Combine(uploadsFolder, $"{nextFileID}_{file.FileName}");

            try
            {

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return "true";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        [HttpPost("Download/{fileName}")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public IActionResult DownloadFile(string fileName)
        {

            string filePath = Path.Combine(_configuration["WebRootPath"], "uploads", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            string mimeType = null;

            switch (extension)
            {
                case ".doc":
                    mimeType = "application/msword";
                    break;
                case ".docx":
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".xls":
                    mimeType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".ppt":
                    mimeType = "application/vnd.ms-powerpoint";
                    break;
                case ".pptx":
                    mimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    break;
                case ".pdf":
                    mimeType = "application/pdf";
                    break;
                default:
                    mimeType = "application/octet-stream";
                    break;
            }

            var stream = System.IO.File.OpenRead(filePath);

            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = fileName
            };

        }

        [HttpGet("GetLastId")]
        public string? GetLastId(string tableName, string primaryKey)
        {
            try
            {

                dboDatabaseController dboController = new dboDatabaseController(_configuration["ConnectionStrings"]);
                return dboController.GetLastId(tableName, primaryKey);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetData/{tableName}/{allMode}")]
        public string? GetData(string tableName, string allMode, [FromBody] Dictionary<string, object>? searchDict)
        {
            try
            {

                DataTable dtResult;
                dboDatabaseController dboController = new dboDatabaseController(_configuration["ConnectionStrings"]);

                if (allMode == "false")
                {
                    dtResult = dboController.GetData(tableName, false, searchDict);
                }
                else
                {
                    dtResult = dboController.GetData(tableName, true, searchDict);
                }

                return JsonConvert.SerializeObject(dtResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertData/{tableName}")]
        public int? InsertData(string tableName, [FromBody] List<Dictionary<string, object>> dataList)
        {
            try
            {
                dboDatabaseController dboController = new dboDatabaseController(_configuration["ConnectionStrings"]);
                return dboController.InsertData(tableName, dataList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("UpdateData/{tableName}")]
        public int? UpdateData(string tableName, [FromBody] UpdateDataRequest request)
        {
            try
            {
                dboDatabaseController dboController = new dboDatabaseController(_configuration["ConnectionStrings"]);
                return dboController.UpdateData(tableName, request.KeyList, request.DataList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
