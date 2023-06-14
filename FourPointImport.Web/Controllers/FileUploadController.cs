using Utilities;
using FourPointImport.Data;
using FourPointImport.Services;
using FourPointImport.Web.Models;
using FourPointImport.Web.Functions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class FileUploadController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        //protected readonly SUSMSTPAccess _tableAccess;
        private ProductCoverageService _productCoverageService;
        //protected readonly FrmMstPAccess _frmMstLAccess;
        //protected readonly COVMSTRAccess _covmstrAccess;
        protected readonly billingDetailService _bildtlService;
        private billingDetail _billingDetail { get; set; }
        //SUSMSTPAccess tableAccess, PRDCOVPAccess prdcovpAccess, FrmMstPAccess frmMstLAccess, COVMSTRAccess covmstrAccess,
        public FileUploadController([NotNull] IConfiguration configuration, billingDetailService bildtlService)
        {
            _configuration = configuration;
            //_tableAccess = tableAccess;
            //_prdcovpAccess = prdcovpAccess;
            //_frmMstLAccess = frmMstLAccess;
            _bildtlService = bildtlService;
            //_covmstrAccess = covmstrAccess;
        }
        [Route("newFile")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm(Name = "files")] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Please select a file");
            }
            LocalFileService fs = new LocalFileService();

            IConfiguration settings = _configuration.GetSection("settings");
            foreach (var _file in files)
            {
                try
                {
                    string fileName = "";

                    //save the file locally for posterity
                    string textString = await fs.SaveFile(_file, settings["fileDirectory"].StringSafe());
                    //get the companion tables

                    fileName = _file.FileName;

                    if (fileName != null)
                    {
                        using (StreamReader reader = new StreamReader(_file.OpenReadStream()))
                        {
                            string fileLine;

                            while ((fileLine = await reader.ReadLineAsync()) != null)
                            {

                                List<Diagram> pattern = fs.mapImportFile();

                                ConvertToEntity<billingDetail> converter = new ConvertToEntity<billingDetail>(fileLine, pattern);
                                _billingDetail = converter.Convert();
                                var _billingEntity = converter.PairFiles(_billingDetail);
                                //now we have the actual class, which we can build with the other functions  _covmstrAccess, _bildtlAccess
                                var _functions = new billingExportFunctions<billingDetail>(_bildtlService, _billingEntity, _productCoverageService);
                                if (_billingEntity.SeCert.StringSafe().Length > 0)
                                {
                                    _functions.HomeSavings();
                                    _functions.Clear();
                                    _functions.ReadAOMOB();
                                    _functions.Form();
                                    _functions.Custom90338();
                                    _functions.Life();
                                    //_functions.Disability();
                                    //_functions.DebtProt();
                                    //_functions.Write();
                                    //_functions.WriteAOMOB();
                                }
                                _functions.Update();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                }
            }
            return Ok("File uploaded successfully");
        }
    }
}
