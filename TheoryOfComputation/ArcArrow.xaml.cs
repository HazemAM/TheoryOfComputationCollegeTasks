using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
			(this.Resources["animationOn"] as Storyboard).Begin();
			//SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("arrowBrush");
			//circleBrush.Color = Color.FromRgb(255,0,0);
		}

		public void dehighlight()
		{
			(this.Resources["animationOff"] as Storyboard).Begin();
			//SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("arrowBrush");
			//circleBrush.Color = Color.FromRgb(0,0,0);
		}
	}
}
