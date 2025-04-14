using System.Collections.Specialized;

namespace YunHu.Requests;

public class YunHuListMessageReq
{
    required public string ChatId { get; set; }

    required public string ChatType { get; set; }

    public string? MessageId { get; set; }

    public int Before { get; set; }

    public int After { get; set; }

    public NameValueCollection ToNameValueCollection() => new()
    {
        { "chat-id", ChatId },
        { "chat-type", ChatType },
        { "message-id", MessageId },
        { "before", Before.ToString() },
        { "after", After.ToString() }
    };
}