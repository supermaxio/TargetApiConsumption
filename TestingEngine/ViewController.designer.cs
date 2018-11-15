// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TestingEngine
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField Output2Text { get; set; }

        [Outlet]
        AppKit.NSTextField OutputText { get; set; }

        [Action ("RunTest2Button:")]
        partial void RunTest2Button (Foundation.NSObject sender);

        [Action ("RunTestButton:")]
        partial void RunTestButton (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (OutputText != null) {
                OutputText.Dispose ();
                OutputText = null;
            }

            if (Output2Text != null) {
                Output2Text.Dispose ();
                Output2Text = null;
            }
        }
    }
}
