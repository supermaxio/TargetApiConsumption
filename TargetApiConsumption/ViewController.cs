/***************************************************************************/
// <copyright file="ViewController.cs" company="My company">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>M. Meier</author>
/***************************************************************************/

namespace TargetApiConsumption
{
    using System;
    using System.IO;
    using AppKit;
    using Foundation;

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
            try
            {
                var busDirectionValue = BusDirectionComboBox.StringValue;
                var busStopValue = BusStopNameTextBox.StringValue;
                var busRouteValue = BusRouteTextBox.StringValue;

                var nextBus = new NextBus();
                var timeInMinutes = nextBus.GetTimeInMinutesForNextBus(busRouteValue, busStopValue, busDirectionValue);
                var stringToDisplay = timeInMinutes.ToString() + " minutes";

                Console.WriteLine(stringToDisplay);
                OutputTimeLabel.StringValue = stringToDisplay;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                OutputTimeLabel.StringValue = "Error";

                var alert = new NSAlert
                {
                    MessageText = "Error",
                    InformativeText = ex.Message
                };

                alert.RunModal();
            }
        }
    }
}
