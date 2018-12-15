
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CatchOrderList.data
{
    public class UserValidation
    {
        /// <summary>
        /// 剩余使用次数
        /// </summary>
        public static int LastUseCount = 0;
        /// <summary>
        /// 标记软件是否注册
        /// 加入软件狗
        /// </summary>
        public static bool IsRegister
        {
            get
            {
                bool isVal = false;
                return true;
                try
                {
                    CRockey2 ry2_Find = new CRockey2();
                    int iMax = CRockey2.Find();
                    if (iMax > 0)
                    {
                        uint uid = 0;
                        uint hid = 0;
                        iMax = CRockey2.Open(CRockey2.AUTO_MODE, uid, ref hid);
                        if (iMax >= 0)
                        {
                            int handle = iMax;
                            int block_index = 0;
                            StringBuilder csReadData = new StringBuilder("", 512);
                            CRockey2 ry2_Read = new CRockey2();
                            iMax = CRockey2.Read(handle, block_index, csReadData);
                            if (iMax >= 0)
                            {
                                string data = Express.Common.DEncrypt.DESEncrypt.Decrypt(csReadData.ToString());
                                if(data.Contains("|"))
                                {
                                    string[] cmds = data.Split('|');
                                    if(cmds.Length>=3)
                                    {
                                        if (cmds[0].ToLower().Contains("version:"))
                                        {
                                            isVal = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return isVal;
            }
        }

        private char[] Seed
        {
            get
            {
                string seed = "@alibaba#tengxun$baidu*fuwenjun";
                return Express.Common.DEncrypt.DESEncrypt.Encrypt(seed).ToCharArray();
            }
        }

        /// <summary>
        /// 验证使用次数
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            
            if(IsRegister)
            {
                return true;
            }
            bool isValidate = false;
            try
            {
                if (!SearchItemRegEdit("SOFTWARE", "Windows32Retry"))
                {
                    CreateItemRegEdit(@"SOFTWARE\Windows32Retry");
                    string data = Express.Common.DEncrypt.DESEncrypt.Encrypt("ABC00030");
                    SetValueRegEdit(@"SOFTWARE\Windows32Retry", "winsoftRecord", data);
                }
                string rdate = getValueRegEdit(@"SOFTWARE\Windows32Retry", "winsoftRecord");
               
                string date = "";
                if(!string.IsNullOrEmpty(rdate))
                {
                   date= Express.Common.DEncrypt.DESEncrypt.Decrypt(rdate);
                }
                if(date.Length==8)
                {
                    int num = int.Parse(date.Substring(6));
                    if (num > 0)
                    {
                        LastUseCount = num - 1;
                    }
                    if (LastUseCount > 0)
                    {
                        string data = Express.Common.DEncrypt.DESEncrypt.Encrypt("ABC000" + LastUseCount.ToString().PadLeft(2, '0'));
                        if (SetValueRegEdit(@"SOFTWARE\Windows32Retry", "winsoftRecord", data) == 1)
                        {
                            isValidate = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValidate;
        }


        /// <summary>
        /// 获得要找到的注册表项
        /// </summary>
        /// <param name="path">注册表路经</param>
        /// <returns>返回注册表对象</returns>
        private bool CreateItemRegEdit(string path)
        {
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;

                obj.CreateSubKey(path);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 设置注册表项下面的值
        /// </summary>
        /// <param name="path">路经</param>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        private int SetValueRegEdit(string path, string name, string value)
        {
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey objItem = obj.OpenSubKey(path, true);
                objItem.SetValue(name, value);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 查看注册表指定项的值
        /// </summary>
        /// <param name="path">路经</param>
        /// <param name="name">项名称</param>
        /// <returns>项值</returns>
        private string getValueRegEdit(string path, string name)
        {
            string value;
            try
            {
                Microsoft.Win32.RegistryKey obj = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey objItem = obj.OpenSubKey(path);
                value = objItem.GetValue(name).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("软件运行权限不够，请使用管理员权限运行软件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
            return value;
        }


        /// <summary>
        /// 查看注册表项是否存在
        /// </summary>
        /// <param name="value">路经</param>
        /// <param name="name">项名称</param>
        /// <returns>是否存在</returns>
        private bool SearchItemRegEdit(string path, string name)
        {
            string[] subkeyNames;

            Microsoft.Win32.RegistryKey hkml = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey software = hkml.OpenSubKey(path);

            subkeyNames = software.GetSubKeyNames();

            //取得该项下所有子项的名称的序列，并传递给预定的数组中   

            foreach (string keyName in subkeyNames)   //遍历整个数组   
            {

                if (keyName.ToUpper() == name.ToUpper()) //判断子项的名称   
                {
                    hkml.Close();
                    return true;
                }

            }

            hkml.Close();

            return false;

        }

        /// <summary>
        /// 查看注册表的值是否存在
        /// </summary>
        /// <param name="value">路经</param>
        /// <param name="value">查看的值</param>
        /// <returns>是否成功</returns>
        private bool SearchValueRegEdit(string path, string value)
        {

            string[] subkeyNames;

            Microsoft.Win32.RegistryKey hkml = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey software = hkml.OpenSubKey(path);

            subkeyNames = software.GetValueNames();

            //取得该项下所有键值的名称的序列，并传递给预定的数组中   

            foreach (string keyName in subkeyNames)
            {

                if (keyName.ToUpper() == value.ToUpper())   //判断键值的名称   
                {

                    hkml.Close();

                    return true;

                }

            }

            hkml.Close();

            return false;

        }
    }
}
