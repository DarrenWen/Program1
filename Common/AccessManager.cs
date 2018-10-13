using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Express.Common
{
    public class AccessManager
    {
        /// <summary>
        /// 备份Access数据库
        /// </summary>
        /// <param name="srcPath">要备份的数据库绝对路径</param>
        /// <param name="aimPath">备份到的数据库绝对路径</param>
        /// <returns></returns>
        public static bool Backup(string srcPath, string aimPath)
        {

            if (!File.Exists(srcPath))
            {
                throw new Exception("源数据库不存在,无法备份");
            }
            try
            {
                File.Copy(srcPath, aimPath, true);
            }
            catch (IOException ixp)
            {
                return false;
                throw new Exception(ixp.ToString());

            }
            return true;
        }

        /// <summary>
        /// 还原Access数据库
        /// </summary>
        /// <param name="bakPath">备份的数据库绝对路径</param>
        /// <param name="dbPath">要还原的数据库绝对路径</param>
        public static bool RecoverAccess(string bakPath, string dbPath)
        {
            if (!File.Exists(bakPath))
            {
                throw new Exception("备份数据库不存在,无法还原");
            }
            try
            {
                File.Copy(bakPath, dbPath, true);
            }
            catch (IOException ixp)
            {
                return false;
                throw new Exception(ixp.ToString());
            }
            return true;
        }

    }
}
