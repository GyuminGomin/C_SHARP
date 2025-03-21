# 중요

### windows Form을 사용하기 위해 반드시 추가 설치 해야하는 Visual Studio 2022 목록
```
- ASP.NET 및 웹 개발
- .NET 데스크톱 개발(필수)
```

### Oracle Database Connect
- ***참고 EF ORM을 사용하기 위해서는 필요없음. -> 다음으로 넘어가시오.***
1. Visual Studio 2022
    - 도구 > NuGet 패키지 관리자 > _패키지 관리자 콘솔_
``` bash
$ Install-Package Oracle.ManagedDataAccess
$ Install-Package Oracle.ManagedDataAccess.Core
-> Core를 설치하니깐 문제없이 잘 동작함 (보니까 위에꺼는 .Net5+ 최신버전에는 잘 적용되지 않고, Core는 경량화되었지만 .Net9같은 최신버전에 호환이 잘됨)

$ Uninstall-Package Oracle.ManagedDataAccess
-> 삭제

$ Get-Package
-> 설치된 목록 확인
```
2. 연결 문자열 설정
    - app.config 파일 생성 후
``` xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="OracleDbContext" connectionString="User Id=<username>;Password=<password>;Data Source=<datasource>" providerName="Oracle.ManagedDataAccess.Client" />
  </connectionStrings>
</configuration>
```

3. 데이터베이스 연결 코드 작성
``` c#
   using Oracle.ManagedDataAccess.Client;

   private void ConnectToDatabase()
   {
       string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;

       using (OracleConnection connection = new OracleConnection(connectionString))
       {
           try
           {
               connection.Open();
               MessageBox.Show("연결 성공!");
               // 데이터베이스 작업 수행
           }
           catch (Exception ex)
           {
               MessageBox.Show($"연결 실패: {ex.Message}");
           }
       }
   }
```
- 위 코드 작성 후 아래 코드 실행을 서버가 실행될 때 연결
``` c#
ConnectToDatabase();
```

### orm 설치 (OracleConnection과는 다른 것)
- `Dapper와 EF 장단점 비교`
    - Dapper의 장점과 단점, EF의 장점과 단점
```
--- 장점 (Dapper)
1. 속도 : Dapper는 성능이 뛰어나며, EF보다 빠르다. Dapper는 SQL 쿼리를 직접 실행하고 결과를 객체로 매핑하는 방식으로 ORM의 오버헤드가 적다
2. 단순성 : Dapper는 비교적 사용이 간단하고, 쿼리 기반으로 작업을 하므로 직관적이다. 복잡한 모델 매핑이나 추상화가 필요 없고, SQL을 직접 작성하는 것이므로 더 많은 제어권을 가진다.
3. 직접적인 쿼리 사용 : SQL을 직접 사용할 수 있기 때문에 복잡한 쿼리나 성능 최적화가 필요할 때 유리하다.
4. 가벼움 : Dapper는 작은 라이브러리로, EF보다 의존성이나 설정이 적어 더 가볍고 빠르게 동작한다.

--- 단점 (Dapper)
1. 추상화 부족 : Dapper는 ORM이지만, EF처럼 강력한 추상화 계층을 제공하지 않는다. DB 작업에 대해 더 많은 코드를 작성해야 할 수 있다.
2. 쿼리 작성 필요 : Dapper는 SQL을 직접 작성해야 하므로, 복잡한 데이터 구조나 관계를 처리하는데 더 많은 노력이 필요할 수 있다.
3. 보일러플레이트 코드 : 복잡한 엔티티나 관계를 다룰 때는 Dapper로 많은 보일러플레이트 코드가 필요할 수 있다.

--- 장점 (Entity Framework)
1. 강력한 추상화 : EF는 데이터베이스와의 상호작용을 추상화하여, 개발자가 SQL을 직접 작성할 필요 없이 LINQ나 메서드를 통해 데이터를 조작할 수 있다.
2. 자동 매핑 : EF는 모델 클래스와 DB 테이블 간에 자동으로 매핑을 수행해주므로, 코드가 간결하고 관리하기 쉽다.
3. 추상화된 데이터 모델 : EF는 RDBMS의 개념을 객체 모델로 추상화하여, 복잡한 쿼리나 관계를 쉽게 다룰 수 있게 해준다.
4. 추가 기능 : EF는 마이그레이션, Lazy Loading, Chagne Tracking, 캐싱 등 많은 고급 기능을 제공한다. 특히, 큰 프로젝트나 복잡한 데이터 모델에 유리하다.
5. 다양한 DB 지원 : EF는 다양한 DB 엔진을 지원하며, 코드만으로 다른 데이터베이스로 쉽게 전환할 수 있다.

--- 단점 (Entity Framework)
1. 성능 문제 : Dapper에 비해 상대적으로 성능이 떨어진다. EF의 자동 매핑, 복잡한 추상화 계층 등으로 인한 오버헤드 때문
2. 복잡한 설정과 초기화 : EF는 설정이 복잡할 수 있으며, EF Core를 사용할 때도 DB에 대한 설정이 필요하고, 모델을 정의하는 데 시간이 걸릴 수 있다.
3. 직접적인 쿼리 사용 불가 : SQL 쿼리를 직접 작성하는 대신, LINQ를 사용하여 데이터를 처리하는 방식이다. 복잡한 쿼리에선 LINQ보다 직접적인 SQL이 더 적합할 수 있다.
4. 학습 곡선 : EF는 Dapper보다 더 많은 개념과 구성이 필요하므로, 학습 곡선이 더 가파를 수 있다.
```

- 전문적인 C# 개발자가 뭘 많이 쓰는지에 대한 답변으로 EF가 많다고 하여 EF 선택

- jpa와 유사한 것 Entity Framework(EF)
    - db table과 C# 클래스 간의 매핑을 자동으로 처리

- Entity Framework 설치
``` bash
$ Install-Package Microsoft.EntityFrameworkCore -> 모르겠음
$ Install-Package Microsoft.EntityFrameworkCore.Sqlite -> SqlLite 작동 위함
$ Install-Package Oracle.EntityFrameworkCore -> Oracle 작동 위함
```

- Dapper 설치
``` bash
$ Install-Package Dapper
```

- DbContext 생성
    1. Config > ODBC.cs 파일에 있는 방식 사용
    2. Query > LoginQuery.cs 보면 사용방법 확인 가능

- 현재 전체적인 사용법 TODO 수정중
```
Query 안에 LoginQuery를 만들고
query를 다 실행 시키고 나면,
마지막에 loginQuery.Commit()을 통해 트랜잭션을 완료

그리고 추가로 Null을 처리 해야함 Null이 들어갈 경우 나오는 에러가 발생하는데, 이거는 일단 계속 보면서 살펴보기
```

### code snippet 설정
- 도구 > _코드 조각 관리자_ > 추가 > .snippet 파일 생성
    - 파일 예시
``` xml
<?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
        <Header>
            <Title></Title>
        </Header>
        <Snippet>
            <Code Language="">
                <![CDATA[]]>
            </Code>
        </Snippet>
    </CodeSnippet>
</CodeSnippets>
```

#### 어려운 Dapper와 EF의 개념
- DbConnection이 폐기 되면

DbConnection 객체는 IDisposable 인터페이스를 구현하므로, Dispose 메서드를 호출하여 명시적으로 자원을 해제할 수 있습니다. DbConnection 객체가 폐기되면, 연결된 데이터베이스 리소스가 해제되고, 연결 풀로 반환됩니다.
DbContext는 DbConnection 객체를 내부적으로 관리하며, DbContext가 폐기될 때 DbConnection 객체도 함께 폐기됩니다. 따라서, DbContext를 사용하는 동안 DbConnection 객체는 DbContext의 수명 주기에 따라 관리됩니다.

예를 들어, using 문을 사용하여 DbContext를 생성하고 사용하면, DbContext가 범위를 벗어날 때 자동으로 Dispose 메서드가 호출되어 DbConnection 객체도 함께 폐기됩니다.

``` c#
using (var context = ODBC.GetInstance())
{
    var connection = context.Database.GetDbConnection();
    connection.Open();

    // SQL 쿼리 실행
    var result = connection.Query("SELECT * FROM SomeTable");

    // 연결을 명시적으로 닫을 필요는 없음
    // using 블록이 끝나면 DbContext와 함께 DbConnection도 폐기됨
}
```

IDbContextTransaction은 DbContext와 연결된 트랜잭션을 관리합니다. 트랜잭션이 시작되면, 트랜잭션 내에서 실행된 모든 작업은 트랜잭션의 일관성을 유지합니다. DbConnection이 닫히더라도 트랜잭션은 여전히 유효하며, 트랜잭션 내에서 실행된 모든 작업은 롤백될 수 있습니다.
#### 


# 개발하면서 새롭게 깨달은 사실들 일지

1. 반복문을 돌리는 리스트에서 요소 삭제
```
만약 리스트에서 반복문을 돌릴 때, 해당 리스트의 요소를 삭제하고 싶다면
반복문을 역순으로 돌려야 한다.
이유는 Enumerator가 처음부터 끝까지 돌아가면서 삭제를 하면
삭제된 요소의 인덱스가 변경되기 때문이다.
```

2. UI 스레드 예외 처리기와 비 UI 스레드 예외 처리기
```
UI 스레드와 비 UI 스레드의 개념은 멀티스레딩 프로그래밍에서 매우 중요합니다. 특히 Windows Forms 애플리케이션과 같은 GUI 애플리케이션에서는 UI 스레드와 비 UI 스레드를 구분하여 작업을 처리하는 것이 중요합니다.
UI 스레드
UI 스레드는 사용자 인터페이스(UI)를 관리하는 스레드입니다. 이 스레드는 사용자 입력(마우스 클릭, 키보드 입력 등)을 처리하고, 화면에 UI 요소를 그리며, 이벤트를 처리합니다. Windows Forms 애플리케이션에서는 기본적으로 하나의 UI 스레드가 있으며, 이 스레드에서 모든 UI 관련 작업이 수행됩니다.
특징
•	UI 스레드는 단일 스레드로 동작합니다.
•	UI 스레드에서 긴 작업을 수행하면 UI가 응답하지 않게 됩니다(프리징).
•	UI 스레드에서 발생하는 예외는 Application.ThreadException 이벤트를 통해 처리할 수 있습니다.

private void Button_Click(object sender, EventArgs e)
{
    // 이 코드는 UI 스레드에서 실행됩니다.
    this.label1.Text = "Button clicked!";
}

```

```
비 UI 스레드는 UI 스레드 외부에서 실행되는 스레드입니다. 비 UI 스레드는 주로 긴 작업이나 백그라운드 작업을 수행하는 데 사용됩니다. 비 UI 스레드를 사용하면 UI 스레드가 긴 작업으로 인해 응답하지 않게 되는 문제를 피할 수 있습니다.
특징
•	비 UI 스레드는 여러 개 생성할 수 있습니다.
•	비 UI 스레드에서 UI 요소에 직접 접근하면 예외가 발생할 수 있습니다. UI 요소에 접근하려면 Invoke 또는 BeginInvoke 메서드를 사용해야 합니다.
•	비 UI 스레드에서 발생하는 예외는 AppDomain.CurrentDomain.UnhandledException 이벤트를 통해 처리할 수 있습니다.

private void StartBackgroundWork()
{
    Task.Run(() =>
    {
        // 이 코드는 비 UI 스레드에서 실행됩니다.
        // 긴 작업을 수행합니다.
        Thread.Sleep(5000);

        // UI 요소에 접근하려면 Invoke를 사용해야 합니다.
        this.Invoke((MethodInvoker)delegate
        {
            this.label1.Text = "Background work completed!";
        });
    });
}
```

```
이 코드는 Windows Forms 애플리케이션에서 전역 예외 처리기를 설정하는 부분입니다. 전역 예외 처리기를 설정하면 애플리케이션에서 발생하는 모든 예외를 잡아 처리할 수 있습니다. 이 코드는 UI 스레드와 비 UI 스레드에서 발생하는 예외를 각각 처리합니다.
코드 설명
1.	Application.EnableVisualStyles();
•	이 메서드는 애플리케이션의 시각적 스타일을 활성화합니다. 이를 통해 Windows XP 이상에서 제공하는 시각적 스타일을 사용할 수 있습니다.
2.	Application.SetCompatibleTextRenderingDefault(false);
•	이 메서드는 애플리케이션에서 텍스트 렌더링을 GDI+ 대신 GDI를 사용하도록 설정합니다. 일반적으로 false로 설정하여 최신 텍스트 렌더링 방식을 사용합니다.
3.	Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
•	이 코드는 UI 스레드에서 발생하는 예외를 처리하기 위해 Application.ThreadException 이벤트에 Application_ThreadException 메서드를 등록합니다.
•	Application.ThreadException 이벤트는 Windows Forms 애플리케이션에서 UI 스레드에서 발생하는 예외를 처리할 수 있도록 합니다.
4.	AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
•	이 코드는 비 UI 스레드에서 발생하는 예외를 처리하기 위해 AppDomain.CurrentDomain.UnhandledException 이벤트에 CurrentDomain_UnhandledException 메서드를 등록합니다.
•	AppDomain.CurrentDomain.UnhandledException 이벤트는 애플리케이션 도메인에서 처리되지 않은 예외를 잡아 처리할 수 있도록 합니다.
```

# Visual Studio 2022 단축키 모음
- `Ctrl + K, Ctrl + D` : 코드 정렬
- `Ctrl + K, Ctrl + C` : 주석 처리
- `Ctrl + R, Ctrl + G` : import 정리