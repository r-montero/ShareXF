using System;
using System.Threading.Tasks;

namespace SharingIsCaring.Dependencies
{
    public interface IShare
    {
        Task Show(string title, string message, string filePath);
    }
}
