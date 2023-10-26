using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowroomService.Helper
{
    public class FileSystemHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigReader"/> class.
        /// </summary>
        /// 

        public static string baseURL = ConfigurationManager.AppSettings["BaseURL"];
        private static string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string TestDataBaseFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName + @"\ExpectedResponse\";

    }
}
