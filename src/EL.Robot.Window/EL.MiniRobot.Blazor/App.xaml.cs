using Microsoft.UI;
using Windows.Graphics;

namespace EL.MiniRobot.Blazor
{
    public partial class App : Application
    {
        const int WindowWidth = 950;
        const int WindowHeight = 600;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //设置窗口的大小
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
#if (WINDOWS)
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
#endif

            });
        }
    }
}