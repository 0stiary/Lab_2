using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
	InteractionController InteractionController { get;}
	
	float InteractionDistance { get; }
	float StoppingDistance { get; }

	Transform Body { get; }
}


public abstract class InteractionController
{
	private bool _isFocused;
	private bool _hasInteracted;
	private PlayerCreature _player;

	private IInteractable _thisInteractable;

	public InteractionController(IInteractable interactable)
	{
		_thisInteractable = interactable;
		ServiceManager.Instance.UpdateHandler += OnUpdate;
		ServiceManager.Instance.DestroyHandler += OnDestroy;
	}

	public void OnFocus(PlayerCreature player)
	{
		_isFocused = true;
		_player = player;
	}

	public void DeFocus()
	{
		_isFocused = false;
		_hasInteracted = false;
	}

	// Start is called before the first frame update

	// Update is called once per frame
	private void OnUpdate()
	{

		if (_isFocused && _player != null && Vector3.Distance(_thisInteractable.Body.position, _player.transform.position) < _thisInteractable.InteractionDistance && !_hasInteracted)
		{
			Interact();
		}
	}

	private void Interact()
	{
		_hasInteracted = true;
		Debug.Log("Interacted " + _thisInteractable.Body);
	}

	public void OnDestroy()
	{
		ServiceManager.Instance.DestroyHandler -= OnDestroy;
	}

}

public class NPCInteractionController : InteractionController
{
	public NPCInteractionController(IInteractable interactable) :base(interactable)
	{

	}
}