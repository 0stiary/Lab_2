using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;
public abstract class Item
{
	private ItemBase _itemBase;
	protected PlayerCreature _owner;
	public ItemId ItemId => _itemBase.ItemId;
	public int CurrentCost => _itemBase.Cost;
	public Sprite InventoryIcon => _itemBase.InventoryIcon;

	public int CurrentStackCount { get; protected set; }

	public Item(ItemBase itemBase)
	{
		_itemBase = itemBase;
	}

	public abstract bool Use();

	public void SetOwner(PlayerCreature player)
	{
		_owner = player;
	}

	public void ReleaseItem()
	{
		_owner = null;
	}

	public abstract bool CanBeUsed();
}

public class Equipment : Item
{
	public EquipmentBase EquipmentBase { get; private set; }

	public Equipment(EquipmentBase itemBase) : base(itemBase)
	{
		EquipmentBase = itemBase;
	}

	public override bool Use()
	{
		if (CanBeUsed())
		{
			_owner.PlayerEquipmentController.EquipItem(this);
			return true;
		}

		return false;
	}

	public override bool CanBeUsed()
	{
		////change 
		return true;
	}
}
