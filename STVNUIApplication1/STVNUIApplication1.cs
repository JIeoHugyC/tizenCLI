using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications;
using System.Runtime.InteropServices;

namespace STVNUIApplication1 {
  class Program : NUIApplication {
    protected override void OnCreate() {
      base.OnCreate();
      Initialize();
    }

    void Initialize() {
      unsafe {
        int k = 4;
        int* val = &k;
        TextLabel text = new TextLabel("Hello Tizen NUI World ");
        text = new TextLabel(MySharpDLL.MySharpDLL.getVal().ToString());
        cli2.Class1 myCLI = new cli2.Class1();
        myCLI.getVal();
        //text = new TextLabel(SharpLibrary.getVal().ToString());
        //text = new TextLabel(NativeLibrary.tizensharedlibrary().ToString());
        int z = *val;
        //text = new TextLabel(z.ToString() + " my Value = " + z.ToString());
        Window.Instance.KeyEvent += OnKeyEvent;
        text.HorizontalAlignment = HorizontalAlignment.Center;
        text.VerticalAlignment = VerticalAlignment.Center;
        text.TextColor = Color.Blue;
        text.PointSize = 300.0f;
        text.HeightResizePolicy = ResizePolicyType.FillToParent;
        text.WidthResizePolicy = ResizePolicyType.FillToParent;
        Window.Instance.GetDefaultLayer().Add(text);

        Animation animation = new Animation(2000);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
        animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
        animation.Looping = true;
        animation.Play();
      }
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e) {
      if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape")) {
        Exit();
      }
    }

    static void Main(string[] args) {
      var app = new Program();
      app.Run(args);
    }
  }
}
