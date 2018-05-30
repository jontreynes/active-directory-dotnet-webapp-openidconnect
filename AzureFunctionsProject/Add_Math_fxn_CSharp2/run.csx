#r "Newtonsoft.Json"

using System.Net;
using Newtonsoft.Json;


public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    dynamic body = await req.Content.ReadAsStringAsync();
    var e = JsonConvert.DeserializeObject<EventData>(body as string);

    int x = 0;
    int y = 0;
    int z = 0;

    int.TryParse(e.x_number, out x);
    int.TryParse(e.y_number, out y);

    z = x+y;
    
    
    return req.CreateResponse(HttpStatusCode.OK, z);

}

public class EventData
{
    public string x_number { get; set; }
    public string y_number { get; set; }
}