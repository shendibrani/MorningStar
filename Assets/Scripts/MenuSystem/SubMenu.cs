using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SubMenu : MonoBehaviour, IStateMachine, IStateBasedUI
{
	public int state {get; protected set;}
	
	bool _visible;

	protected virtual void Start()
	{
		overlord = FindObjectOfType<MenuOverlord>();
	}

	public MenuOverlord overlord {get; protected set;}

	public bool visible {
		get{
			return _visible;
		}
		set{
			_visible = value;
			if(value){
				Show();
			} else {
				Hide();
			}
		}
	}

	public virtual void OnEnter() {}

	public virtual void OnExit(){}

	#region IStateBasedUI
	
	public void Hide()
	{
		//Debug.Log("Hide");
		foreach(UIDrawerBehaviour ui in GetComponentsInChildren<UIDrawerBehaviour>()){
			ui.NextPosition(1);
		}
		foreach(UIDrawerBehaviour ui in GetComponentsInParent<UIDrawerBehaviour>()){
			ui.NextPosition(1);
		}
	}
	
	public void Show ()
	{
		//Debug.Log("Show");
		foreach(UIDrawerBehaviour ui in GetComponentsInChildren<UIDrawerBehaviour>()){
			ui.NextPosition(0);
		}
		foreach(UIDrawerBehaviour ui in GetComponentsInParent<UIDrawerBehaviour>()){
			ui.NextPosition(0);
		}
	}
	
	#endregion

	#region IStateMachine
	
	public abstract void NextState();
	
	public abstract void PrevState();

	public abstract void SetState(int state);

	public abstract void NextSelect();
	
	public abstract void PrevSelect();

	public abstract void Submit();

	#endregion
}

public abstract class SubMenu<T> : SubMenu where T : MonoBehaviour
{
	[SerializeField] protected List<T> states;

	#region IStateMachine
	
	public override void NextState()
	{
		state++;
		state = (state%states.Count + states.Count)%states.Count;
	}
	
	public override void PrevState()
	{
		state--;
		state = (state%states.Count + states.Count)%states.Count;
	}

	public override void SetState (int s)
	{
		state = s;
		state = (state%states.Count + states.Count)%states.Count;
	}

	public override void NextSelect()
	{
		if(states[state].GetComponent<IStateMachine>() != null){
			states[state].GetComponent<IStateMachine>().NextState();
		}
	}
	
	public override void PrevSelect()
	{
		if(states[state].GetComponent<IStateMachine>() != null){
			states[state].GetComponent<IStateMachine>().PrevState();
		}
	}

	public override void Submit(){}

	#endregion
}