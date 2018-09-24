<Query Kind="Statements" />

//from char letter in "Dan Gilleland"
//select letter
string[] names = {"Dan", "Don", "Sam"};
names.Dump();
var result = from item in names
		     select item;
result.Dump();