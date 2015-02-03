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

		EquipSpell("FrostShield");
	}

	public void EquipSpell(string spellName)
	{
		Spell newSpell = (Spell)attackLibrary.GetAttackByName (spellName);
		if(equippedSpells.Contains(newSpell.GetComboCode ()))
			equippedSpells.Remove (newSpell.GetComboCode ());
		equippedSpells.Add (newSpell.GetComboCode (), newSpell);

	}

	public void CastSpell(GameObject enemy, GameObject player, int[] numStacks)
	{
		int combocode = CalculateCode(numStacks);
		if (combocode != 0)
		{
			Spell toCast = (Spell)equippedSpells [combocode];
			toCast.ExecuteAttack (enemy, player);
		}
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
