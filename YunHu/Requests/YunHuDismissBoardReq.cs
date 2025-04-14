namespace YunHu.Requests;

public class YunHuDismissBoardReq
{
    required public string ChatId { get; set; }
    required public string RecvType { get; set; }
    required public string MemberId { get; set; }
}
