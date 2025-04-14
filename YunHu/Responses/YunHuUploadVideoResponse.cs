namespace YunHu.Responses;

public record YunHuUploadVideoResponseData(string VideoKey);

public class YunHuUploadVideoResponse : YunHuResponse<YunHuUploadVideoResponseData>;
