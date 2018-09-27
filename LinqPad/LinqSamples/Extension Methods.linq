<Query Kind="Program" />

void Main()
{
	string name = "Dan";
	
	name.Dump();
	string message = "Hello " + name.Quack(3);
	message.Dump();
}

// Define other methods and classes here
public static class StringExtensions
{
	public static string Quack(this string self)
	{
		return self + " (quack)";
	}
	
	public static string Quack(this string self, int count)
	{
		string backgroundNoise = " ( ";
		while(count > 0)
		{
			backgroundNoise += "quack ";
			count--;
		}
		backgroundNoise += ")";
		return self + backgroundNoise;
	}
}