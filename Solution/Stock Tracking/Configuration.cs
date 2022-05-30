using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace StockTracking
{
    public static class Configuration
    {

        public static ConfigObject Initialize() {

            ConfigObject ret;
            if (File.Exists("settings.json")) {

                try
                {

                    ret = JsonConvert.DeserializeObject<ConfigObject>(File.ReadAllText("settings.json"));

                }
                catch (Exception e)
                {

                    MessageBox.Show("Kaydedilen ayarlar okunurken bir hata oluştu. Ayarlar sıfırlanıyor. \n\n" + e.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete("settings.json");
                    ret = Initialize();

                }

                return ret;

            }

            ret = new ConfigObject(); 
            SaveConfiguration(ret);
            
            return ret;

        }

        public static void SaveConfiguration(ConfigObject config)
        {
            
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText("settings.json", json);

        }

    }
}
