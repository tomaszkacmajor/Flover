using System.IO;

namespace FloverWebApp.Models
{
    public class MainModel
    {
        public string ImagePath = "";
        public string ImageFilename => Path.GetFileName(ImagePath);
    }
}
