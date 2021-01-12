var john, mike, mary;

var score = function avgScore(match1, match2, match3, firstName) {
	var findAvg = (match1 + match2 + match3)/3;

	console.log(firstName + "Average Score: " + findAvg);

	switch(firstName) {
		case "John" : johnAvgScore = findAvg;
					  break;
		case "Mike" : mikeAvgScore = findAvg;
					  break;
		case "Mary" : maryAvgScore = findAvg;

		winTeam(johnAvgScore, mikeAvgScore, maryAvgScore);	
	}

}


john = score(89, 120, 103, "John");
mike = score(116, 94, 123, "Mike");
mary = score(97, 134, 105, "Mary");


function winTeam(johnAvgScore, mikeAvgScore, maryAvgScore) {

	console.log("\n");

	if (johnAvgScore > mikeAvgScore && johnAvgScore > maryAvgScore)
	{
		console.log("John's Team won");
	}
	else if (mikeAvgScore > johnAvgScore &&  mikeAvgScore > maryAvgScore)
	{
		console.log("Mike Team Won");
	}
	else if (maryAvgScore > johnAvgScore && maryAvgScore > mikeAvgScore)
	{
		console.log("Merry Team won");
	}
	else if (johnAvgScore == mikeAvgScore && johnAvgScore > maryAvgScore)
	{
		console.log("John's and Mike's Team Draws");
	}
	else if (johnAvgScore == maryAvgScore && johnAvgScore > mikeAvgScore)
	{
		console.log("John's and Merry's Team Draws");
	}
	else if (mikeAvgScore == maryAvgScore && mikeAvgScore > johnAvgScore)
	{
		console.log("Mike's and Merry's Team Draws");
	}
	else
	{
		console.log("All teams are Draw");
	}

}
