using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.IO;
using Xamarin.Forms;
using S13_LocalDatabase.Interfaces;
using S13_LocalDatabase.iOS.Implementations;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace S13_LocalDatabase.iOS.Implementations
{
    class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}