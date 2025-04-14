namespace YunHu.Responses;

public class YunHuResponse
{
    public int Code { get; set; }

    required public string Msg { get; set; }
}

public class YunHuResponse<T> : YunHuResponse
{
    required public T Data { get; set; }
}

