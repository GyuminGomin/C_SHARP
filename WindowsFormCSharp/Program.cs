namespace WindowsFormCSharp;
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Open Console
        AllocConsole();

        // 전역 예외 처리기 설정
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        // 콘솔 입력을 처리하는 스레드 시작
        Task.Run(() => ProcessConsoleInput());

        ApplicationConfiguration.Initialize();
        Application.Run(new _LoginForms.LoginForm()); // 로그인 절차 생략
        //Application.Run(new _PCMStartForms.PCMStartForm(null, null));
    }

    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern bool AllocConsole();

    // UI 스레드 예외 처리기
    static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"UI 스레드 예외 발생 : {currentTime} \n");
        Console.WriteLine(e.Exception.ToString());
    }

    // 비 UI 스레드 예외 처리기
    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Exception ex = (Exception)e.ExceptionObject;
        Console.WriteLine($"비 UI 스레드 예외 발생 : {currentTime} \n");
        Console.WriteLine(ex.ToString());
    }

    // 콘솔 입력을 처리하는 메서드
    static void ProcessConsoleInput()
    {
        while (true)
        {
            Console.Write("Enter Command : ");
            string input = Console.ReadLine();
            if (input != null && !input.Equals(""))
            {
                if (input.Equals("cls", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                }
                else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(
                    $"""
                    ***************************************
                           Unknown Command -> {input}
                    MANUAL
                    clear  ->   cls
                    exit   ->   exit
                    ***************************************
                    """
                    );
                }
            }
        }
    }
}