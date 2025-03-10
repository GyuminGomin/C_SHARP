## 방법

### 새로운 프로젝트 시작 1
``` console
$ dotnet new console -o ./CsharpProjects/TestProject

Ctrl + F5 로 빌드 및 실행
또는
$ dotnet run
```

### 새로운 프로젝트 시작 2
```
in vscode
1. C# Devkit 설치 in Extension Marketplace
2. Ctrl + Shift + P
    - Welcome: Open Walkthrough
    - Get Started with C# Dev Kit
3. Set up your environment 선택
    - Install .NET SDK
        - Install Latest version
4. Ctrl + Shift + P
    - .NET:New Project
    - Console App
        - 프로젝트 이름 설정
5. Program.cs에서 Ctrl + F5 로 빌드 및 실행
```

## 빌드
### 기존 프로젝트 시작
``` console
$ dotnet --version
$ dotnet restore
$ dotnet build

- 빌드 및 실행
Ctrl + F5

- 만약 dotnet 버전을 변경하고 싶다면
dotnet clean후, csproj 파일을 수정한 후 다시 build
```

# C#
- 변수 명명 규칙
    - 카멜케이스 thisIsCamelCase
    - 밑줄은 사용 x (특별한 용도로 사용하기 때문)
    - 축약이나 약어 사용 x
    - 변수이름에 데이터 형식을 포함 x

- 암시적 형식 지역 변수
    - var
        - 컴파일러가 자동으로 형식을 반환

- 축자 문자열 리터럴,<br/> 유니코드 이스케이프, <br/>문자열 보간
``` C#
// 축자 문자열 리터럴과 문자열 보간 같이 사용 가능
Console.WriteLine(@"    c:\source\repos()");
Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");
string greeting = "Hello";
string firstName = "Tim";
string message = $"{greeting} {firstName}!";
```

- 대상 형식 생성자 호출을 반복하지 않고 개체 인스턴스화
``` c#
//Random dice = new Random();
Random dice = new();
int roll = dice.Next(1, 7);
Console.WriteLine($"Dice roll: {roll}");
```

- 참고문서  
<a href="https://learn.microsoft.com">https://learn.microsoft.com</a>

- 조건 연산자
``` c#
string permission = "Admin|Manager";
int level = 55;

string message = permission.Contains("Admin") ?
 (level > 55 ? "Welcome, Super Admin user." : "Welcome, Admin user.") : permission.Contains("Manager") ?
 (level >= 20 ? "Contact an Admin for access." : "You do not have sufficient privileges.") : "You do not have sufficient privileges.";
```

### 자바에는 존재하지 않는 C#만의 확장 메서드
``` c#
///////////////////////////// ArrayExtensions.cs
using System;

/**
 * toStringCustom method is an extension method for the Array class.
 */
namespace ArrayExtensions
{
    public static class ArrayExtensions
    {
        public static string ToStringCustom<T>(this T[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }
    }
}

///////////////////////////// Program.cs
using System;
using ArrayExtensions;

string[] fraudulentOrderIDs = [ "A123", "B456", "C789" ];

Console.WriteLine(fraudulentOrderIDs.ToStringCustom());
```

- 배열 명명 규칙
``` c#
using System;
using ArrayExtensions;

// 둘 다 동일
string[] fraudulentOrderIDs = [ "A123", "B456", "C789" ];
string[] fraudulentOrderIDs2 = { "A123", "B456", "C789" };

Console.WriteLine(fraudulentOrderIDs.ToStringCustom());
Console.WriteLine(fraudulentOrderIDs2.ToStringCustom());
```

### 자바와 다른 메소드들
``` c#
Console.WriteLine("Enter an integer value between 5 and 10");

while (true) {
    String input = Console.ReadLine();
    // 중요!
    int.TryParse(input, out int number);

    if (number >= 5 && number <= 10) {
        Console.WriteLine($"Your input value ({number}) has been accepted.");
        break;
    } else {
        Console.WriteLine($"You entered {number}. Please enter a number between 5 and 10: ");
        continue;
    }
}
```