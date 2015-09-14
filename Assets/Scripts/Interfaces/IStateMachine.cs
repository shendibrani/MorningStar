using System;

public interface IStateMachine
{
	int state {get;}

	void NextState();
	void PrevState();
	void NextSelect();
	void PrevSelect();
	void SetState(int state);
	void Submit();
	//void Back();
	void OnEnter();
	void OnExit();
}