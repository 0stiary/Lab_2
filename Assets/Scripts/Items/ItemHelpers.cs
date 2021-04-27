using System;
using Player;
using UnityEngine;

namespace Items
{
	public static class ItemHelper
	{
		public static bool CanBeEquiped(EquipmentType type, EquipmentSlotType slotType)
		{
			switch (type)
			{
				case EquipmentType.Weapon:
					return slotType == EquipmentSlotType.ItemRigth;
				case EquipmentType.Shield:
					return slotType == EquipmentSlotType.ItemLeft;
				default:
					Debug.Log("Not supported type");
					return false;
			}
		}
	}
	[Serializable]
	public class ItemStat : Stat
	{
		public IncreaseType IncreaseType;
	}

	public enum ItemId
	{
		Sword = 1,
		Shield = 2,
		Armor = 3
	}

	public enum StatType
	{
		Default = 0,
		Hp = 1,
		Mp = 2,
		Agility = 3,
		Strength = 4,
		Intelligence = 5,
		Defense = 6,
		Damage = 7,
		AttackSpeed = 8
	}

	public enum IncreaseType
	{
		Value,
		Percent
	}

	public enum EquipmentType
	{
		Weapon,
		Shield,
		Helmet,
		Chest,
		Gloves,
		Boots,
		Belt,
		Ring,
		Amulet,
	}
	public enum RarityLvl
	{
		Common = 0,
		Uncommon = 1,
		Magical = 2,
		Rare = 3,
		Epic = 4,
		Legendary = 5,
	}

}
