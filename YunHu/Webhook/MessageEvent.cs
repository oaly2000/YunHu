namespace YunHu.Webhook;

public class MessageEvent
{
    required public YunHuWebhookMessageEventSender Sender { get; set; }
    required public YunHuWebhookMessageEventChat Chat { get; set; }
    required public YunHuWebhookMessageEventMessage Message { get; set; }
}
