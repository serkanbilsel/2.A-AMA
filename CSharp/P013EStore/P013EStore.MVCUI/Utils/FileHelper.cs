namespace P013EStore.MVCUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formfile, string filePath = "/Img")
        {
            string fileName = "";
            fileName = formfile.FileName;
            string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            using var stream = new FileStream(directory, FileMode.Create);
            await formfile.CopyToAsync(stream);
            return fileName;
        }
    }
}
