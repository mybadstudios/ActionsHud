//Contextual Actions HUD © 2024 by Ryunosuke Jansen is licensed under CC BY-ND 4.0.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace MBS {
	public enum EActionsButtonInputType {Tap, Hold}

	public class ActionsHUDButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
		public Button
			action_button;

		public EActionsHudAction
			action_type = EActionsHudAction.Collect;

		public string
			action_response;

		public KeyCode
			action_key;

		public EActionsButtonInputType
			action_key_type;

		public bool
			show_keyboard_key = true;

		public Text
			keyboard_text;

		bool button_down = false;

		ActionsHUD
			_actions_hud;

		ActionsHUD actions_hud
		{
			get
			{
				if (null == _actions_hud)
					_actions_hud = FindObjectOfType<ActionsHUD>();
				return _actions_hud;
			}
		}

		void Start()
		{
			if (show_keyboard_key && action_key != KeyCode.None)
			{
				keyboard_text.gameObject.SetActive(true);
				keyboard_text.text = action_key.ToString();
			} 
			else
			{
				keyboard_text.gameObject.SetActive(false);
			}
		}

		void Update()
		{
			if (button_down)
				actions_hud.ActionsHUDButtonPressed(action_response);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!(action_button.interactable || action_key_type == EActionsButtonInputType.Tap)) return;
			actions_hud.ActionsHUDButtonPressed(action_response);
		}
		
		public void OnPointerDown(PointerEventData eventData)
		{
			if (!(action_button.interactable || action_key_type == EActionsButtonInputType.Hold)) return;
			button_down = true;
		}
		
		public void OnPointerUp(PointerEventData eventData)
		{
			button_down = false;
		}
		
		public void SetVisibilityBasedOn(EActionsHudAction[] actions)
		{
			bool interactable = false;
			if (null != actions)
				foreach(EActionsHudAction action in actions)
				if (action == action_type)
				{
						interactable = true;
				}
			action_button.interactable = interactable;
		}
	}
}