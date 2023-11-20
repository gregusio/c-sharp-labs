using lab04.city_app;
using lab04.matrix_app;
using lab04.square_app;

var square = new Square();
square.Run();

var matrix = new Matrix();
matrix.Run();

var city = new City();
city.Run();

var list = new List<string>(){"1.2", "2.3", "3.1"};
var query = list.Select(double.Parse).ToList();
query.ForEach(Console.WriteLine);

var listOfLists = new List<List<int>>(){new() {1, 2, 3}, new() {4, 5}};
var listsToList = listOfLists.SelectMany(i => i.ToList()).ToList();
listsToList.ForEach(Console.WriteLine);