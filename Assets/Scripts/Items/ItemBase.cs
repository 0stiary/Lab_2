using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
	[SerializeField] private ItemId _itemId;
	[SerializeField] private string _name;
	[SerializeField] private string _description;
	[SerializeField] private int _cost;
	[SerializeField] private int _stackCount;
	[SerializeField] private Sprite _inventoryIcon;


	public ItemId ItemId => _itemId;
	public string Name => _name;
	public string Description => _description;
	public int Cost => _cost;
	public int StackCount => _stackCount;
	public Sprite InventoryIcon => _inventoryIcon;

}

public abstract class StatItemBase : ItemBase
{
	[SerializeField] private int _requiredLvl;
	[SerializeField] private ItemStat[] _primaryStats;

	public int RequireLvl => _requiredLvl;
	public ItemStat[] PrimaryStat => _primaryStats;
}






[Serializable]
public class Stat
{
	public StatType StatType;
	public int Amount;
}