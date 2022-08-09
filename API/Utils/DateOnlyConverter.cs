using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Utils
{
   public class DateOnlyConverter : JsonConverter<DateOnly>
   {
      private readonly string serializationFormat;

      public DateOnlyConverter() : this(null)
      {
      }

      public DateOnlyConverter(string? serializationFormat)
      {
         this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
      }

      public override DateOnly Read(ref Utf8JsonReader reader,
                              Type typeToConvert, JsonSerializerOptions options)
      {
         reader.Read();
         reader.Read();
         var valueYear = reader.GetInt32();
         reader.Read();
         reader.Read();
         var valueMonth = reader.GetInt32();
         reader.Read();
         reader.Read();
         var valueDay = reader.GetInt32();
         reader.Read();

         return new DateOnly(valueYear, valueMonth, valueDay);
      }

      public override void Write(Utf8JsonWriter writer, DateOnly value,
                                          JsonSerializerOptions options)
          => writer.WriteStringValue(value.ToString(serializationFormat));
   }
}
