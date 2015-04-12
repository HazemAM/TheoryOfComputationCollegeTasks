using System;
using System.Collections.Generic;
using System.Windows;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for MainWindow.
	/// </summary>
	public partial class MainWindow : Window
	{
		const char EMPTY = '\0';

		public MainWindow()
		{
			InitializeComponent();
			AddThreeMachine machine = new AddThreeMachine("101");

			Tuple<int,char,Direction> output;
			do{
				output = machine.step();
			} while(output != null && output.Item1 != AddThreeMachine.FINAL_STATE);
		}
	}
}
