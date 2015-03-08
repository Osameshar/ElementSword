using UnityEngine;
using System.Collections;

public class BlackIceDebuff : BuffDebuff {

	private int remainingDuration;
	private string name;
	private const int DURATION_MODIFIER = 1;
	private const int DAMAGE_MODIFIER = 20;
	private float damage;
	private string iconLocation = "Enemy";
	private string iconName = "BlackIce";

	public BlackIceDebuff (int coldStacks, int poisonStacks)
	{
		remainingDuration = DURATION_MODIFIER * coldStacks;
		damage = (DAMAGE_MODIFIER * poisonStacks)/remainingDuration;
		name = "BlackIceDebuff";		
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
		stats.alterStunned (remainingDuration);
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetTrigger("BlackIce");
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetBool("BlackIceR",true);
	}
	public void onSecond (Stats stats)
	{
		stats.gameObject.GetComponent<CombatManagerEnemy>().TakeDamage(damage,null,false);
		remainingDuration--;
		stats.alterStunned (-1);
		Debug.Log (stats.getStunned ().ToString ());
	}
	public void onEnd (Stats stats)
	{
		stats.gameObject.transform.Find ("PersonalAnim").gameObject.GetComponent<Animator>().SetBool("BlackIceR",false);
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
