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
    
    文件名：GetWeAnalysisAppidDailyVisitTrendResultJson.cs
    文件功能描述：小程序“数据分析”接口 - 访问趋势：日趋势 返回结果
    
    
    创建标识：Senparc - 20180101

    修改标识：Senparc - 20180718
    修改描述：修改 stay_time_uv,stay_time_session 类型
    
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senparc.Weixin.Entities;

namespace Senparc.Weixin.WxOpen.AdvancedAPIs.DataCube
{
    /// <summary>
    /// 小程序“数据分析”接口 - 访问趋势：日趋势 返回结果
    /// </summary>
    public class GetWeAnalysisAppidDailyVisitTrendResultJson : WxJsonResult
    {
        public List<GetWeAnalysisAppidDailyVisitTrendResultJson_list> list { get; set; }
    }

    /// <summary>
    /// 小程序“数据分析”接口 - 访问趋势：日趋势 返回结果 - list
    /// </summary>
    public class GetWeAnalysisAppidDailyVisitTrendResultJson_list
    {
        /// <summary>
        /// 日期，如：20170313
        /// </summary>
        public string ref_date { get; set; }
        /// <summary>
        /// 打开次数
        /// </summary>
        public int session_cnt { get; set; }
        /// <summary>
        /// 访问次数
        /// </summary>
        public int visit_pv { get; set; }
        /// <summary>
        /// 访问人数
        /// </summary>
        public int visit_uv { get; set; }
        /// <summary>
        /// 新用户数
        /// </summary>
        public int visit_uv_new { get; set; }
        /// <summary>
        /// 人均停留时长 (浮点型，单位：秒)
        /// </summary>
        public double stay_time_uv { get; set; }
        /// <summary>
        /// 次均停留时长 (浮点型，单位：秒)
        /// </summary>
        public double stay_time_session { get; set; }
        /// <summary>
        /// 平均访问深度 (浮点型)
        /// </summary>
        public double visit_depth { get; set; }
    }

}
