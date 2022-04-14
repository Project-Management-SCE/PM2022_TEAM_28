using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebHoly.ViewModels
{
    public class MidrasViewModel
    {
        public string category { get; set; }
        public string commentator { get; set; }
        public string heCommentator { get; set; }
        public  string type { get; set; }
        public string anchorRef { get; set; }
        public string anchorText { get; set; }
        public string sourceRef { get; set; }
        public decimal commentaryNum { get; set; }
        public Int32 anchorVerse { get; set; }

        [JsonConverter(typeof(InfoToStringConverter))]
        public string text { get; set; }
        public string _id { get; set; }
        [Display(Name="ref")]
        public string Ref { get; set; }

        [JsonConverter(typeof(InfoToStringConverter))]
        public string he { get; set; }
    }

    public class InfoToStringConverter : JsonConverter<string>
    {
        public override string Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                return jsonDoc.RootElement.GetRawText();
            }
        }

        public override void Write(
            Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
