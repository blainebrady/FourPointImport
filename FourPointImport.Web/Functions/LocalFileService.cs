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
                    fieldName = "BXAGNT",
                    start = 0,
                    length = 10
                },
                new Diagram
                {
                    fieldName = "BXBRCH",
                    start = 10,
                    length = 10
                },
                new Diagram
                {
                    fieldName = "BXCERT",
                    start = 20,
                    length = 20
                },
                new Diagram
                {
                    fieldName = "BXNAME",
                    start = 40,
                    length = 25
                },
                new Diagram
                {
                    fieldName = "BXCOVC",                                                  //SeDebtCode
                    start = 65,
                    length = 30
                },
                new Diagram
                {
                    fieldName = "BXEFFT",
                    start = 95,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXFROM",                                           //from date
                    start = 103,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXTHRU",                                              //thru date
                    start = 111,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXEXPR",                                       //expiration Date
                    start = 119,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXPAID",                                       //date payment made
                    start = 127,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXNEXT",                                       //next payment due
                    start = 135,
                    length = 8
                },
                new Diagram
                {
                    fieldName = "BXBAMT",
                    start = 143,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXCOMM",                                       //Commission amount billed
                    start = 154,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXBGRS",                                       //gross billeded amount
                    start = 165,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXPAMT",                                       //BXAMT
                    start = 176,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXCOMP",
                    start = 187,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXGRS",                                    //gross collected amount
                    start = 198,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXMOB",                                    //current MOB
                    start = 209,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXINTR",
                    start = 220,
                    length = 7
                },
                new Diagram
                {
                    fieldName = "BXINT",                                    //Current Interest
                    start = 227,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXPRIN",                                       //Current Principal
                    start = 238,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXSCHD",
                    start = 249,
                    length = 11
                },
                new Diagram
                {
                    fieldName = "BXMSGC",                                   //message code
                    start = 260,
                    length = 2
                },
                new Diagram
                {
                    fieldName = "BXMSGD",                                   //Message Desc
                    start = 262,
                    length = 25
                },
                new Diagram
                {
                    fieldName = "BXCODE",
                    start= 287,
                    length = 2,
                },
                new Diagram
                {
                    fieldName = "BXDESC",
                    start = 289,
                    length = 25
                },
                new Diagram
                {
                    fieldName = "BXCAND",
                    start = 314,
                    length = 8
                }
            };
            return diagram;
        } 
    }
}
