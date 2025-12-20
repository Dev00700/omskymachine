using MachineWeb.Models;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace MachineWeb.BAL
{
    public class FileUploadService
    {
        public async Task<List<string>> SaveImageInFolder(List<IFormFile> images)
        {
            var imageNames = new List<string>();
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "webimages");
            Directory.CreateDirectory(imageFolder);

            CommonResponseDto<List<string>> commonResponseDto = new CommonResponseDto<List<string>>();

            foreach (var imageFile in images)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var imageName = $"{Guid.NewGuid()}{extension}";
                    var imagePath = Path.Combine(imageFolder, imageName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    imageNames.Add(imageName);
                }
            }
            return imageNames;
        }

        public DataTable ConvertImageListToDataTable(List<string> imageNames)
        {
           
                DataTable dt = new DataTable();
                dt.Columns.Add("ImageName", typeof(string));

                foreach (var img in imageNames)
                {
                    dt.Rows.Add(img);
                }

                return dt;
        }

    }
}
