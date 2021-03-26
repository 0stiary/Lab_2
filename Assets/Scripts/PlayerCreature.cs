using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : LivingCreature
{
	protected override void Start()
	{
		base.Start();
		ActionController = new PlayerActionController(this);
	}
}
