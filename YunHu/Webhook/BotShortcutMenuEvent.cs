namespace YunHu.Webhook;

public class BotShortcutMenuEvent
{
    required public string BotId { get; set; }
    required public string MenuId { get; set; }
    required public long MenuType { get; set; }
    required public long MenuAction { get; set; }
    required public string ChatId { get; set; }
    required public string ChatType { get; set; }
    required public string SenderId { get; set; }
    required public string SenderType { get; set; }
    required public long SendTime { get; set; }
}