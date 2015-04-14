using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for Arrow.xaml
	/// </summary>
	public partial class ArcArrow : UserControl
	{
		public ArcArrow()
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
