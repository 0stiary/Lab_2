using System.Collections;
using System.Collections.Generic;
using Items;
using Player;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : ItemSlot, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private EquipmentSlotType _equipmentSlotType;
	private Color _defaultColor;
	private Sprite _defaultSprite;

	public EquipmentSlotType EquipmentSlotType => _equipmentSlotType;

	private void Start()
	{
		_defaultSprite = _slotImage.sprite;
		_defaultColor = _slotImage.color;
		SlotInteractable = true;
	}

	public override void RemoveItem()
	{
		base.RemoveItem();
		_slotImage.color = _defaultColor;
		_slotImage.sprite = _defaultSprite;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Item item = PlayerCreature.PlayerInventoryController.MovingItem;

		if (item != null)
		{
			if (!(item is Equipment) || !ItemHelper.CanBeEquiped((item as Equipment).EquipmentBase.EquipmentType, _equipmentSlotType))
				SetSlotInteractability(false);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		SetSlotInteractability(true);
	}

	protected void SetSlotInteractability(bool isInteractable)
	{
		_slotImage.color = !isInteractable ? Color.red : IsEquipped ? Color.white : _defaultColor;
		SlotInteractable = isInteractable;
	}

	protected override void OnLeftPointerDown()
	{
		if (!SlotInteractable)
			return;
		base.OnLeftPointerDown();
	}

	protected override void OnRightPointerDown()
	{
		if (!SlotInteractable)
			return;
		base.OnRightPointerDown();
	}
}
