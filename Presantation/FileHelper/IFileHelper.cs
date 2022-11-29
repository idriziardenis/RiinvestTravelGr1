using RiinvestTravel.App.Enumerations;

namespace Presantation.FileHelper
{
    public interface IFileHelper
    {
        void SaveFile(FileTypesEnum type, IFormFile file, string folderName, string id, params int[] thumbnails);
        void SaveFavIcon(FileTypesEnum type, IFormFile file, string folderName, string id);
        string GetProperFilePath(FileTypesEnum type, ThumbnailsEnum thumbnail, string path);
        string GetProperFilePath(FileTypesEnum type, ThumbnailsEnum thumbnail, string path, bool forLogo);
        string GetFavIconFilePath(string path);
        void SaveImage(FileTypesEnum type, IFormFile file, string folderName, string id);
    }
}
