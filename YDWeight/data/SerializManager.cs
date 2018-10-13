using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace YDWeight.data
{
    /// <summary>
    /// 序列化文件
    /// </summary>
    public class SerializManager
    {
        public static bool Set<T>(string filename,T data) where T:class
        {
            string fileName = Application.StartupPath+"//"+filename;
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                //序列化
                using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, data);
                    fs.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                
            }
            return false;
        }

        public static T GetT<T>(string filename) where T : class
        {
            string fileName = Application.StartupPath + "//" + filename;

            try
            {
                if (File.Exists(fileName))
                {
                    //反序列化
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        return bf.Deserialize(fs) as T;
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }
    }
}
