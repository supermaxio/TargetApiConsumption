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
        AppKit.NSTextField OutputText { get; set; }

        [Action ("RunTestButton:")]
        partial void RunTestButton (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (OutputText != null) {
                OutputText.Dispose ();
                OutputText = null;
            }
        }
    }
}
