//Bill amount give in  array
var bill = [124, 48, 268]; 
var tip = []; 
var totelAmount = [124,48,268]; 

//we count tip
function tipCalculator(amount)
{
        var tipPer;
        if (amount <= 50) {
            tipPer = 0.20;
        } else if (50 < amount <= 200) {
            tipPer = 0.15;
        } else {
            tipPer = 0.10;
        }
    return tipPer *  amount;
}

//find the totel amount of bill
for (i = 0; i< bill.length; i++)
{
    tip[i] = tipCalculator(bill[i]);
    totelAmount[i] += tip[i];
    console.log(" Tip " + [i+1] + ": " + tip[i]);
}

//amount value before and after tips
console.log("\nBills before tips: " + bill);
console.log("Final Bill with tips: " + totelAmount);