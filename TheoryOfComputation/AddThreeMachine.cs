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
		private char currChar;
		private int currPos;
		private int currentState;

		public AddThreeMachine(string input)
		{
			initializeTransitions();
			this.tape = input;
			this.currChar = this.tape[0];
			this.currPos = 0;
			this.currentState = 0;
		}

		public Tuple<int,char,Direction,char> step(out MachineStatus machineStatus)
		{
			if(currentState == FINAL_STATE){
				machineStatus = MachineStatus.HALT;
				return null;
			}

			char inputChar = this.currChar;
			Tuple<int,char,Direction> output;
			output = nextTransition(this.currChar);

			if(output == null){
				machineStatus = MachineStatus.HANG;
				return null;
			}

			write(output.Item2);
			if(output.Item3 == Direction.RIGHT)
				moveRight();
			else moveLeft();

			machineStatus = MachineStatus.CONTINUE;
			return new Tuple<int,char,Direction,char>
				(output.Item1, output.Item2, output.Item3, inputChar);
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

		private void moveRight()
		{
			this.currPos++;
			if(currPos >= this.tape.Length)
				this.currChar = EMPTY;
			else
				this.currChar = this.tape[currPos];
		}

		private void moveLeft()
		{
			this.currPos--;
			if(currPos < 0)
				this.currChar = EMPTY;
			else
				this.currChar = this.tape[currPos];
		}

		private void write(char ch)
		{
			if(currPos == this.tape.Length)
				this.tape += ch;
			else if(currPos == -1){
				this.tape = ch + this.tape;
				this.currPos = 0;
			}
			else{
				StringBuilder sb = new StringBuilder(this.tape);
				sb[currPos] = ch;
				this.tape = sb.ToString();
			}
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

	public enum MachineStatus
	{
		HALT, HANG, CONTINUE
	}
}
