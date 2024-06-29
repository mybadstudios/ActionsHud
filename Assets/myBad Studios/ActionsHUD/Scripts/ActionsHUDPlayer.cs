//Contextual Actions HUD � 2024 by Ryunosuke Jansen is licensed under CC BY-ND 4.0.

using UnityEngine;
using System.Collections.Generic;
using MBS;

public class ActionsHUDPlayer : MonoBehaviour 
{
	
	ActionsHUD				actions_hud;
	Collider[] 				NearItems;
	List<ActionsHUDObject>	ItemsInView;
	ActionsHUDObject		CurrentItem	= null;

	int LastCount = 0;
	int LookingAt = 0;
	
	public float interactDistance	= 1.5f;
	public float LookAngle			= 30f;
	
	public void Start()
	{
		actions_hud = FindObjectOfType<ActionsHUD>();
		ItemsInView = new List<ActionsHUDObject>();
	}
	
	public void CalculateActionState()
	{
		if (null == actions_hud) actions_hud = FindObjectOfType<ActionsHUD>();
		if (null == actions_hud) return;

		if (null != CurrentItem)
			actions_hud.FocusOnItem( CurrentItem.actions , CurrentItem.transform.root.gameObject);
		else
			actions_hud.FocusOnItem(null, null);
	}
	
	public void  UpdateActionHUD()
	{
		Vector3 targetDir;
		Vector3 forward;
		float angle;
		
		NearItems = Physics.OverlapSphere(transform.position, interactDistance);
		if (NearItems.Length != LastCount)
		{	
			ItemsInView.Clear();
			
			foreach (Collider x in NearItems)
			{
				targetDir = x.transform.position - transform.position;
				forward = transform.forward;
				angle = Vector3.Angle(targetDir, forward);
				
				if (angle <= LookAngle || angle >= -LookAngle)
				{
					if(x.transform.gameObject.TryGetComponent(out ActionsHUDObject aho))
						ItemsInView.Add(aho);
				}
			}

			LastCount = ItemsInView.Count;
			if (!LookingAtSameObject() )
				LookAtClosestItem();
		}
	}
	
	public bool LookingAtSameObject()
	{
		if (null != CurrentItem)
		foreach (ActionsHUDObject aho in ItemsInView)
		{
			if (aho == CurrentItem)
				return true;
		}			
		return false;
	}
	
	public void LookAtClosestItem()
	{
		float	distance	= Mathf.Infinity;
		float	sqrLen;
		int		index		= 0;
		int		lookat	= 0;
		
		if (ItemsInView.Count == 0)
		{
			LookAtItem(-1);
		} else
		{
			foreach (ActionsHUDObject x in ItemsInView)
			{
				sqrLen = (x.transform.position - transform.position).sqrMagnitude;
				if( sqrLen < distance )
				{
					lookat		= index;
					distance	= sqrLen;
				}
				index++;
			}
			LookAtItem(lookat);
		}
	}
	
	public void LookAtItem(int lookat)
	{
		ActionsHUDObject cur = CurrentItem;
		if (cur)
			cur.has_focus = false;
		
		LookingAt = lookat;
		
		if (lookat < 0)
		{
			if (null != CurrentItem)
			{
				CurrentItem = null;
				CalculateActionState();
			} else
				CurrentItem = null;
		}
		else
		{
			CurrentItem = ItemsInView[LookingAt];
			CurrentItem.has_focus = true;
			CalculateActionState();
		}
	}
	
	public void Update()
	{
		UpdateActionHUD();
	}

}