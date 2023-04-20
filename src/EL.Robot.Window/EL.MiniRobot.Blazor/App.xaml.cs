#if (WINDOWS)
using Microsoft.UI;
using Microsoft.VisualBasic;
using Windows.Graphics;
using Colors= Microsoft.UI.Colors;
using Microsoft.UI.Windowing;
#endif

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
				var titleBar = appWindow.TitleBar;
            
                //titleBar.ExtendsContentIntoTitleBar = true;
    //               titleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;
                  //titleBar.PreferredHeightOption  = TitleBarHeightOption.Tall;
				 //titleBar.ForegroundColor =  Colors.White;
     //           titleBar.BackgroundColor = Colors.Green;
     //           titleBar.ButtonForegroundColor = Colors.White;
     //           titleBar.ButtonBackgroundColor = Colors.SeaGreen;
     //           titleBar.ButtonHoverForegroundColor = Colors.Gainsboro;
     //           titleBar.ButtonHoverBackgroundColor = Colors.DarkSeaGreen;
     //           titleBar.ButtonPressedForegroundColor = Colors.Gray;
     //           titleBar.ButtonPressedBackgroundColor = Colors.LightGreen;

                // Set inactive window colors
                // Note: No effect when app is running on Windows 10 since color customization is not
                // supported.
                //titleBar.InactiveForegroundColor = Colors.Gainsboro;
                //titleBar.InactiveBackgroundColor = Colors.SeaGreen;
                //titleBar.ButtonInactiveForegroundColor = Colors.Gainsboro;
                //titleBar.ButtonInactiveBackgroundColor = Colors.SeaGreen;
#endif

            });
		}
	}
}