using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for TransitionLabel.xaml
	/// </summary>
	public partial class TransitionLabel : UserControl
	{
		public string Text
		{
			get { return Text; }
			set { label.Text = value; }
		}

		public TransitionLabel()
		{
			InitializeComponent();
		}

		public void highlight()
		{
			label.Foreground = new SolidColorBrush(Color.FromRgb(255,0,0));
		}

		public void dehighlight()
		{
			label.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
		}
	}
}
