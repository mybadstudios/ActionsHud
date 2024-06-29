//Contextual Actions HUD � 2024 by Ryunosuke Jansen is licensed under CC BY-ND 4.0.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MBS;

public class ActionsHUD : MonoBehaviour 
{
	System.Action<EActionsHudAction[]> onFocusOnItem;
	
	static ActionsHUD _instance;
	static public ActionsHUD Instance {
		get
		{
			if (null == _instance)
				_instance = FindObjectOfType<ActionsHUD>();
			return _instance;
		}
	}
	
	bool _is_active = true;
	public bool IsActive { get {return _is_active; } } 
	
	ActionsHUDButton[] buttons;
	
	public GameObject
		target;
	
	void Start()
	{
		buttons = GetComponentsInChildren<ActionsHUDButton>();
		foreach(ActionsHUDButton button in buttons)
		{
			onFocusOnItem += button.SetVisibilityBasedOn;
		}

		#if UDEA
		//Integration with the Unity Dialogue Engine Advance ( a.k.a. THE Dialogue Engine )
		UDEA.OnDialogueStarted += HideHudForUDEA;
		UDEA.OnDialogueEnded += ShowHudAfterUDEA;
		#endif
	}
	
	#if UDEA
	void HideHudForUDEA(object source, UDEAEvent e)
	{
		HideHUD();
	}
	
	void ShowHudAfterUDEA(object source, UDEAEvent e)
	{
		ShowHUD();
	}
	#endif

	void OnDestroy()
	{
		onFocusOnItem = null;
	}
	
	public void FocusOnItem(EActionsHudAction[] icons, GameObject target)
	{
		this.target = target;
		if (null != onFocusOnItem)
			onFocusOnItem(icons);
	}
	
	#if UDEA
	void Update()
	{
		ShowHUD (!(UDEA.State == eUDEAState.Active || Shop.showing));
		
		if (IsActive && UDEA.State == eUDEAState.Inactive)
			TestForKeyPress();
	}
	#else
	void Update()
	{
		if (null != target && IsActive)
			TestForKeyPress();
	}
	#endif
	
	void TestForKeyPress()
	{
		if (null == target) return;
		if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
		{
			foreach(ActionsHUDButton button in buttons)
			{
				if (button.action_button.interactable && button.action_key_type == EActionsButtonInputType.Tap && Input.GetKeyDown(button.action_key))
					ActionsHUDButtonPressed(button.action_response);
			}
			//don't trigger an onkeydown and onkey the same frame...
			return;
		}

		if (Input.anyKey && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
			foreach(ActionsHUDButton button in buttons)
		{
			if (button.action_button.interactable && button.action_key_type == EActionsButtonInputType.Hold && Input.GetKey(button.action_key))
				ActionsHUDButtonPressed(button.action_response);
		}
	}
	
	//use these two functions to hide or show the HUD
	public void HideHUD()
	{
		ShowHUD(false);
	}
	
	public void ShowHUD(bool show = true)
	{
		_is_active = show;
		foreach (ActionsHUDButton button in buttons)
			button.gameObject.SetActive(show);
	}
	
	public void ActionsHUDButtonPressed(string message)
	{
		if (null != target)
			target.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
	}
	
}