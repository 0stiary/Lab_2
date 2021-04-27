/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCreature : LivingCreature, IInteractable
{
	[SerializeField] private float _interactionDistance; 
	private float _stoppingDistance;
	public InteractionController InteractionController { get; protected set ; }

	public virtual float InteractionDistance => _interactionDistance;
	public virtual float StoppingDistance => _stoppingDistance * 0.8f;

	public Transform Body => transform;

	protected override void Start()
	{
		base.Start();
		InteractionController = new NPCInteractionController(this);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, _interactionDistance);
	}

	private void OnDestroy()
	{
		InteractionController.OnDestroy();
	}
}

*/