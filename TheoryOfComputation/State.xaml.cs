using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for State.xaml
	/// </summary>
	public partial class State : UserControl
	{
		public int Index {
			get { return Index; }
			set { label.Text = value.ToString(); }
		}

		public bool IsFinal {
			get { return IsFinal; }
			set {
				if(value) finalIndicator.Visibility = Visibility.Visible;
			}
		}

		public State()
		{
			InitializeComponent();
		}

		public void highlight()
		{
			SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("circleBrush");
			circleBrush.Color = Color.FromRgb(0,140,255);

			SolidColorBrush labelBrush = (SolidColorBrush)this.FindResource("labelBrush");
			labelBrush.Color = Color.FromRgb(255,255,255);
		}

		public void dehighlight()
		{
			SolidColorBrush circleBrush = (SolidColorBrush)this.FindResource("circleBrush");
			circleBrush.Color = Color.FromArgb(0,0,0,0);

			SolidColorBrush labelBrush = (SolidColorBrush)this.FindResource("labelBrush");
			labelBrush.Color = Color.FromRgb(0,0,0);
		}
	}
}
