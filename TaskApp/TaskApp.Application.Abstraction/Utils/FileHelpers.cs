using System.IO;

namespace TaskApp.Application
{
    public static class FileHelpers
    {
        public static void DeleteFileFromContent(string path) {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
