namespace YunHu.Responses;

public class YunHuSendMessageResponseData
{
    required public MessageInfo MessageInfo { get; set; }
}

public record MessageInfo(string MsgId, string RecvId, string RecvType);

public class YunHuSendMessageResponse: YunHuResponse<YunHuSendMessageResponseData>;

public class YunHuBatchMessageResponseData
{
    public int SuccessCount { get; set; }
    required public IEnumerable<MessageInfo> SuccessList { get; set; }
}

public class YunHuBatchMessageResponse: YunHuResponse<YunHuBatchMessageResponseData>;
