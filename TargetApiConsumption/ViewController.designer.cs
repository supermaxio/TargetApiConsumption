// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TargetApiConsumption
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSComboBox BusDirectionComboBox { get; set; }

		[Outlet]
		AppKit.NSTextField BusRouteTextBox { get; set; }

		[Outlet]
		AppKit.NSTextField BusStopNameTextBox { get; set; }

		[Outlet]
		AppKit.NSTextField OutputTimeLabel { get; set; }

		[Action ("SubmitButton:")]
		partial void SubmitButton (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BusRouteTextBox != null) {
				BusRouteTextBox.Dispose ();
				BusRouteTextBox = null;
			}

			if (BusStopNameTextBox != null) {
				BusStopNameTextBox.Dispose ();
				BusStopNameTextBox = null;
			}

			if (OutputTimeLabel != null) {
				OutputTimeLabel.Dispose ();
				OutputTimeLabel = null;
			}

			if (BusDirectionComboBox != null) {
				BusDirectionComboBox.Dispose ();
				BusDirectionComboBox = null;
			}
		}
	}
}
