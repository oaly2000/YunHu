namespace YunHu.Messages;

public class YunHuMessageButton
{
    public string Text { get; private set; }
    public YunHuMessageButtonAction Action { get; private set; }
    public string? Url { get; set; }
    public string? Value { get; set; }

    public YunHuMessageButton(string text, string url)
    {
        Text = text;
        Action = YunHuMessageButtonAction.Redirect;
        Url = url;
    }

    public YunHuMessageButton(string text, string value, YunHuMessageButtonAction action)
    {
        if (action != YunHuMessageButtonAction.Copy && action != YunHuMessageButtonAction.Report)
            throw new ArgumentException("action must be Copy or Push");

        Text = text;
        Action = action;
        Value = value;
    }
}

