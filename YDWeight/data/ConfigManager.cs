using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDWeight.data
{
    public class ConfigManager
    {
        private static SysSetModel _myconfig;
        /// <summary>
        /// 当前配置文档信息
        /// </summary>
        public static SysSetModel MyConfig
        {
            get
            {
                if (_myconfig==null)
                {
                    _myconfig = SerializManager.GetT<SysSetModel>("config.data");
                }
                return _myconfig;
            }
            set
            {
                _myconfig = value;
                SerializManager.Set<SysSetModel>("config.data", value);
            }
        }


        private static List<CollectorModel> _collectores;
        /// <summary>
        /// 收件员操作类
        /// </summary>
        public static List<CollectorModel> CollectorModels
        {
            get
            {
                _collectores = SerializManager.GetT<List<CollectorModel>>("collector.data");
                return _collectores;
            }

            set
            {
                _collectores = value;
                SerializManager.Set<List<CollectorModel>>("collector.data",_collectores);
            }
        }
    }
}
