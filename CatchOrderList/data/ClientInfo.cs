using System;
using System.Collections.Generic;
using System.Text;

namespace CatchOrderList.data
{
    internal class ClientInfo
    {
        private static Express.Model.SysSetInfo sysSetInfo;
        /// <summary>
        /// 客户端配置信息
        /// </summary>
        public static Express.Model.SysSetInfo SysSetInfo
        {
            get {
                
                if(null==sysSetInfo)
                {
                    List<Express.Model.SysSetInfo> infos = new Express.BLL.SysSetInfo().GetModelList("");
                    if (infos.Count>0)
                    {
                        sysSetInfo = infos[0];
                    }
                }
                ///如果没有数据，加入默认数据
                if(null==sysSetInfo)
                {
                    sysSetInfo = new Express.Model.SysSetInfo();
                    sysSetInfo.sysId = 1;
                    sysSetInfo.cusname = "***快递公司";
                    sysSetInfo.Remark = "";
                    sysSetInfo.UserName = "";
                    sysSetInfo.Pass = "";
                    sysSetInfo.PageSize = 100;
                    sysSetInfo.PageUrl = "http://qz.yundasys.com:18090/wsd/kjcx/cxend.jsp?wen=59423c58ef4d9e5198083505e7&jmm=59423c58ef4d9e5198083505e7";
                    sysSetInfo.Paream0 = "txm_sm";
                    sysSetInfo.Paream1 = "sm_btn";
                    sysSetInfo.Paream2 = "";
                    sysSetInfo.Paream3 = "";
                    sysSetInfo.Paream4 = "";
                    sysSetInfo.Paream5 = @"c:\";
                    sysSetInfo.Power = "0".PadLeft(255,'0');
                    sysSetInfo.RInterver = 1000;
                    sysSetInfo.RRate = 1000;
                    new Express.BLL.SysSetInfo().Add(sysSetInfo);
                }
                return ClientInfo.sysSetInfo; }
            set {
                ClientInfo.sysSetInfo = value;
                new Express.BLL.SysSetInfo().Update(sysSetInfo);
            }
        }


        public static bool VIP_IsLoadPerDetail
        {
            get {
                return SysSetInfo.Power.Substring(0, 1) == "0" ? false : true;
            }
        }

        public static bool VIP_IsAutoCheck
        {
            get
            {
                return SysSetInfo.Power.Substring(1, 1) == "0" ? false : true;
            }
        }

        public static bool VIP_IsImportVal
        {
            get
            {
                return SysSetInfo.Power.Substring(2, 1) == "0" ? false : true;
            }
        }

        private static Express.Model.Sys_User sys_UserInfo;
        /// <summary>
        /// 当前登录的用户信息
        /// </summary>
        public static Express.Model.Sys_User Sys_UserInfo
        {
            get { return ClientInfo.sys_UserInfo; }
            set { ClientInfo.sys_UserInfo = value; }
        }

        public static string NoteMsg
        {
            get {
                if (!UserValidation.IsRegister)
                {
                    return "未检测到注册信息，该软件还可以试用" + UserValidation.LastUseCount + "次，更多高级功能,请购买正版!联系QQ:380891124";
                }
                else
                {
                    return "尊敬的VIP用户，您现在可以使用系统的所有功能，如有疑问请联系QQ:380891124";
                }
            }
        }
    }
}
