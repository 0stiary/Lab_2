using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private PlayerCreature _player;
	private List<Item> _inventoryItems = new List<Item>();
	private int _inventoryCapacity = 100;

	public PlayerInventory(PlayerCreature player)
	{
		_player = player;
	}

	public bool AddItemToInventory(Item item)
	{
		if (_inventoryItems.Count < _inventoryCapacity)
		{
			_inventoryItems.Add(item);
			ShowInventoryItems();
			return true;
		}
		else
		{
			return false;
		}
	}

	private void ShowInventoryItems()
	{
		foreach (Item inventoryItem in _inventoryItems)
		{
			Debug.Log(inventoryItem.ItemId);
		}
	}

	public void RemoveItemFromInventory()
	{

	}
}
