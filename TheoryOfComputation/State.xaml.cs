using System;
using System.Windows.Controls;
using System.Windows;

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
	}
}
