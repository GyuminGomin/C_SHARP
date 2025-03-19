namespace WindowsFormCSharp;
using WindowsFormCSharp._LoginForms;
using WindowsFormCSharp.Config;
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

        ApplicationConfiguration.Initialize();
        //Application.Run(new _LoginForms.LoginForm()); // 로그인 절차 생략
        Application.Run(new _PCMStartForms.PCMStartForm());
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
}