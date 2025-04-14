using System.Text.Json.Serialization;

namespace YunHu.Messages;

[JsonPolymorphic]
[JsonDerivedType(typeof(YunHuTextMessageContent), YunHuMessageContentType.Text)]
[JsonDerivedType(typeof(YunHuImageMessageContent), YunHuMessageContentType.Image)]
[JsonDerivedType(typeof(YunHuVideoMessageContent), YunHuMessageContentType.Video)]
[JsonDerivedType(typeof(YunHuFileMessageContent), YunHuMessageContentType.File)]
[JsonDerivedType(typeof(YunHuMarkdownMessageContent), YunHuMessageContentType.Markdown)]
[JsonDerivedType(typeof(YunHuHtmlMessageContent), YunHuMessageContentType.Html)]
public abstract class YunHuMessageContent
{
    public IEnumerable<YunHuMessageButton>? Buttons { get; set; }

    public abstract string GetContentType();
}

public class YunHuTextMessageContent : YunHuMessageContent
{
    required public string Text { get; set; }

    override public string GetContentType() => YunHuMessageContentType.Text;
}

public class YunHuImageMessageContent : YunHuMessageContent
{
    required public string ImageKey { get; set; }

    override public string GetContentType() => YunHuMessageContentType.Image;
}

public class YunHuVideoMessageContent : YunHuMessageContent
{
    required public string VideoKey { get; set; }

    override public string GetContentType() => YunHuMessageContentType.Video;
}

public class YunHuFileMessageContent : YunHuMessageContent
{
    required public string FileKey { get; set; }

    override public string GetContentType() => YunHuMessageContentType.File;
}

public class YunHuMarkdownMessageContent : YunHuMessageContent
{
    required public string Text { get; set; }

    override public string GetContentType() => YunHuMessageContentType.Markdown;
}

/// <summary>
/// see https://www.yhchat.com/c/p/863
/// </summary>
public class YunHuHtmlMessageContent : YunHuMessageContent
{
    required public string Text { get; set; }

    override public string GetContentType() => YunHuMessageContentType.Html;
}
