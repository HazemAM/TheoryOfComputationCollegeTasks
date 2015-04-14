using System;
using System.Windows.Controls;

namespace TheoryOfComputation
{
	/// <summary>
	/// Interaction logic for AddThreeMachineUI.xaml
	/// </summary>
	public partial class AddThreeMachineUI : UserControl
	{
		const int TOTAL_STATES = 6; //0-based.

		public AddThreeMachineUI()
		{
			InitializeComponent();
		}

		public void highlightState(int index)
		{
			dehighlightAllStates();

			State goal = null;
			switch (index){
				case 0: goal = state0; break;
				case 1: goal = state1; break;
				case 2: goal = state2; break;
				case 3: goal = state3; break;
				case 4: goal = state4; break;
				case 5: goal = state5; break;
				case 6: goal = state6; break;
			}

			if(goal != null)
				goal.highlight();
		}

		private void dehighlightAllStates()
		{
			state0.dehighlight();
			state1.dehighlight();
			state2.dehighlight();
			state3.dehighlight();
			state4.dehighlight();
			state5.dehighlight();
			state6.dehighlight();
		}
	}
}
