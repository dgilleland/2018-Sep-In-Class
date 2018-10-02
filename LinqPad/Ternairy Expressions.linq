<Query Kind="Statements" />

Random rnd = new Random();
int coinSide = rnd.Next(2); // result in either 0 or 1
string coinSideName =
    coinSide == 0 ? // if (coinSide == 0)
	"Heads"
	:               // else
	"Tails";
coinSideName.Dump();

// Assuming that the first day of the week is Sunday,
// and that it can be called day 0....
int today = 4; // today is Thursday...
// a Ternary expression is one where you can
// get one of two possible values, depending
// on the result of a boolean expression
//    conditionalExpression ? valueToUseIfTrue : valueToUseIfFalse
string dayName = today == 0 ? "Sunday"
               : today == 1 ? "Monday"
			   : today == 2 ? "Tuesday"
			   : today == 3 ? "Wednesday"
			   : today == 4 ? "Thursday"
			   : today == 5 ? "Friday"
			   : "Saturday";
dayName.Dump();
