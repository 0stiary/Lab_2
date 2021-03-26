using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : LivingCreatureActionController
{
	private PlayerCreature _playerCreature;
	private Interactable _lastTarget;

	public PlayerActionController(PlayerCreature player) : base(player)
	{
        _playerCreature = player;
        _playerCreature.ServiceManager.InputController.LeftPointerClickHandler += LeftPointerClicked;
    }

	private void LeftPointerClicked(Vector3 destination, Collider collider)
	{
		if (_lastTarget != null)
		{
			_lastTarget.DeFocus();
		}
		if (collider != null)
		{
			_lastTarget = collider.GetComponent<Interactable>();
			if (_lastTarget != null)
			{
				_lastTarget.OnFocus(_playerCreature);
				destination = _lastTarget.transform.position;
				Vector3 centrePoint = new Vector3(_lastTarget.transform.position.x, _playerCreature.transform.position.y, _lastTarget.transform.position.z);
				Move(centrePoint, _lastTarget.StoppingDistance);
				return;
			}
			//Debug.Log(collider);
			
		}

        Move(destination);
    }

	protected override void OnDestroy()
	{
		base.OnDestroy();
		_playerCreature.ServiceManager.InputController.LeftPointerClickHandler -= LeftPointerClicked;
	}
}
