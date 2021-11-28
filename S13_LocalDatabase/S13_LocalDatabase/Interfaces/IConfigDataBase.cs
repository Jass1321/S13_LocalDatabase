using System;
using System.Collections.Generic;
using System.Text;

namespace S13_LocalDatabase.Interfaces
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }
}
