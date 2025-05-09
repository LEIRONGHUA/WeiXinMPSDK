﻿/*----------------------------------------------------------------
    Copyright (C) 2025 Senparc
    
    文件名：PlateNumJsonResult.cs
    文件功能描述：OCR 车牌识别返回结果
    
    
    创建标识：yaofeng - 20231204

----------------------------------------------------------------*/

using Senparc.Weixin.Entities;

namespace Senparc.Weixin.MP.AdvancedAPIs.CV.OCR
{
    /// <summary>
    /// 车牌识别
    /// </summary>
    public class PlateNumJsonResult : WxJsonResult
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string number { get; set; }
    }
}
