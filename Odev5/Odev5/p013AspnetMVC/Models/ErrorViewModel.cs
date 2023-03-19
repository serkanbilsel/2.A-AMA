namespace P013AspNetMVC.Models
{
    public class ErrorViewModel   // NORMAL BÝR CLASS C# DAN BÝLÝNDÝÐÝ ÜZERE
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}