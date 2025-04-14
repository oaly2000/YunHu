using YunHu.Messages;

namespace YunHu.Requests;

public class YunHuSetBoardReq(string chatId, string chatType, string contentType, string content, long expireTime, string? memberId = null)
{
    public string ChatId { get; set; } = chatId;
    public string ChatType { get; set; } = chatType;
    public string? MemberId { get; set; } = memberId;
    public string ContentType { get; set; } = contentType switch
    {
        YunHuMessageContentType.Text => YunHuMessageContentType.Text,
        YunHuMessageContentType.Markdown => YunHuMessageContentType.Markdown,
        YunHuMessageContentType.Html => YunHuMessageContentType.Html,
        _ => throw new ArgumentException("Board only support text/markdown/html")  
    };
    public string Content { get; set; } = content;
    public long ExpireTime { get; set; } = expireTime;
}

public class YunHuSetBoardAllReq(YunHuMessageContent content, long expireTime)
{
    public string ContentType { get; set; } = content.GetContentType();
    public YunHuMessageContent Content { get; set; } = content switch
    {
        YunHuTextMessageContent text => text,
        YunHuMarkdownMessageContent markdown => markdown,
        YunHuHtmlMessageContent html => html,
        _ => throw new ArgumentException("Board only support text/markdown/html")
    };
    public long ExpireTime { get; set; } = expireTime;
}
