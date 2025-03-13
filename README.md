## c# tasks.json, launch.json 설정
`반드시 현재 프로젝트 구조랑 비교해서 확인해보고 개인 프로젝트에 적용시켜 보세요`
``` json
- launch.json -
{
    // Use IntelliSense to learn about possible attributes.
    // Hover to view descriptions of existing attributes.
    // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "buildConsoleAppTest",
            // If you have changed target frameworks, make sure to update the program path.
            "program": "${workspaceFolder}/ConsoleAppTest/bin/Debug/net9.0/ConsoleAppTest.dll",
            "args": [],
            "cwd": "${workspaceFolder}/ConsoleAppTest",
            // For more information about the 'console' field, see https://aka.ms/VSCode-CS-LaunchJson-Console
            "console": "internalConsole",
            "stopAtEntry": false
        },
        {
            "name": ".NET Core Launch2 (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "buildGuided-project-foreach-if-array-CSharp-main",
            // If you have changed target frameworks, make sure to update the program path.
            "program": "${workspaceFolder}/_01.Guided-project-foreach-if-array-CSharp-main/GuidedProject/Starter/bin/Debug/net9.0/Starter.dll",
            "args": [],
            "cwd": "${workspaceFolder}/_01.Guided-project-foreach-if-array-CSharp-main",
            // For more information about the 'console' field, see https://aka.ms/VSCode-CS-LaunchJson-Console
            "console": "internalConsole",
            "stopAtEntry": false
        }
    ]
}

/*
name : 시작 구성에 할당된 읽기 권한자 식별 이름
- 할당된 값은 실행 및 디버그 보기의 맨 위에 있는 제어판의 시작 구성 드롭다운에 표시
type : 시작 구성에 사용할 디버거 형식
- codeclr의 값은 .NET 5+ 및 .NET Core 애플리케이션(C# 애플리케이션 포함)의 디버거 형식을 지정
request : 시작 구성의 요청 유형
- launch 및 attach 값만 지원됨 (현재)
preLaunchTask : 프로그램을 디버깅하기 전에 실행할 작업을 지정
- build의 사전 실행 작업을 지정하면 애플리케이션을 시작하기 전에 dotnet build 명령을 실행함
program : 시작할 애플리케이션 dll 또는 .NET Core 호스트 실행 파일의 경로로 설정됨
cwd : 대상 프로세스의 작업 디렉토리를 지정
args : 시작 시 프로그램에 전달되는 인수를 지정
console : 애플리케이션이 시작될 때 사용되는 콘솔 형식
- 가능한 옵션
    - internalConsole : Visual Studio Code 편집기 아래의 패널 영역에 있는 디버그 콘솔 패널에 해당
    - integratedTerminal : Visual Studio Code 편집기 아래의 패널 영역에 있는 출력 패널에 해당
    - externalTerminal : 외부 터미널 창에 해당. Windows와 함께 제공되는 명령 프롬프트 애플리케이션은 터미널 창의 예
stopAtEntry : 대상의 진입점에서 중지해야 하는 경우 선택적으로 true로 설정
- 이 옵션을 사용하면 프로그램이 시작되자마자 디버거가 중지함
*/
```

``` json
- tasks.json -
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "buildConsoleAppTest",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/ConsoleAppTest/ConsoleAppTest.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "buildGuided-project-foreach-if-array-CSharp-main",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/_01.Guided-project-foreach-if-array-CSharp-main/GuidedProject/Starter/Starter.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
}
```

## 방법

### 새로운 프로젝트 시작 1
``` console
$ dotnet new console -o ./CsharpProjects/TestProject

$ cd <Project 경로>

$ dotnet build
Ctrl + F5 로 빌드 및 실행
또는
$ dotnet run
```

### 새로운 프로젝트 시작 2
```
in vscode
1. C# Devkit 설치 
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

### 직접 서버를 깔고 모든 초기 셋팅하기
```
1. VS Code 확장 프로그램 설치
- C# Dev Kit
- C# Extension (2025 3월 기준 bard83-최신)
- .NET Install Tool for Extension Authors

2. MVC 프로젝트 생성
$ dotnet new mvc -n MyMvcApp (ASP.NET Core MVC 프로젝트 생성)

3. MVC 프로젝트 시작
$ dotnet watch run (핫 리로드 반영) -- 개발 시 이거 사용
$ dotnet run (그냥 빌드 후 런)

4. 라이브러리 추가 방법 (NuGet Package)
$ dotnet add package System.Net.Http (Net.Http는 기본 제공이므로 별도 설치할 필요없지만 다른 패키지 추가할때도 같은 방식 사용하면 됨)

$ dotnet add package Newtonsoft.JSON -- JSON Parsing Library (.csproj 파일에 기록됨)

$ dotnet list package -- 설치된 패키지 목록 출력

$ dotnet remove package Newtonsoft.JSON -- 패키지 제거
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

- 만약 특정 컴파일 경로를 제거하고 싶다면
csproj 파일 설정 추가
<ItemGroup>
    <Compile Remove="_01.MethodSample.cs" />
    <None Include="_01.MethodSample.cs" />
</ItemGroup>

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

- 복합 서식 지정 <br/> 통화 서식 지정 <br/> 숫자 서식 지정 <br/> 백분율 서식 지정 <br/> 
서식 지정 접근
``` c#
string first = "Hello";
string second = "World";
string result = string.Format("{0} {1}!", first, second);
Console.WriteLine(result);

decimal price = 123.45m;
int discount = 50;
Console.WriteLine($"Price: {price:C} (Save {discount:C})");

decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units");
Console.WriteLine($"Measurement: {measurement:N4} units");

decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}");

decimal price = 67.55m;
decimal salePrice = 59.99m;
string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);
Console.WriteLine(yourDiscount);
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

### 캐스팅 잘림 및 변환 반올림 / 반내림
``` c#
int value = (int)1.5m; // casting truncates
Console.WriteLine(value);

int value2 = Convert.ToInt32(1.5m); // converting rounds up
Console.WriteLine(value2);

// 위는 짤림, 아래는 반올림 **
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

### 자바와 다른 데이터 타입
``` c#
Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");

// 결과
/*
Signed integral types:
sbyte  : -128 to 127
short  : -32768 to 32767
int    : -2147483648 to 2147483647
long   : -9223372036854775808 to 9223372036854775807

Unsigned integral types:
byte   : 0 to 255
ushort : 0 to 65535
uint   : 0 to 4294967295
ulong  : 0 to 18446744073709551615

Floating point types:
float  : -3.4028235E+38 to 3.4028235E+38 (with ~6-9 digits of precision)
double : -1.7976931348623157E+308 to 1.7976931348623157E+308 (with ~15-17 digits of precision)
decimal: -79228162514264337593543950335 to 79228162514264337593543950335 (with 28-29 digits of precision)
*/
```