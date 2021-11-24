using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SourceGenerators
{

    public class Foo
    {
        public void Test()
        {
            var json = JsonSerializer.Serialize(new Person("Ilkay", "Ilknur"), SourceGenerationContext.Default.Person);
        }
    }



    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Person))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
    public record Person(string Name, string Surname);
}
