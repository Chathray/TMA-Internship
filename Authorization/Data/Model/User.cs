using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication.Models;

namespace WebApplication
{
    [JsonConverter(typeof(WeirdNameSerializer))]
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
        public char Role { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
    }

    public class WeirdNameSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var name = value as User;
            writer.WriteStartObject();

            writer.WritePropertyName("value");
            serializer.Serialize(writer, name.FirstName + " " + name.LastName);
            writer.WritePropertyName("src");
            serializer.Serialize(writer, name.Avatar);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(User).IsAssignableFrom(objectType);
        }
    }
}