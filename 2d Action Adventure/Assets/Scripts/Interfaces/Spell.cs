using UnityEngine;
using System.Collections;

public interface Spell : Attack
{
	bool isDiscovered ();

	int getComboCode();

}
