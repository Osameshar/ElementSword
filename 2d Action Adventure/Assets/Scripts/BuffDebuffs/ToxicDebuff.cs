using UnityEngine;
using System.Collections;

public class ToxicDebuff: BuffDebuff {

	private int remainingDuration;
	private string name;
	private const int DURATION_MODIFIER = 5; 
	private float debuffStrength = 7f;
	private string iconLocation = "Enemy";
	private string iconName = "Toxic";
	public ToxicDebuff (int stacks)
	{

		remainingDuration = DURATION_MODIFIER * stacks;
		name = "ToxicDebuff";
		
	}
	public int GetRemainingDuration ()
	{
		return remainingDuration;
	}
	public string GetName ()
	{
		return name;
	}
	public void onApply (Stats stats)
	{
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetBool("Toxic",true);
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetBool("ToxicR",true);
	}
	public void onSecond (Stats stats)
	{
		stats.gameObject.GetComponent<CombatManagerEnemy>().TakeDamage(debuffStrength,null,false);
		remainingDuration--;
	}
	public void onEnd (Stats stats)
	{
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetBool("ToxicR",false);
	}
	public string GetIconLocation ()
	{
		return iconLocation;
	}
	public string getIconName()
	{
		return iconName;
	}
}
