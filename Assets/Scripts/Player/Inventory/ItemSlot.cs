using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Items;
public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] protected Image _slotImage;
	public bool IsEquipped { get; private set; }
	public Item SlotItem { get; private set; }
	public bool SlotInteractable { get; protected set; }
	public PlayerCreature PlayerCreature { get; set; }

	public Action<ItemSlot> LeftPointerClicked = delegate { };
	public Action<ItemSlot> RightPointerClicked = delegate { };


	public void AddItemToSlot(Item item)
	{
		if (IsEquipped)
			RemoveItem();

		SlotItem = item;
		IsEquipped = true;
		_slotImage.sprite = SlotItem.InventoryIcon;
		_slotImage.color = Color.white;
	}

	public virtual void RemoveItem()
	{
		_slotImage.sprite = null;
		_slotImage.color = Color.clear;
		SlotItem = null;
		IsEquipped = false;
	}
	public virtual void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			OnLeftPointerDown();
		}

		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (PlayerCreature.PlayerInventoryController.MovingItem != null)
				return;
			OnRightPointerDown();
		}
	}

	protected virtual void OnLeftPointerDown()
	{
		LeftPointerClicked(this);
		Debug.Log("LeftClick");
	}

	protected virtual void OnRightPointerDown()
	{
		if (!IsEquipped)
			return;

		RightPointerClicked(this);
		Debug.Log("RightClick");
	}
}