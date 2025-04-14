namespace YunHu.Responses;

public record YunHuUploadFileResponseData(string FileKey);

public class YunHuUploadFileResponse : YunHuResponse<YunHuUploadFileResponseData>;
