using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    #region characterstats
    [Tooltip("Current hp")]
    public int hp;
    [Tooltip("atk = damage it deals")]
    public int atk;
    //[Tooltip("matk=atk but ignores armor or something")]
    //public int matk;
    [Tooltip("spd = movespeed")]
    public int spd;
    [Tooltip("def = enemy armor (damage from player blocked)")]
    public int def;
    [Tooltip("Rate of Fire")]
    public int rof;
    [Tooltip("range = atk range")] //Not sure if something to deal with this stat is implemented
    public int range;
    [Tooltip("Is it made of slime?")] //optional <- if implemented changes how damage is dealt to enemy (as in if a person hits an enemy with this "True"
    public bool slime?; //optional
    
    //If implemented or something?
    //
    //public bool AoE?
    //public bool pierce? Tooltip("bullet goes in straight path, deal damage to stuff in path)
    //public int hit -> Tooltip("number of people hit at once")]
    
    #endregion
    #region statfunctions
    
    //###############################
    //NOTE: all stats are placeholders (kind of). May be re-balanced (depending on player damage/health
    //  Range depends on how the map looks later
    //NOTE2: Delete enemies to lessen programming/enemy design work.
    //###############################
    
    //Beginner level enemies
    public void dirt_golem() //sword slow, damage focus, low rof
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
        //If needed to randomize some stat values
        //(example if this code is correct)hp += rnd.Next(500);
    }
    
    public void apprentice() //sniper, (slow rof high range)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void skeleton() //archer, (mid range, high dps?)
    {
        hp = 1;
        atk = 1;
        spd = 2;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void rat() //high speed, high damage, low rate of fire
    {
        hp = 1;
        atk = 1;
        spd = 4;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void slime()
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = True;
    }
    
    //Mid-stage Enemies
    public void stone_golem() //sword slow, damage focus, low rof
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    public void mage() //sniper, (slow rof high range)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void skeleton() //archer, (mid range, high dps?)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void salamander()
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void big_slime()
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = True;
    }
    
    //High-level Enemies, optional probably if spritework/programming can't make in time
    public void iron_golem() //sword slow, damage focus, low rof
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void apprentice() //sniper, (slow rof high range)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void skeleton() //archer, (mid range, high dps?)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void golem() //some animal thing
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void very_big_slime()
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = True;
    }
    
    //Boss
    public void cult_leader() //sniper, (slow rof high range)
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void dragon() //some animal thing
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void king_slime()
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = True;
    }
    public void whale() //honestly don't know how this is going to work
    {
        hp = 1;
        atk = 1;
        spd = 1;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
}
