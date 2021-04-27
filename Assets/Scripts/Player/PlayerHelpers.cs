using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	[Serializable]
	public class Stat
	{
		public StatType StatType;
		public int Amount;
	}

	public enum StatType
	{
		Default = 0,
		HP = 1,
		MP = 2,
		Agility = 3,
		Strengh = 4,
		Intelligence = 5,
		Defence = 6,
		Damage = 7,
		AtackSpeed = 8,
	}

	public enum EquipmentSlotType
	{
		None,
		ItemLeft,
		ItemRigth,
		Helmet,
		Chest,
		Gloves,
		Boots,
		Belt,
		RingLeft,
		RingRight,
		Amulet,
	}
}
