using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
	ItemBody _itemBody;

	protected override void Start()
	{
		_itemBody = GetComponent<ItemBody>();
		base.Start();
	}

	protected override void Interact()
	{
		base.Interact();
		_itemBody.OnPickUp(_player);
	}



	public override float StoppingDistance
	{
		get { return _interactionDistance * 0.8f; }
	}

	//protected override void Interact()
	//{
	//	base.Interact();
	//	_thisItem.Destroy(_player);
	//}
}
