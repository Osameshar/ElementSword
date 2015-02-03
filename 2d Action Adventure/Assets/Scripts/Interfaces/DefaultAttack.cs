using UnityEngine;
using System.Collections;

public interface DefaultAttack : Attack
{
	string GetNextAttack();

	string GetPreviousAttack();

	Attack GetProjectileMode();
}
