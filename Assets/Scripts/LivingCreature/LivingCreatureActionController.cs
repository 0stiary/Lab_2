using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingCreatureActionController
{
	[SerializeField] private LivingCreature _livingCreature;

	private ActionType _currAction;

	public LivingCreatureActionController(LivingCreature livingCreature)
	{
		_livingCreature = livingCreature;
		_livingCreature.ServiceManager.DestroyHandler += OnDestroy;
		_livingCreature.ServiceManager.UpdateHandler += OnUpdate;
    }

	protected virtual void Move(Vector3 destination, float stoppingDistance = 0.5f)
	{
		_livingCreature.CreatureNavMeshAgent.destination = destination;
		_livingCreature.CreatureNavMeshAgent.stoppingDistance = stoppingDistance;
		ChangeAction(ActionType.Run);
	}

    protected virtual void ChangeAction(ActionType action)
    {
	    ResetAction();
        _currAction = action;
	    if (_currAction != ActionType.None)
	    {
		    _livingCreature.CreatureAnimator.SetBool(_currAction.ToString(),true);
	    }
    }

    protected virtual void ResetAction()
    {
	    if (_currAction != ActionType.None)
	    {
		    _livingCreature.CreatureAnimator.SetBool(_currAction.ToString(),false);
	    }

	    _currAction = ActionType.None;
    }

    protected virtual void OnUpdate()
    {
	    if (Vector3.Distance(_livingCreature.transform.position,_livingCreature.CreatureNavMeshAgent.destination) <= _livingCreature.CreatureNavMeshAgent.stoppingDistance)
	    {
		    ChangeAction(ActionType.None);
		    _livingCreature.CreatureNavMeshAgent.destination = _livingCreature.transform.position;
	    }
    }

    protected virtual void OnDestroy()
    {
	    _livingCreature.ServiceManager.DestroyHandler -= OnDestroy;
	    _livingCreature.ServiceManager.UpdateHandler -= OnUpdate;
    }
}

public enum ActionType
{
    None,
    Run,
}
