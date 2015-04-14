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
			SolidColorBrush circleBrush = new SolidColorBrush(Color.FromRgb(0,140,255));
			this.Resources["circleBrush"] = circleBrush;

			SolidColorBrush labelBrush = new SolidColorBrush(Color.FromRgb(255,255,255));
			this.Resources["labelBrush"] = labelBrush;
		}

		public void dehighlight()
		{
			SolidColorBrush circleBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));
			this.Resources["circleBrush"] = circleBrush;

			SolidColorBrush labelBrush = new SolidColorBrush(Color.FromRgb(0,0,0));
			this.Resources["labelBrush"] = labelBrush;
		}
	}
}
