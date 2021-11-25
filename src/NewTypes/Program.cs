

var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
while (await periodicTimer.WaitForNextTickAsync())
{
    Console.WriteLine("Timer tick");
}


//New properties for getting process ID and path without allocation a process instance
var pId = Environment.ProcessId;
var pPath = Environment.ProcessPath;


//ThrowIfNull
void DoSomethingUseful(object obj)
{
    ArgumentNullException.ThrowIfNull(obj);
}

//WaitAsync Improvements
Task operationTask = SomeLongRunningOperationAsync();
await operationTask.WaitAsync(TimeSpan.FromSeconds(10));

Task SomeLongRunningOperationAsync()
{
    return Task.CompletedTask;
}


//CancellationToken.TryReset
var cts = new CancellationTokenSource();
//Try resetting CTS to reuse it again.
if (!cts.TryReset())
{
    cts = new CancellationTokenSource();
}


//Thread-safe Random
var number = Random.Shared.Next();


//PriorityQueue
var queue = new PriorityQueue<string, int>();
queue.Enqueue("Four", 4);
queue.Enqueue("Two", 2);
queue.Enqueue("Six", 6);
queue.Enqueue("One", 1);

while (queue.TryDequeue(out var element, out var priority))
{
    Console.WriteLine($"Element={element}, Priority={priority}");
}

//Element = One, Priority = 1
//Element = Two, Priority = 2
//Element = Four, Priority = 4
//Element = Six, Priority = 6


var date = DateOnly.FromDateTime(DateTime.Now);
var time = TimeOnly.FromDateTime(DateTime.Now);

