namespace YunHu.Requests;

public class YunHuRecallMessageReq
{
    required public string MsgId { get; set; }

    required public string ChatId { get; set; }

    required public string ChatType { get; set; }
}
