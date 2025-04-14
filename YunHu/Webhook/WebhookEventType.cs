namespace YunHu.Webhook;

public static class WebhookEventType
{
    public const string MessageEvent = "message.receive.normal";
    public const string MessageInstructionEvent = "message.receive.instruction";
    public const string GroupJoinEvent = "group.join";
    public const string GroupLeaveEvent = "group.leave";
    public const string BotFollowedEvent = "bot.followed";
    public const string BotUnfollowedEvent = "bot.unfollowed";
    public const string ButtonReportInlineEvent = "button.report.inline";
    public const string BotShortcutMenuEvent = "bot.shortcut.menu";
}
