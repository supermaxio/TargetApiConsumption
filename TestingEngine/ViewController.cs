using System;

using AppKit;
using Foundation;
using CoreBusiness;

namespace TestingEngine
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

        partial void RunTestButton(NSObject sender)
        {
            try
            {
                var nextBus = new NextBusOperation();
                var timeInMinutes = nextBus.GetTimeInMinutesForNextBus("METRO Blue Line", "Target Field Station Platform 1", "south");

                // Output
                var stringToDisplay = "Test succeeds with output: " + timeInMinutes;

                Console.WriteLine(stringToDisplay);
                OutputText.StringValue = stringToDisplay;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                OutputText.StringValue = "Error";

                var alert = new NSAlert
                {
                    MessageText = "Error",
                    InformativeText = "Test failed. " + ex.Message
                };

                alert.RunModal();
            }
        }

        partial void RunTest2Button(NSObject sender)
        {
            try
            {
                var nextBus = new NextBusOperation();
                var timeInMinutes = nextBus.GetTimeInMinutesForNextBus("Express - Target - Hwy 252 and 73rd Av P&R - Mpls", "Target North Campus Building F", "south");

                // Output
                var stringToDisplay = "Test succeeds with output: " + timeInMinutes;

                Console.WriteLine(stringToDisplay);
                Output2Text.StringValue = stringToDisplay;
            }
            catch (ApplicationException ex)
            {
                if (ex.Message.Contains("There are no scheduled stops here"))
                {
                    var stringToDisplay = "Test succeeds: no scheduled stops";

                    Console.WriteLine(stringToDisplay);
                    Output2Text.StringValue = stringToDisplay;
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    Output2Text.StringValue = "Error";

                    var alert = new NSAlert
                    {
                        MessageText = "Error",
                        InformativeText = "Test failed. " + ex.Message
                    };

                    alert.RunModal();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Output2Text.StringValue = "Error";

                var alert = new NSAlert
                {
                    MessageText = "Error",
                    InformativeText = "Test failed. " + ex.Message
                };

                alert.RunModal();
            }
        }
    }
}
