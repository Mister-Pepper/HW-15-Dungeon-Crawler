using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightController : MonoBehaviour
{

    // variable declaration 
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;

    /*
        Object for the announcer text mesh pro
    */

    public TextMeshPro announcer_TMP;

    // variable whether the attacker is player or munster
    private bool isHero = true;

    

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Ghost");
       
        this.hero_hp_TMP.text= "Current HP: " + MySingleton.thePlayer.getHP() + " \n AC: " + MySingleton.thePlayer.getAC();
        this.monster_hp_TMP.text= "Current HP: " + this.theMonster.getHP() + " \n AC: " + this.theMonster.getAC();
        
            int num = Random.Range(0,2); // coin flip simulation
            if(num == 0)
            {
                this.currentAttacker = hero_GO;
            }
            else 
            {
                this.currentAttacker = monster_GO;
            }

            StartCoroutine(fight());
    }

    private void tryAttack(Inhabitant attacker, Inhabitant defender)    // not actually creating an instance of Inhabitant, so this is legal - they are just containers
    {
        // attacker will be trying to attack the defender
        int attackRoll = Random.Range(0,20) + 1;// this will give us a value between 1-21...
        if (attackRoll >= defender.getAC())
        {
            // only runs if we roll a big enough number
            int damageRoll = Random.Range(0,4) + 2; // creates damage between 2 and 5..

            // will use if else statement to decide what text to put into announcer
            if(isHero == true)
            {
                announcer_TMP.text = ("You have hit the enemy for " + damageRoll + " damage!");
            }
            else
            {
                
                announcer_TMP.text = ("The monster hit you for " + damageRoll + " damage!");
            }

            defender.takeDamage(damageRoll);
        }
        else 
        {
            announcer_TMP.text = ("attack missed!!!");
        }
    }

    IEnumerator fight()
    {

        yield return new WaitForSeconds(2);

        if(this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            if(this.currentAttacker == this.hero_GO)
            { 
                // this is where we make sure bool value is true
                isHero = true;

                this.currentAttacker = this.monster_GO;
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.monster_hp_TMP.text = "Current HP:\n" + this.theMonster.getHP() + "AC: " + this.theMonster.getAC();
            
                if (this.theMonster.getHP() <= 0)
                {
                    announcer_TMP.text = ("Player 1 wins!!!!");
                    this.shouldAttack = false;
                }
                else 
                {
                    StartCoroutine(fight());
                }
            }
            else
            {
                // isHero value edit for monster when in tryAttack
                isHero = false;

                this.currentAttacker = this.hero_GO;
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + "\nAC: " + MySingleton.thePlayer.getAC(); 

                if(MySingleton.thePlayer.getHP() <= 0)
                {
                    announcer_TMP.text = ("A soldier has fallen...");
                    this.shouldAttack = false;
                }
                else 
                {
                    StartCoroutine(fight());
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
