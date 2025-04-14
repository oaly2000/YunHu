namespace YunHu.Webhook;

public class ButtonReportInlineEvent
{
    required public string MsgId { get; set; }
    required public string RecvId { get; set; }
    required public string RecvType { get; set; }
    required public long Time { get; set; }
    required public string UserId { get; set; }
    required public string Value { get; set; }
}
