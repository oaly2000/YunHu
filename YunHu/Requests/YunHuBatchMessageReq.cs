using YunHu.Messages;

namespace YunHu.Requests;

public class YunHuBatchMessageReq(string[] recvIds, string recvType, YunHuMessageContent content)
{
    public string[] RecvIds { get; set; } = recvIds;
    public string RecvType { get; set; } = recvType;
    public string ContentType { get; set; } = content.GetContentType();
    public YunHuMessageContent Content { get; set; } = content;
}
