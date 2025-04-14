namespace YunHu.Webhook;

public class BotFollowedEvent
{
    required public string AvatarUrl { get; set; }
    required public string ChatId { get; set; }
    required public string ChatType { get; set; }
    required public string Nickname { get; set; }
    required public long Time { get; set; }
    required public string UserId { get; set; }
}
