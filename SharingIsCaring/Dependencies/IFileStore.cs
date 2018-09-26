using System;
namespace SharingIsCaring.Dependencies
{
    public interface IFileStore
    {
        string GetFilePath(string fileName);
    }
}
