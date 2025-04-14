using YunHu.Messages;

namespace YunHu.Responses;

public record YunHuMessageListResponseDataItem(
    string MsgId,
    string ParentId,
    string SenderId,
    string SenderType,
    string SenderNickname,
    string ContentType,
    YunHuMessageContent Content,
    long SendTime,
    string CommandName,
    int CommandId
);

public class YunHuMessageListResponse : YunHuResponse<IEnumerable<YunHuMessageListResponseDataItem>>;
