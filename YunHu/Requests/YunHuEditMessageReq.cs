using YunHu.Messages;

namespace YunHu.Requests;

public class YunHuEditMessageReq(string msgId, string recvId, string recvType, YunHuMessageContent content)
{
    public string MsgId { get; set; } = msgId;
    public string RecvId { get; set; } = recvId;
    public string RecvType { get; set; } = recvType;
    public string ContentType { get; set; } = content.GetContentType();
    public YunHuMessageContent Content { get; set; } = content;
}
