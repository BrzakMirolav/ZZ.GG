using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace BusinessModel.GlobalModels
{

    public class ApiMessage
    {
        public string? Text { get; set; }
        public MessageType Type { get; set; }
    }
}
