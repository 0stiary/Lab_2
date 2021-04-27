using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : LivingCreature
{
	[SerializeField] private PlayerWindow _playerWindow;
	[SerializeField] private PlayerEquipment _playerEquipment;

	public PlayerInventoryController PlayerInventoryController { get; private set; }
	public PlayerEquipmentController PlayerEquipmentController { get; private set; }

	public PlayerInventoryUI PlayerInventoryUI => _playerWindow.PlayerInventory;
	public PlayerEquipmentUI PlayerEquipmentUI => _playerWindow.PlayerEquipment;
	public PlayerEquipment PlayerEquipment => _playerEquipment;
	public PlayerWindow PlayerWindow => _playerWindow;

	protected override void Start()
	{
		base.Start();
		ActionController = new PlayerActionController(this);
		_playerWindow.InitComponents();
		PlayerInventoryController = new PlayerInventoryController(this);
		PlayerEquipmentController = new PlayerEquipmentController(this);

	}
}
