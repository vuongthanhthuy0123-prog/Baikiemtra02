namespace Bai3_MdiSieuThi
{
    internal static class Program
    {
        /// <summary>
        ///  Điểm khởi chạy chương trình.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}
