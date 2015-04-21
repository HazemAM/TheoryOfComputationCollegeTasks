using System;
using System.Windows;
using System.Windows.Controls;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for BorderText.xaml
	/// </summary>
	public partial class BorderText : UserControl
	{
		public string Text
		{
			get { return Text; }
			set { txt.Text = value; }
		}

		public bool Last
		{
			get { return Last; }
			set { border.BorderThickness = value
				? new Thickness(0,2,0,2)
				: new Thickness(0,2,2,2); }
		}

		public BorderText()
		{
			InitializeComponent();
		}
	}
}
