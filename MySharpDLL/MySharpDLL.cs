using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace MySharpDLL {
  public class FlutterDesktopEngine : SafeHandle {
    public FlutterDesktopEngine() : base(IntPtr.Zero, true) {
    }

    public override bool IsInvalid => handle == IntPtr.Zero;

    public static implicit operator bool(FlutterDesktopEngine engine) {
      return !engine.IsInvalid;
    }

    protected override bool ReleaseHandle() {
      SetHandle(IntPtr.Zero);
      return true;
    }
  }
  public static class NativeLibrary {
    [DllImport("libsharedlibrary.so")]
    public static extern int tizensharedlibrary();

    [StructLayout(LayoutKind.Sequential)]
    public struct FlutterDesktopWindowProperties {
      [MarshalAs(UnmanagedType.U1)]
      public bool headed;
      public int x;
      public int y;
      public int width;
      public int height;
      [MarshalAs(UnmanagedType.U1)]
      public bool transparent;
      [MarshalAs(UnmanagedType.U1)]
      public bool focusable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FlutterDesktopEngineProperties {
      public string assets_path;
      public string icu_data_path;
      public string aot_library_path;
      public IntPtr switches;
      public uint switches_count;
      public string entrypoint;
      public int dart_entrypoint_argc;
      public IntPtr dart_entrypoint_argv;
    }

    [DllImport("flutter_tizen.so")]
    public static extern FlutterDesktopEngine FlutterDesktopRunEngine2(
        ref FlutterDesktopWindowProperties window_properties,
        ref FlutterDesktopEngineProperties engine_properties);

  }

  public static class MySharpDLL {
    public static int getVal() {
     // NativeLibrary.FlutterDesktopWindowProperties Winprop = new NativeLibrary.FlutterDesktopWindowProperties();
      //NativeLibrary.FlutterDesktopEngineProperties engProp = new NativeLibrary.FlutterDesktopEngineProperties();
      //NativeLibrary.FlutterDesktopRunEngine2(ref Winprop, ref engProp);
      return 8;
    }
  }
}
