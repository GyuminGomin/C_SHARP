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