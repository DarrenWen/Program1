using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YDWeight.data
{
    /// <summary>
    /// 收件员信息
    /// </summary>
    [Serializable]
    public class CollectorModel
    {
        public string Code { get; set; }
        public string UserName { get; set; }
    }
}
