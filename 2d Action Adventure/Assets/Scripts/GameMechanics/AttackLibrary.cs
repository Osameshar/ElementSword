using UnityEngine;
using System.Collections;

public class AttackLibrary : MonoBehaviour 
{
	private Hashtable allAttacks;

	void Awake()
	{
		allAttacks = new Hashtable ();
		allAttacks.Add ("QuickFire", new QuickFire ());
		allAttacks.Add ("QuickFrost", new QuickFrost ());
		allAttacks.Add ("QuickPoison", new QuickPoison ());
		allAttacks.Add ("QuickWind", new QuickWind ());
		allAttacks.Add ("StrongAttack", new StrongAttack ());

	}

	public Attack GetAttackByName(string name)
	{
		return (Attack)allAttacks [name];
	}
}
