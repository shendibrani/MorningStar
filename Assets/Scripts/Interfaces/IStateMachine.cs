using System;

public interface IStateMachine
{
	int state {get;}

	void NextState();
	void PrevState();
	void SetState(int state);
	void Submit();
	//void Back();
	void NextSelect();
	void PrevSelect();
	void OnEnter();
	void OnExit();
}