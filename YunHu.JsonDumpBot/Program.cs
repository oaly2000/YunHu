using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using YunHu;
using YunHu.Messages;
using YunHu.Webhook;

using static YunHu.Messages.YunHuChatType;

var builder = WebApplication.CreateBuilder(args);

var options = new YunHuClientOptions { Token = builder.Configuration["YunHuToken"]! };
var bot = new YunHuClient(new HttpClient(), options);
var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/", async Task ([FromBody] YunHuWebhookMessage<MessageEvent> message) =>
{
    if (message.Header.EventType != WebhookEventType.MessageEvent) return;

    _ = await bot.SendMessageAsync(new(message.Event.Sender.SenderId, User, new YunHuMarkdownMessageContent { Text = $"""
    ```json
    {JsonSerializer.Serialize(message, jsonSerializerOptions)}
    ```
    """ }));
});

app.Run();
