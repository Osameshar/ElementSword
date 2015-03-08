using UnityEngine;
using System.Collections;

public interface BuffDebuff

{
	int GetRemainingDuration();

	string GetName();

	void onApply (Stats stats);

	void onSecond (Stats stats);

	void onEnd(Stats stats);

	string GetIconLocation ();

	string getIconName ();
}
