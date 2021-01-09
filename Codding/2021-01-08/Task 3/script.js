var johnTeamAvg = (89 + 120 + 103)/3;
var mikeTeamAvg = (116 + 94 + 123)/3;

console.log("John's and Mike's match")
// Here check Team won using ternary operator
var winTeam = console.log((johnTeamAvg > mikeTeamAvg)? ("John Team Wins: "+johnTeamAvg):("Mike Team Wins: " +mikeTeamAvg));

console.log("\nNow add Merry Team and check who won");

var merryTeamAvg = (97 + 134 + 105)/3;

// Here we check who win match ? John, win or Merry
if (johnTeamAvg > mikeTeamAvg && johnTeamAvg > merryTeamAvg)
{
	console.log("John's Team won");
}
else if (mikeTeamAvg > johnTeamAvg &&  mikeTeamAvg > merryTeamAvg)
{
	console.log("Mike Team Won");
}
else if (merryTeamAvg > johnTeamAvg && merryTeamAvg > mikeTeamAvg)
{
	console.log("Merry Team won");
}
else if (johnTeamAvg == mikeTeamAvg && johnTeamAvg > merryTeamAvg)
{
	console.log("John's and Mike's Team Draws");
}
else if (johnTeamAvg == merryTeamAvg && johnTeamAvg > mikeTeamAvg)
{
	console.log("John's and Merry's Team Draws");
}
else if (mikeTeamAvg == merryTeamAvg && mikeTeamAvg > johnTeamAvg)
{
	console.log("Mike's and Merry's Team Draws");
}
else
{
	console.log("All teams are Draw");
}

console.log("\nScore enter by User");
//Now if the score change by user
var johnMatch1 = prompt("Enter John match 1 score: ");
var johnMatch2 = prompt("Enter John match 2 score: ");
var johnMatch3 = prompt("Enter John match 3 score: ");

var mikeMatch1 = prompt("Enter Mike match 1 score: ");
var mikeMatch2 = prompt("Enter Mike match 2 score: ");
var mikeMatch3 = prompt("Enter Mike match 3 score: ");


var merryMatch1 = prompt("Enter Merry match 1 score: ");
var merryMatch2 = prompt("Enter Merry match 2 score: ");
var merryMatch3 = prompt("Enter Merry match 3 score: ");

johnTeamAvg = (johnMatch1 + johnMatch2 + johnMatch3)/3;
mikeTeamAvg = (mikeMatch1 + mikeMatch2 + mikeMatch3)/3;
merryTeamAvg = (merryMatch1 + merryMatch2 + merryMatch3)/3;

if (johnTeamAvg > mikeTeamAvg && johnTeamAvg > merryTeamAvg)
{
	console.log("John's Team won");
}
else if (mikeTeamAvg > johnTeamAvg &&  mikeTeamAvg > merryTeamAvg)
{
	console.log("Mike Team Won");
}
else if (merryTeamAvg > johnTeamAvg && merryTeamAvg > mikeTeamAvg)
{
	console.log("Merry Team won");
}
else if (johnTeamAvg == mikeTeamAvg && johnTeamAvg > merryTeamAvg)
{
	console.log("John's and Mike's Team Draws");
}
else if (johnTeamAvg == merryTeamAvg && johnTeamAvg > mikeTeamAvg)
{
	console.log("John's and Merry's Team Draws");
}
else if (mikeTeamAvg == merryTeamAvg && mikeTeamAvg > johnTeamAvg)
{
	console.log("Mike's and Merry's Team Draws");
}
else
{
	console.log("All teams are Draw");
}