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

    /// <summary>
    /// View controller.
    /// </summary>
    public partial class ViewController : NSViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TargetApiConsumption.ViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        /// <summary>
        /// Gets or sets the represented object.
        /// </summary>
        /// <value>The represented object.</value>
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

        /// <summary>
        /// Submits the button.
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void SubmitButton(NSObject sender)
        {
            try
            {
                // Get and set variables from form
                var busDirectionValue = BusDirectionComboBox.StringValue;
                var busStopValue = BusStopNameTextBox.StringValue;
                var busRouteValue = BusRouteTextBox.StringValue;

                // Run business logic
                var nextBus = new NextBus();
                var timeInMinutes = nextBus.GetTimeInMinutesForNextBus(busRouteValue, busStopValue, busDirectionValue);
                var stringToDisplay = timeInMinutes.ToString() + " minutes";

                // Output
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
