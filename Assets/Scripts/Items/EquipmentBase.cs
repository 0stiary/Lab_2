using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Item/Equipment")]
public class EquipmentBase : StatItemBase
{
	[SerializeField] private Stat[] _requiredStats;
	[SerializeField] private EquipmentType _equipmentType;
	[SerializeField] private RarityLvl _rarityLvl;
	[SerializeField] private ItemStat[] _additionalStats;

	public Stat[] RequiredStats => _requiredStats;
	public EquipmentType EquipmentType => _equipmentType;
	public RarityLvl RarityLvl => _rarityLvl;
	public ItemStat[] AdditionalStats => _additionalStats;
}
