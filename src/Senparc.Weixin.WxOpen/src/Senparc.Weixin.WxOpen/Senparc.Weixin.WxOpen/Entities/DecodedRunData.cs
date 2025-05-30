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
    
    文件名：DecodedRunData
    文件功能描述：小程序运动步数解密类
    
    
    创建标识：2019-04-02
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Senparc.Weixin.WxOpen.Entities
{
    //  "stepInfoList": [
    //  {
    //    "timestamp": 1445866601,
    //    "step": 100
    //  },
    //  {
    //    "timestamp": 1445876601,
    //    "step": 120
    //  }
    //]
    [Serializable]
    public class DecodedRunData : DecodeEntityBase
    {
        public List<DecodedRunData_StepModel> stepInfoList { get; set; }
    }

    [Serializable]
    public class DecodedRunData_StepModel
    {
        public long timestamp { get; set; }
        public long step { get; set; }
    }
}