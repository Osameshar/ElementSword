using UnityEngine;
using System.Collections;

public class SpellBook
{
	private Hashtable equippedSpells;
	private AttackLibrary attackLibrary;

	public SpellBook()
	{
		equippedSpells = new Hashtable ();
		GameObject libs = GameObject.FindWithTag ("Libraries");
		attackLibrary = libs.GetComponent<AttackLibrary>();
	}

	public void EquipSpell(string spellName)
	{
		Spell newSpell = (Spell)attackLibrary.GetAttackByName (spellName);
		if(equippedSpells.Contains(newSpell.getComboCode ()))
			equippedSpells.Remove (newSpell.getComboCode ());
		equippedSpells.Add (newSpell.getComboCode (), newSpell);

	}

	public void CastSpell(GameObject enemy, GameObject player, int[] numStacks)
	{
		int combocode = CalculateCode(numStacks);
		Spell toCast = (Spell)equippedSpells [combocode];
		toCast.ExecuteAttack (enemy, player);
	}

	int CalculateCode(int[] numStacks)
	{
		int combocode = 0;

		if (numStacks [0] > 0)
			combocode += 100;
		else if (numStacks [1] > 0)
			combocode += 10;
		else if (numStacks [2] > 0)
			combocode += 1;

		return combocode;
	}

}
