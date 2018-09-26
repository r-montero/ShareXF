using System;
using System.IO;
using SharingIsCaring.Dependencies;
using SharingIsCaring.Droid.Dependencies;
using Xamarin.Forms;

namespace SharingIsCaring.Droid.Dependencies
{
    public class FileStore : IFileStore
    {
        public string GetFilePath(string fileName)
        {
            return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, fileName);
        }
    }
}
