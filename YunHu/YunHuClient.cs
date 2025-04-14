using System.Net.Http.Json;
using YunHu.Requests;
using YunHu.Responses;

namespace YunHu;

public class YunHuClient(HttpClient httpClient, YunHuClientOptions options)
{
    private const string _baseUrl = "https://chat-go.jwzhd.com/open-apis/v1";

    public async Task<YunHuSendMessageResponse?> SendMessageAsync(YunHuSendMessageReq message)
    {
        var url = $"{_baseUrl}/bot/send?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);

        return await response.Content.ReadFromJsonAsync<YunHuSendMessageResponse>();
    }

    public async Task<YunHuBatchMessageResponse?> SendBatchMessageAsync(YunHuBatchMessageReq message)
    {
        var url = $"{_baseUrl}/bot/batch_send?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);

        return await response.Content.ReadFromJsonAsync<YunHuBatchMessageResponse>();
    }

    public async Task<YunHuResponse?> EditMessageAsync(YunHuEditMessageReq message)
    {
        var url = $"{_baseUrl}/bot/edit?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);

        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }

    public async Task<YunHuResponse?> RecallMessageAsync(YunHuRecallMessageReq message)
    {
        var url = $"{_baseUrl}/bot/recall?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);

        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }

    public async Task<YunHuMessageListResponse?> ListMessagesAsync(YunHuListMessageReq message)
    {
        var url = new UriBuilder($"{_baseUrl}/bot/messages");
        var query = message.ToNameValueCollection();
        query.Add("token", options.Token);
        url.Query = query.ToString();

        return await httpClient.GetFromJsonAsync<YunHuMessageListResponse>(url.Uri);
    }

    public async Task<YunHuUploadImageResponse?> UploadImageAsync(FileInfo file)
    {
        var url = $"{_baseUrl}/image/upload?token={options.Token}";

        var fileStream = file.Open(FileMode.Open);
        var form = new MultipartFormDataContent
        {
            { new StreamContent(fileStream), "image", file.Name }
        };

        var response = await httpClient.PostAsync(url, form);

        await fileStream.DisposeAsync();

        return await response.Content.ReadFromJsonAsync<YunHuUploadImageResponse>();
    }

    public async Task<YunHuUploadVideoResponse?> UploadVideoAsync(FileInfo file)
    {
        var url = $"{_baseUrl}/video/upload?token={options.Token}";

        var fileStream = file.Open(FileMode.Open);
        var form = new MultipartFormDataContent
        {
            { new StreamContent(fileStream), "video", file.Name }
        };

        var response = await httpClient.PostAsync(url, form);

        await fileStream.DisposeAsync();

        return await response.Content.ReadFromJsonAsync<YunHuUploadVideoResponse>();
    }

    public async Task<YunHuUploadFileResponse?> UploadFileAsync(FileInfo file)
    {
        var url = $"{_baseUrl}/file/upload?token={options.Token}";

        var fileStream = file.Open(FileMode.Open);
        var form = new MultipartFormDataContent
        {
            { new StreamContent(fileStream), "file", file.Name }
        };

        var response = await httpClient.PostAsync(url, form);

        await fileStream.DisposeAsync();

        return await response.Content.ReadFromJsonAsync<YunHuUploadFileResponse>();
    }

    public async Task<YunHuResponse?> SetBoardAsync(YunHuSetBoardReq message)
    {
        var url = $"{_baseUrl}/bot/board?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);
        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }

    public async Task<YunHuResponse?> DismissBoardAsync(YunHuDismissBoardReq message)
    {
        var url = $"{_baseUrl}/bot/board-dismiss?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);
        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }

    public async Task<YunHuResponse?> SetBoardAllAsync(YunHuSetBoardAllReq message)
    {
        var url = $"{_baseUrl}/bot/board-all?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, message);
        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }

    public async Task<YunHuResponse?> DismissBoardAllAsync()
    {
        var url = $"{_baseUrl}/bot/board-all-dismiss?token={options.Token}";
        var response = await httpClient.PostAsJsonAsync(url, new { });
        return await response.Content.ReadFromJsonAsync<YunHuResponse>();
    }
}
