namespace YunHu.Webhook;

/// <summary>
/// 特殊的推送事件，由消息中的按钮触发。见 https://www.yhchat.com/document/300-310#按钮汇报事件json结构体示例
/// </summary>
public class YunHuWebHookReportMessage
{
    required public string MsgId { get; set; }
    required public string RecvId { get; set; }
    required public string RecvType { get; set; }
    required public long Time { get; set; }
    required public string UserId { get; set; }
    required public string Value { get; set; }
}