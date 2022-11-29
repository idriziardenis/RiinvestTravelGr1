using RiinvestTravel.App.Enumerations;
using RiinvestTravel.App.Interfaces;

namespace Presantation.FileHelper
{
    public class FileHelper : IFileHelper
    {
        private IWebHostEnvironment _env;
        private IThumbnailService _thumbnailService;

        public FileHelper(IWebHostEnvironment env, IThumbnailService thumbnailService)
        {
            _env = env;
            _thumbnailService = thumbnailService;
        }

        public string GetProperFilePath(FileTypesEnum type, ThumbnailsEnum thumbnail, string path)
        {
            var properPath = "";
            try
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                var fileExtension = Path.GetExtension(path);

                var pathWithoutFileName = Path.GetDirectoryName(path);
                var test = Path.GetFullPath(path);

                var newFileName = $"{fileNameWithoutExtension}_{(int)thumbnail}{fileExtension}";


                var pathArray = path.Split('/');

                pathArray[pathArray.Length - 1] = newFileName;

                properPath = string.Join('/', pathArray);

                var absolutePath = pathWithoutFileName.Substring(1) + "\\" + newFileName;
                absolutePath = _env.WebRootPath + absolutePath;
                if (!File.Exists(absolutePath))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                properPath = $"~/images/default-images/product-default_{(int)thumbnail}.jpg";
            }


            return properPath;

        }
        public string GetProperFilePath(FileTypesEnum type, ThumbnailsEnum thumbnail, string path, bool forLogo)
        {
            var properPath = "";
            try
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                var fileExtension = Path.GetExtension(path);

                var pathWithoutFileName = Path.GetDirectoryName(path);
                var test = Path.GetFullPath(path);

                var newFileName = $"{fileNameWithoutExtension}_{(int)thumbnail}{fileExtension}";


                var pathArray = path.Split('/');

                pathArray[pathArray.Length - 1] = newFileName;

                properPath = string.Join('/', pathArray);

                var absolutePath = pathWithoutFileName.Substring(1) + "\\" + newFileName;
                absolutePath = _env.WebRootPath + absolutePath;
                if (!File.Exists(absolutePath))
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                properPath = null;
            }


            return properPath;

        }
        public string GetFavIconFilePath(string path)
        {
            string properPath;
            try
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                var fileExtension = Path.GetExtension(path);

                var pathWithoutFileName = Path.GetDirectoryName(path);
                var test = Path.GetFullPath(path);
                var newFileName = Path.GetFileName(path);

                //var newFileName = $"{fileNameWithoutExtension}_{(int)thumbnail}{fileExtension}";


                var pathArray = path.Split('/');

                pathArray[pathArray.Length - 1] = newFileName;

                properPath = string.Join('/', pathArray);

                var absolutePath = pathWithoutFileName.Substring(1) + "\\" + newFileName;
                absolutePath = _env.WebRootPath + absolutePath;
                if (!File.Exists(absolutePath))
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                properPath = null;
            }


            return properPath;

        }
        public void SaveFile(FileTypesEnum type, IFormFile file, string folderName, string id, params int[] thumbnails)
        {
            var filePath = Path.Combine(_env.WebRootPath, "uploads", folderName, id, type.ToString());
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            (new FileInfo(filePath)).Directory.Create();


            using (var fileStream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);

                fileStream.Close();
            }
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtenstion = Path.GetExtension(file.FileName);


            foreach (var item in thumbnails)
            {
                string thumbnailPath = Path.Combine(filePath, $"{fileNameWithoutExtension}_{item}{fileExtenstion}");
                _thumbnailService.GenerateThumbnail(item, Path.Combine(filePath, file.FileName), thumbnailPath);
            }
        }

        public void SaveFavIcon(FileTypesEnum type, IFormFile file, string folderName, string id)
        {
            var filePath = Path.Combine(_env.WebRootPath, "uploads", folderName, id, type.ToString());
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
           (new FileInfo(filePath)).Directory.Create();
            using (var fileStream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);

                fileStream.Close();
            }
        }
        public void SaveImage(FileTypesEnum type, IFormFile file, string folderName, string id)
        {
            var filePath = Path.Combine(_env.WebRootPath, "uploads", folderName, id, type.ToString());
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            (new FileInfo(filePath)).Directory.Create();
            using (var fileStream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
                fileStream.Close();
            }

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtenstion = Path.GetExtension(file.FileName);

        }

    }
}
