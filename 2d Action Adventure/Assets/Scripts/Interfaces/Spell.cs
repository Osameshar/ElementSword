using UnityEngine;
using System.Collections;

public interface Spell : Attack
{
	bool IsDiscovered ();

	int GetComboCode();

}
