
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

//Serialize support for IAsyncEnumerable
using var ms = new MemoryStream();
await JsonSerializer.SerializeAsync(ms, GetAsyncEnumerable());


//Deserialize support for IAsyncEnumerable
var json = "[1,2,3,4,5,6,7,8,9,10]";
using var ms2 = new MemoryStream(Encoding.UTF8.GetBytes(json));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(ms2))
{
    Console.WriteLine(item);
}


//Writable DOM APIs
// Parse a JSON object
JsonNode jNode = JsonNode.Parse("{\"MyProperty\":42}");
int value = (int)jNode["MyProperty"];
// or
value = jNode["MyProperty"].GetValue<int>();

// Parse a JSON array
jNode = JsonNode.Parse("[10,11,12]");
value = (int)jNode[1];
// or
value = jNode[1].GetValue<int>();

// Create a new JsonObject using object initializers and array params
var jObject = new JsonObject
{
    ["MyChildObject"] = new JsonObject
    {
        ["MyProperty"] = "Hello",
        ["MyArray"] = new JsonArray(10, 11, 12)
    }
};

// Obtain the JSON from the new JsonObject
string json2 = jObject.ToJsonString();
Console.WriteLine(json); // {"MyChildObject":{"MyProperty":"Hello","MyArray":[10,11,12]}}


async IAsyncEnumerable<int> GetAsyncEnumerable()
{
    for (int i = 0; i < 10; i++)
    {
        yield return i;
        await Task.Delay(500);
    }
}


//Json property ordering
public class Person
{
    public string City { get; set; } // No order defined (has the default ordering value of 0)

    [JsonPropertyOrder(1)] // Serialize after other properties that have default ordering
    public string FirstName { get; set; }

    [JsonPropertyOrder(2)] // Serialize after FirstName
    public string LastName { get; set; }

    [JsonPropertyOrder(-1)] // Serialize before other properties that have default ordering
    public int Id { get; set; }
}

//Json Serialization notifications
public class Person2 : IJsonOnDeserialized, IJsonOnSerializing
{
    public string FirstName { get; set; }

    void IJsonOnDeserialized.OnDeserialized() => Validate(); // Call after deserialization
    void IJsonOnSerializing.OnSerializing() => Validate(); // Call before serialization

    private void Validate()
    {
        if (FirstName is null)
        {
            throw new InvalidOperationException("The 'FirstName' property cannot be 'null'.");
        }
    }
}