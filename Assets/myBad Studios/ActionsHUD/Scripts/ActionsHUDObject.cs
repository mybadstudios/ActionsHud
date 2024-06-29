//Contextual Actions HUD © 2024 by Ryunosuke Jansen is licensed under CC BY-ND 4.0.

using UnityEngine;
using System.Collections;

namespace MBS {
	public class ActionsHUDObject : MonoBehaviour {

		public EActionsHudAction[]
			actions;

		[System.NonSerialized]
		public bool has_focus = false;
	}
}