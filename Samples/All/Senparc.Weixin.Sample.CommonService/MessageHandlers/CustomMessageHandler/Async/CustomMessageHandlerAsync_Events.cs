﻿/*----------------------------------------------------------------
    Copyright (C) 2025 Senparc
    
    文件名：CustomMessageHandler_Events.cs
    文件功能描述：自定义MessageHandler
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using Senparc.CO2NET.Extensions;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.Sample.CommonService.Download;
using System;
using System.Linq;
using System.Threading.Tasks;

#if NET462
using System.Web;
#endif


namespace Senparc.Weixin.Sample.CommonService.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {
        public override Task<IResponseMessageBase> OnEvent_ClickRequestAsync(RequestMessageEvent_Click requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                var syncResponseMessage = OnEvent_ClickRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
                //常识获取Click事件的同步方法
                if (syncResponseMessage is ResponseMessageText)
                {
                    var textResponseMessage = syncResponseMessage as ResponseMessageText;
                    textResponseMessage.Content += "\r\n\r\n  -- 来自【异步MessageHandler】的回复";
                }

                return syncResponseMessage;
            });
        }

        /// <summary>
        /// 【异步方法】事件之发送模板消息返回结果
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEvent_TemplateSendJobFinishRequestAsync(RequestMessageEvent_TemplateSendJobFinish requestMessage)
        {
            switch (requestMessage.Status)
            {
                case "success":
                    //发送成功

                    break;
                case "failed:user block":
                    //送达由于用户拒收（用户设置拒绝接收公众号消息）而失败
                    break;
                case "failed: system failed":
                    //送达由于其他原因失败
                    break;
                default:
                    throw new WeixinException("未知模板消息状态：" + requestMessage.Status);
            }

            //注意：此方法内不能再发送模板消息，否则会造成无限循环！

            try
            {
                var msg = @"已向您发送模板消息
状态：{0}
MsgId：{1}
（这是一条来自MessageHandler的异步客服消息）".FormatWith(requestMessage.Status, requestMessage.MsgID);
                await CustomApi.SendTextAsync(appId, OpenId, msg);//发送客服消息
            }
            catch (Exception e)
            {
                Senparc.Weixin.WeixinTrace.SendCustomLog("模板消息发送失败", e.ToString());
            }


            //无需回复文字内容
            //return requestMessage
            //    .CreateResponseMessage<ResponseMessageNoResponse>();
            return null;
        }

        public override async Task<IResponseMessageBase> OnEvent_SubscribeRequestAsync(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = GetWelcomeInfo();
            if (!string.IsNullOrEmpty(requestMessage.EventKey))
            {
                responseMessage.Content += "\r\n============\r\n场景值：" + requestMessage.EventKey;
            }

            //推送消息
            //下载文档
            if (requestMessage.EventKey.StartsWith("qrscene_"))
            {
                var sceneId = long.Parse(requestMessage.EventKey.Replace("qrscene_", ""));
                //var configHelper = new ConfigHelper(new HttpContextWrapper(HttpContext.Current));
                var codeRecord =
                    ConfigHelper.CodeCollection.Values.FirstOrDefault(z => z.QrCodeTicket != null && z.QrCodeId == sceneId);

                if (codeRecord != null)
                {
                    if (codeRecord.AllowDownload)
                    {
                        await CustomApi.SendTextAsync(null, OpenId, "下载已经开始，如需下载其他版本，请刷新页面后重新扫一扫。");
                    }
                    else
                    {
                        //确认可以下载
                        codeRecord.AllowDownload = true;
                        await CustomApi.SendTextAsync(null, OpenId, GetDownloadInfo(codeRecord));
                    }
                }
            }

            return responseMessage;
        }

    }
}