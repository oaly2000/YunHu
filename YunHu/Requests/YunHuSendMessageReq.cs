using YunHu.Messages;

namespace YunHu.Requests;

public class YunHuSendMessageReq(string recvId, string recvType, YunHuMessageContent content, string? parentId = null)
{
    public string RecvId { get; set; } = recvId;
    public string RecvType { get; set; } = recvType;
    public string? ParentId { get; set; } = parentId;
    public string ContentType { get; set; } = content.GetContentType();
    public YunHuMessageContent Content { get; set; } = content;
}
