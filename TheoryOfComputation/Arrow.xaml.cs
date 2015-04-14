using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for Arrow.xaml
	/// </summary>
	public partial class Arrow : UserControl
	{
		public int Length
		{
			get { return Length; }
			set {
				line.X2 = value;
				head.Margin = new Thickness(value-5, 0, -(value-5), 0);
			}
		}

		public Arrow()
		{
			InitializeComponent();
		}

		public void highlight()
		{
			SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("arrowBrush");
			circleBrush.Color = Color.FromRgb(255,0,0);
		}

		public void dehighlight()
		{
			SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("arrowBrush");
			circleBrush.Color = Color.FromRgb(0,0,0);
		}
	}
}
