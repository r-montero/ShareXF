using System;
using SharingIsCaring.Dependencies;

namespace SharingIsCaring.iOS.Dependencies
{
    public class FileStore : IFileStore
    {
        public string GetFilePath(string fileName)
        {
            return "Files/"+fileName;
        }
    }
}
