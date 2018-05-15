using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using WaterForLife;

[assembly: Dependency(typeof(FileHelpers))]
namespace WaterForLife
{
    class FileHelpers : IFileHelpers
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
            //return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
