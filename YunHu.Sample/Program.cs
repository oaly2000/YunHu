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

// plain text
var r1 = await bot.SendMessageAsync(new YunHuSendMessageReq("8600931", User, new YunHuTextMessageContent { Text = "Hello World!" }));
Console.WriteLine(JsonSerializer.Serialize(r1));
await Task.Delay(500);

// markdown
var r2 = await bot.SendMessageAsync(new YunHuSendMessageReq("8600931", User, new YunHuMarkdownMessageContent { Text = "Hello **World**!" }));
Console.WriteLine(JsonSerializer.Serialize(r2));
await Task.Delay(500);

// image
var r3 = await bot.UploadImageAsync(
    new FileInfo(@"D:\Users\fei\Downloads\e8a21905baf9f83eca705f4309439969ee1f4f3d.jpg@240w_240h_1c_1s_!web-avatar-nav.webp"));
var r4 = await bot.SendMessageAsync(
    new YunHuSendMessageReq("8600931", User, new YunHuImageMessageContent { ImageKey = r3!.Data.ImageKey }));
Console.WriteLine(JsonSerializer.Serialize(r4));
await Task.Delay(500);

// video
var r5 = await bot.UploadVideoAsync(
    new FileInfo(@"D:\Users\fei\Videos\Screen Recordings\Screen Recording 2025-04-14 193555.mp4"));
var r6 = await bot.SendMessageAsync(
    new YunHuSendMessageReq("8600931", User, new YunHuVideoMessageContent { VideoKey = r5!.Data.VideoKey }));
Console.WriteLine(JsonSerializer.Serialize(r6));
await Task.Delay(500);

// file
var r7 = await bot.UploadFileAsync(
    new FileInfo(@"D:\Users\fei\Videos\Screen Recordings\Screen Recording 2025-04-14 193555.mp4"));
var r8 = await bot.SendMessageAsync(
    new YunHuSendMessageReq("8600931", User, new YunHuFileMessageContent { FileKey = r7!.Data.FileKey }));
Console.WriteLine(JsonSerializer.Serialize(r8));
await Task.Delay(500);

// html
var r9 = await bot.SendMessageAsync(new YunHuSendMessageReq("8600931", User, new YunHuHtmlMessageContent { Text = "<h1>Hello World</h1>" }));
Console.WriteLine(JsonSerializer.Serialize(r9));
await Task.Delay(500);

// board
var r10 = await bot.SetBoardAsync(new("8600931", User, Html, "<u>Fuck World!<u>", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600));
Console.WriteLine(JsonSerializer.Serialize(r10));
await Task.Delay(500);

// batch
var r11 = await bot.SendBatchMessageAsync(new (["8600931"], User, new YunHuHtmlMessageContent { Text = "<del>Hello World</del>" }));
Console.WriteLine(JsonSerializer.Serialize(r11));
await Task.Delay(500);

// recall
var r12 = await bot.RecallMessageAsync(new(){ ChatId = "8600931", ChatType = User, MsgId = "224bf71bef14457589773ca2621b9fbf" });
Console.WriteLine(JsonSerializer.Serialize(r12));
await Task.Delay(500);
