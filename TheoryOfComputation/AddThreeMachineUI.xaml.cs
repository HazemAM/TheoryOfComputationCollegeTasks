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

		public void highlightArrow(int from, int to)
		{
			dehighlightAllArrows();

			Arrow goalNormal = null;
			ArcArrow goalArc = null;
			
			if(from == 0 && to == 0) goalArc = arrow00;
			else if(from == 0 && to == 1) goalNormal = arrow01;
			else if(from == 1 && to == 2) goalNormal = arrow12;
			else if(from == 1 && to == 3) goalNormal = arrow13;
			else if(from == 2 && to == 4) goalNormal = arrow24;
			else if(from == 2 && to == 5) goalNormal = arrow25;
			else if(from == 3 && to == 4) goalNormal = arrow34;
			else if(from == 4 && to == 4) goalArc = arrow44;
			else if(from == 4 && to == 5) goalNormal = arrow45;
			else if(from == 5 && to == 5) goalArc = arrow55;
			else if(from == 5 && to == 6) goalNormal = arrow56;

			if(goalNormal != null)
				goalNormal.highlight();
			else if(goalArc != null)
				goalArc.highlight();
		}

		private void dehighlightAllArrows()
		{
			arrow00.dehighlight();
			arrow01.dehighlight();
			arrow12.dehighlight();
			arrow13.dehighlight();
			arrow24.dehighlight();
			arrow25.dehighlight();
			arrow34.dehighlight();
			arrow44.dehighlight();
			arrow45.dehighlight();
			arrow55.dehighlight();
			arrow56.dehighlight();
		}

		public void highlightFunction(int state, char input)
		{
			dehighlightAllFunctions();

			TransitionLabel goal = null;
			char empty = AddThreeMachine.EMPTY;
			
			if(state == 0 && input == '0') goal = func00;
			else if(state == 0 && input == '1') goal = func01;
			else if(state == 0 && input == empty) goal = func0E;
			else if(state == 1 && input == '0') goal = func10;
			else if(state == 1 && input == '1') goal = func11;
			else if(state == 2 && input == '0') goal = func20;
			else if(state == 2 && input == '1') goal = func21;
			else if(state == 2 && input == empty) goal = func2E;
			else if(state == 3 && input == '0') goal = func30;
			else if(state == 3 && input == '1') goal = func31;
			else if(state == 3 && input == empty) goal = func3E;
			else if(state == 4 && input == '0') goal = func40;
			else if(state == 4 && input == '1') goal = func41;
			else if(state == 4 && input == empty) goal = func4E;
			else if(state == 5 && input == '0') goal = func50;
			else if(state == 5 && input == '1') goal = func51;
			else if(state == 5 && input == empty) goal = func5E;

			if(goal != null)
				goal.highlight();
		}

		private void dehighlightAllFunctions()
		{
			func00.dehighlight();
			func01.dehighlight();
			func0E.dehighlight();
			func10.dehighlight();
			func11.dehighlight();
			func20.dehighlight();
			func21.dehighlight();
			func2E.dehighlight();
			func30.dehighlight();
			func31.dehighlight();
			func3E.dehighlight();
			func40.dehighlight();
			func41.dehighlight();
			func4E.dehighlight();
			func50.dehighlight();
			func51.dehighlight();
			func5E.dehighlight();
		}

		public void reset()
		{
			dehighlightAllStates();
			dehighlightAllArrows();
			dehighlightAllFunctions();
		}
	}
}
