using System;
using System.Threading.Tasks;

namespace MyLocation.Services.Interfaces
{
    public interface IFileOperationsService
    {
        void AddTimeToCountryFile(string countryName);
    }
}
