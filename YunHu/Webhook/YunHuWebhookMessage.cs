using System.Text.Json;

namespace YunHu.Webhook;

public class YunHuWebhookMessage<T>
{
    required public string Version { get; set; }
    required public YunHuWebhookMessageHeader Header { get; set; }
    required public T Event { get; set; }
}

public class YunHuWebhookMessageEventMessage
{
    required public string MsgId { get; set; }
    required public string ParentId { get; set; }
    required public long SendTime { get; set; }
    required public string ChatId { get; set; }
    required public string ChatType { get; set; }
    required public string ContentType { get; set; }
    required public JsonDocument Content { get; set; }
    public int? CommandId { get; set; }
    public string? CommandName { get; set; }
}

public class YunHuWebhookMessageEventChat
{
    required public string ChatId { get; set; }
    required public string ChatType { get; set; }
}

public class YunHuWebhookMessageEventSender
{
    required public string SenderId { get; set; }
    required public string SenderType { get; set; }
    required public string SenderUserLevel { get; set; }
    required public string SenderNickname { get; set; }
}

public class YunHuWebhookMessageHeader
{
    required public string EventId { get; set; }
    required public long EventTime { get; set; }
    required public string EventType { get; set; }
}
