namespace P013AspNetMVC.Models
{
    public class ErrorViewModel   // NORMAL B�R CLASS C# DAN B�L�ND��� �ZERE
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}