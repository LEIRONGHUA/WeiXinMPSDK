﻿#region Apache License Version 2.0
/*----------------------------------------------------------------

Copyright 2025 Jeffrey Su & Suzhou Senparc Network Technology Co.,Ltd.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
either express or implied. See the License for the specific language governing permissions
and limitations under the License.

Detail: https://github.com/JeffreySu/WeiXinMPSDK/blob/master/license.md

----------------------------------------------------------------*/
#endregion Apache License Version 2.0

/*----------------------------------------------------------------
    Copyright (C) 2025 Senparc
  
    文件名：UploadImageReturnJson.cs
    文件功能描述：图片上传接口返回Json类
    
    
    创建标识：Senparc - 20210922
    
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senparc.Weixin.TenPayV3.Apis.Entities;

namespace Senparc.Weixin.TenPayV3.Apis.Marketing
{
    /// <summary>
    /// 图片上传接口返回Json类
    /// <para>详细请参考微信支付官方文档 https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter9_0_1.shtml </para>
    /// </summary>
    public class UploadImageReturnJson : ReturnJsonBase
    {
        /// <summary>
        /// 含参构造函数
        /// </summary>
        /// <param name="media_url">媒体文件URL地址 <para>微信返回的媒体文件标识url。有效期为永久</para><para>示例值：https://qpic.cn/xxx</para></param>
        public UploadImageReturnJson(string media_url)
        {
            this.media_url = media_url;
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public UploadImageReturnJson()
        {
        }

        /// <summary>
        /// 媒体文件URL地址
        /// <para>微信返回的媒体文件标识url。有效期为永久</para>
        /// <para>示例值：https://qpic.cn/xxx</para>
        /// </summary>
        public string media_url { get; set; }
    }
}


