---
_layout: landing
---

#### 云湖.NET SDK

此SDK适用于.NET 8.0 及以上版本。

相较官方几个语言版本的轻量级，此SDK更加“重量”，提供了强类型以及字符串值的枚举。

#### 示例

这是一个控制台应用的例子，你可以去[GitHub](https://github.com/oaly2000/YunHu)查看完整代码

```csharp
using YunHu;
using YunHu.Requests;
using Microsoft.Extensions.Configuration;
using YunHu.Messages;
using System.Text.Json;

using static YunHu.Messages.YunHuChatType;
using static YunHu.Messages.YunHuMessageContentType;

var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

var options = new YunHuClientOptions { Token = configuration["YunHuToken"]! };

var bot = new YunHuClient(new HttpClient(), options)!;

// video
var r5 = await bot.UploadVideoAsync(
    new FileInfo(@"D:\Users\fei\Videos\Screen Recordings\Screen Recording 2025-04-14 193555.mp4"));
var r6 = await bot.SendMessageAsync(
    new YunHuSendMessageReq("8600931", User, new YunHuVideoMessageContent { VideoKey = r5!.Data.VideoKey }));
Console.WriteLine(JsonSerializer.Serialize(r6));
```

Webhook的话我从golang的sdk抄了一份类型，用法如下

```csharp
app.MapPost("/", async Task ([FromBody] YunHuWebhookMessage<MessageEvent> message) =>
{
    if (message.Header.EventType != WebhookEventType.MessageEvent) return;

    _ = await bot.SendMessageAsync(new(message.Event.Sender.SenderId, User, new YunHuMarkdownMessageContent { Text = $"""
    ```json
    {JsonSerializer.Serialize(message, jsonSerializerOptions)}
    ```
    """ }));
});
```

#### 开源

https://github.com/oaly2000/YunHu

欢迎贡献代码、修复BUG

#### 许可证

MIT