# 1. IPv4가 유효한지 확인하는 코드
``` c#
using System.Text.RegularExpressions;

Console.WriteLine("Enter IPv4 : ");
string ipv4 = Console.ReadLine();

string format = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

if (Regex.IsMatch(ipv4, format))
{
    Console.WriteLine("IPv4 is valid");
}
else
{
    Console.WriteLine("IPv4 is invalid");
}
```

# 2. 간단 연습 - 주사위 게임
``` c#
Random random = new ();

while (true) {
    int target = random.Next(1, 7);
    Console.WriteLine($"The target is {target}.");
    if (ShouldPlay())
    {
        int roll = random.Next(1, 6);
        Console.WriteLine($"You rolled {roll}.");
        string result = WinOrLose(roll, target);
        Console.WriteLine(result);
        if (result == "You lose!")
        {
            break;
        }
    } else {
        break;
    }
}

bool ShouldPlay() {
    Console.WriteLine("Do you want to roll the dice? (Y/N)");
    string yesNo = Console.ReadLine();

    if (yesNo.ToUpper() == "Y")
    {
        return true;
    } else if (yesNo.ToUpper() == "N")
    {
        return false;
    } else {
        return false;
    }
}

string WinOrLose(int roll, int target) {
    if (roll > target)
    {
        return "You win!";
    } else {
        return "You lose!";
    }
}
```