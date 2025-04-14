namespace YunHu.Responses;

public record YunHuUploadImageResponseData(string ImageKey);

public class YunHuUploadImageResponse : YunHuResponse<YunHuUploadImageResponseData>;
