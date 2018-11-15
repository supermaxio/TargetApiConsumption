using System;
using System.IO;
using AppKit;
using Foundation;

namespace TargetApiConsumption
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void SubmitButton(NSObject sender)
        {
            Console.WriteLine("Hello");
            OutputTimeLabel.StringValue = "500 minutes";
        }
    }
}
