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
		allAttacks.Add ("FrostShield", new FrostShield ());
		allAttacks.Add ("Toxic", new Toxic ());
		allAttacks.Add ("IgniteTheBlight", new IgniteTheBlight ());
		allAttacks.Add ("BlackIce", new BlackIce ());
	}

	public Attack GetAttackByName(string name)
	{
		return (Attack)allAttacks [name];
	}
}
