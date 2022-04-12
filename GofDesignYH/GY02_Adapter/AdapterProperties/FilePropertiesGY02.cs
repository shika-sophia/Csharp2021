using CsharpBegin.Utility;
using CsharpBegin.Utility.JavaPropertiesDiv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.GofDesignYH.GY02_Adapter.AdapterProperties
{
    class FilePropertiesGY02 : AbsPropertyFileGY02
    {
        private readonly JavaProperties prop = new JavaProperties();
        private readonly SeekPath seek = new SeekPath();
        private readonly string dir;

        public FilePropertiesGY02()
        {
            this.dir = seek.SeekDirectory();
        }

        public override void ReadFile(string loadFile)
        {
            prop.Load(dir, loadFile);
        }//ReadFile()

        public override void WriteFile(string saveFile)
        {
            string header = BuildHeader();
            prop.Store(dir, saveFile, header);
        }//WriteFile()

        private string BuildHeader()
        {
            var dtNow = DateTime.Now;
            var bld = new StringBuilder(50);
            bld.Append("written by FilePropertiesGY02\n");
            bld.Append($"# {dtNow}");

            return bld.ToString();
        }//BuildHeader()

        public override void SetProperty(string key, string value)
        {
            prop.SetDictionary(key, value);
        }

        public override string GetValue(string key)
        {
            return prop.GetValue(key);
        }

        public override string ToStringAll(string header = "")
        {
            return prop.ToStringAll(header);
        }
    }//class
}
