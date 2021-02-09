using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astreiko.Homework9.Nbrb.by.FileClient
{
    public interface IFileService
    {
        Task SaveAsync<T>(string path, T data);
    }
}
