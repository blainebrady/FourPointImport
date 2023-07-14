using FourPointImport.Web.Models;
using Utilities;

namespace FourPointImport.Web.Functions
{
    public class LocalFileService
    {
        public LocalFileService() { }
        public string getFile(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            var fileContent = reader.ReadToEnd();
            reader.Close();

            return fileContent;
        }

        public List<string> ProcessFiles(List<IFormFile> files, out string fileName)
        {
            //this function turns a text file into a string list, and determines the name of the file
            List<string> _res = new List<string>();
            string _fileName = "";
            files.ForEach(async file =>
            {
                //qualify the name of the file
                if (file.FileName.StringSafe().IndexOf("_") > 1)
                {
                    string[] fBreak = file.FileName.Split('_');

                    if (file.Length <= 1 || fBreak[1].StringSafe().Length > 0 || Utils.IsDate(fBreak[1].StringSafe()))
                        return;
                    try
                    {
                        DateTime dDate = Utils.ParseDateControlledReturn(fBreak[1].StringSafe());
                        _fileName = fBreak[0].StringSafe();
                        using (var reader = new StreamReader(file.OpenReadStream()))

                            while (!reader.EndOfStream)
                                //
                                _res.Add(await reader.ReadLineAsync());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
            fileName = _fileName;
            return _res;
        }

        public async Task<string> SaveFile(IFormFile file, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            var target = Path.Combine("C:\\production\\", subDirectory);

            Directory.CreateDirectory(target);
            string _out = "";

            if (file.Length <= 0) return "No files found";
            var filePath = Path.Combine(target, file.FileName);
            target += @"\" + file.FileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                _out += stream.ToString();
            }

            return _out;
        }
        public List<Diagram> mapImportFile()
        {
            List<Diagram> diagram = new List<Diagram>
            {
                new Diagram
                {
                    fieldName = "CFAGNT",
                    start = 0,
                    length = 10
                },
                new Diagram
                {
                    fieldName = "CFCERT",
                    start = 10,
                    length = 20
                },
                new Diagram
                {
                    fieldName = "CFFLAG",
                    start = 30,
                    length = 1
                },
                new Diagram
                {
                    fieldName = "CFERR",                                                
                    start = 31,
                    length = 10
                },
                new Diagram
                {
                    fieldName = "CFTIMEDATE",
                    start = 41,
                    length = 14
                }
            };
            return diagram;
        } 
    }
}
