using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Xamarin.Forms;
using S13_LocalDatabase.Droid.Implementations;
using S13_LocalDatabase.Interfaces;

[assembly: Dependency(typeof(ConfigDataBase))]

namespace S13_LocalDatabase.Droid.Implementations
{
    class ConfigDataBase: IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }

    }
}