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

        // ���� ���� ó���� ����
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        ApplicationConfiguration.Initialize();
        //Application.Run(new _LoginForms.LoginForm()); // �α��� ���� ����
        Application.Run(new _PCMStartForms.PCMStartForm());
    }

    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    static extern bool AllocConsole();

    // UI ������ ���� ó����
    static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"UI ������ ���� �߻� : {currentTime} \n");
        Console.WriteLine(e.Exception.ToString());
    }

    // �� UI ������ ���� ó����
    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Exception ex = (Exception)e.ExceptionObject;
        Console.WriteLine($"�� UI ������ ���� �߻� : {currentTime} \n");
        Console.WriteLine(ex.ToString());
    }
}