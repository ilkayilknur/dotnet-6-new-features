
var element = Enumerable.Range(1, 10).ElementAt(^2); // returns 9

//source.Take(..3) instead of source.Take(3)
//source.Take(3..) instead of source.Skip(3)
//source.Take(2..7) instead of source.Take(7).Skip(2)
//source.Take(^3..) instead of source.TakeLast(3)
//source.Take(..^3) instead of source.SkipLast(3)
//source.Take(^7..^3) instead of source.TakeLast(7).SkipLast(3).



var people = new Person[] { new("Francis", 20), new("Lindsey", 30), new("Ashley", 40) };

//MinBy/MaxBy
people.MaxBy(person => person.Age); // ("Ashley", 40)
people.Min(person => person.Age);


//FirstOrDefault/LastOrDefault/SingleOrDefault overloads taking default parameters
people.FirstOrDefault(people => people.Age < 10, new Person("N/A", -1));

//Chunk
IEnumerable<int[]> chunks = Enumerable.Range(0, 10).Chunk(size: 3); // { {0,1,2}, {3,4,5}, {6,7,8}, {9} }

//Zip overload accepting three enumerables
var xs = Enumerable.Range(1, 10);
var ys = xs.Select(x => x.ToString());
var zs = xs.Select(x => x % 2 == 0);

foreach ((int x, string y, bool z) in Enumerable.Zip(xs, ys, zs))
{
}



public record Person(string Name, int Age);