using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyFirst.Utilities
{
   public class ConfigHelper
    {
        /// <summary>
        /// 读取appStrings配置节， 返回＊.exe.config文件中appSettings配置节的value项
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetAppSetting(string keyName)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key==keyName)
                {
                    return ConfigurationManager.AppSettings[keyName];
                }
            }
            return null;
        }
    }
}
