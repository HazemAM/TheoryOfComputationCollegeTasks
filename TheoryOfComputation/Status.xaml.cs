using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for Status.
	/// </summary>
	public partial class Status : UserControl
	{
		public static Color RED = Color.FromRgb(255,0,0),
							GREEN = Color.FromRgb(0,204,0),
							YELLOW = Color.FromRgb(255,204,0);

		public bool Visible{
			set{
				if(value == true) show();
				else hide();
			}
		}

		public Status()
		{
			InitializeComponent();
		}

		public void updateStatus(string text, Color color)
		{
			label.Text = text;
			label.Foreground = new SolidColorBrush(color);
			circle.Fill = new SolidColorBrush(color);
		}

		public void show()
		{
			container.Visibility = System.Windows.Visibility.Visible;
		}

		public void hide()
		{
			container.Visibility = System.Windows.Visibility.Hidden;
		}
	}
}
