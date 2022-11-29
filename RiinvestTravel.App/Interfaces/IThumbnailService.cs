using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Interfaces
{
    public interface IThumbnailService
    {
        void GenerateThumbnail(int size, string inputPath, string outputPath);
    }
}
