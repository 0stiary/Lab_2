using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
	public override float StoppingDistance
	{
		get { return _interactionDistance * 0.1f; }
	}

	protected override void Interact()
	{
		base.Interact();
		Debug.Log("No no no, you can't pick up this " + transform.name);
	}
}
