using System;
using System.Collections.Generic;
using System.Text;

namespace TheoryOfComputation
{
	class AddThreeMachine
	{
		public const char EMPTY = '\0';
		public const int FINAL_STATE = 6;

		private Dictionary<Tuple<int,char>, Tuple<int,char,Direction>> transitions;
		private string tape;
		private int currentState;

		public AddThreeMachine(string input)
		{
			initializeTransitions();
			this.tape = input;
			this.currentState = 0;
		}

		private Tuple<int,char,Direction> nextTransition(char input)
		{
			Tuple<int,char,Direction> result;
			bool exist = transitions.TryGetValue(newKey(currentState, input), out result);
			
			if(exist){
				currentState = result.Item1;
				return result;
			}
			else return null;
		}

		private void initializeTransitions()
		{
			/*
			 * TRANSITIONS
			 */
			transitions = new Dictionary<Tuple<int,char>, Tuple<int,char,Direction>>();

			transitions.Add(newKey(0, '0'), newValue(0, '0', Direction.RIGHT));
			transitions.Add(newKey(0, '1'), newValue(0, '1', Direction.RIGHT));
			transitions.Add(newKey(0, EMPTY), newValue(1, EMPTY, Direction.LEFT));

			transitions.Add(newKey(1, '0'), newValue(2, '1', Direction.LEFT));
			transitions.Add(newKey(1, '1'), newValue(3, '0', Direction.LEFT));

			transitions.Add(newKey(2, '0'), newValue(5, '1', Direction.LEFT));
			transitions.Add(newKey(2, EMPTY), newValue(5, '1', Direction.LEFT));
			transitions.Add(newKey(2, '1'), newValue(4, '0', Direction.LEFT));

			transitions.Add(newKey(3, '1'), newValue(4, '1', Direction.LEFT));
			transitions.Add(newKey(3, '0'), newValue(4, '0', Direction.LEFT));
			transitions.Add(newKey(3, EMPTY), newValue(4, '0', Direction.LEFT));

			transitions.Add(newKey(4, '1'), newValue(4, '0', Direction.LEFT));
			transitions.Add(newKey(4, '0'), newValue(5, '1', Direction.LEFT));
			transitions.Add(newKey(4, EMPTY), newValue(5, '1', Direction.LEFT));

			transitions.Add(newKey(5, '1'), newValue(5, '1', Direction.LEFT));
			transitions.Add(newKey(5, '0'), newValue(5, '0', Direction.LEFT));
			transitions.Add(newKey(5, EMPTY), newValue(6, EMPTY, Direction.RIGHT));
		}

		public static Tuple<int,char,Direction> newValue(int newState, char newTapeChar, Direction headDirection)
		{
			return new Tuple<int,char,Direction>(newState, newTapeChar, headDirection);
		}

		public static Tuple<int,char> newKey(int state, char tapeChar)
		{
			return new Tuple<int,char>(state, tapeChar);
		}
	}

	public enum Direction
	{
		RIGHT, LEFT, SUSPEND
	}
}

