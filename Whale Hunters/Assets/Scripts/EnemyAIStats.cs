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
    //NOTE: all stats are placeholders (kind of). May be re-balanced (depending on player damage/health.
    //  Range depends on how the map looks later
    // Implement how stats work first, balance later.
    //NOTE2: Delete enemies to lessen programming/enemy design work.
    //###############################
    
    //Beginner level enemies
    public void dirt_golem() //sword slow, damage focus, low rof
    {
        hp = 5;
        atk = 3;
        spd = 1;
        def = 2;
        rof = 1;
        range = 1;
        slime? = False;
        //If needed to randomize some stat values
        //(example if this code is correct)hp += rnd.Next(500);
    }
    
    public void apprentice() //sniper, (slow rof high range)
    {
        hp = 10;
        atk = 9;
        spd = 1;
        def = 1;
        rof = 1;
        range = 6;
        slime? = False;
    }
    
    public void skeleton() //archer, (mid range, high dps?)
    {
        hp = 7;
        atk = 6;
        spd = 2;
        def = 2;
        rof = 3;
        range = 4;
        slime? = False;
    }
    
    public void rat() //high speed, high damage, low rate of fire
    {
        hp = 3;
        atk = 5;
        spd = 4;
        def = 1;
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void slime()
    {
        hp = 6;
        atk = 2;
        spd = 1;
        def = 0;
        rof = 1;
        range = 2;
        slime? = True;
    }
    
    //Mid-stage Enemies
    public void stone_golem() //sword slow, damage focus, low rof
    {
        hp = 25;
        atk = 10;
        spd = 1;
        def = 10;
        rof = 1;
        range = 1;
        slime? = False;
    }
    public void mage() //sniper, (slow rof high range)
    {
        hp = 15;
        atk = 20;
        spd = 1;
        def = 5;
        rof = 1;
        range = 6;
        slime? = False;
    }
    
    public void dark_skeleton() //archer, (mid range, high dps?)
    {
        hp = 13;
        atk = 15;
        spd = 2;
        def = 3; //slightly harder than a normal skeleton. Otherwise not so different
        rof = 3;
        range = 4;
        slime? = False;
    }
    
    public void salamander()
    {
        hp = 20; //"It's like a tank but slimier"
        atk = 10;
        spd = 3;
        def = 8;
        rof = 2;
        range = 2;
        slime? = False;
    }
    
    public void big_slime()
    {
        hp = 36; //"an accumulation of 6 normal slimes"
        atk = 4;
        spd = 1;
        def = 0;
        rof = 1;
        range = 2;
        slime? = True;
    }
    
    //High-level Enemies, optional probably if spritework/programming can't make in time
    public void iron_golem() //sword slow, damage focus, low rof
    {
        hp = 50;
        atk = 25; //Golem crush!
        spd = 1;
        def = 30; //"They say iron is 3x stronger than stone" -some Mage
        rof = 1;
        range = 1;
        slime? = False;
    }
    
    public void cultist() //sniper, (slow rof high range)
    {
        hp = 24;
        atk = 40; //"Offense is the best defense"
        spd = 1; //"I may be stronger but my staff makes me slower."
        def = 15;
        rof = 1;
        range = 6;
        slime? = False;
    }
    
    public void void_skeleton() //archer, (mid range, high dps?)
    {
        hp = 20;
        atk = 20;
        spd = 3; //void-stuff moves fast though air. No air-resistence you see.
        def = 10;
        rof = 3;
        range = 4;
        slime? = False;
    }
    
    public void serpend_of_evils_and_all_that_is_unholy_oh_the_terror() //some animal thing. Looks like a very big snake. Color it pink? It's friends call it Jimmy.
    {
        hp = 35;
        atk = 30; //Protip: Kill it quick
        spd = 4;
        def = 20;
        rof = 3;
        range = 3;
        slime? = False;
    }
    
    public void very_big_slime()
    {
        hp = 144;
        atk = 6; //bigger -> more mass -> more crushing strength
        spd = 1;
        def = 2; //more slimes -> more bounce -> somehow gets defense
        rof = 1;
        range = 2;
        slime? = True;
    }
    
    //Boss
    public void cult_leader() //sniper, (slow rof high range)
    {
        hp = 70; //Infused with the powers of the great Beyond
        atk = 50; //Boom, you dead
        spd = 1; //"I don't need to chase after you bugs"
        def = 18;
        rof = 2;
        range = 7;
        slime? = False;
    }
    
    public void dragon()
    {
        hp = 150;
        atk = 65;
        spd = 4;
        def = 45; //The true tank of the fantasy world.
        rof = 1;
        range = 4;
        slime? = False;
    }
    
    public void king_slime() //The biggest, baddest slime you will ever find in a forest.
    {
        hp = 500; //How many darn slimes are there???
        atk = 13;
        spd = 1;
        def = 3;
        rof = 1;
        range = 3; //Make this value so that it is as big as the width of the sprite of the King.
        slime? = True;
    }
    
    public void something_from_beyond_the_void() //"Not enough teleporting enemies" - said no one
    {
        hp = 50;
        atk = 30;
        spd = 99999;
        def = 26;
        rof = 3;
        range = 2;
        slime? = True;
    }
    
    public void whale() //honestly don't know how this is going to work
    { //"Come into the void of my stomach" or something
        hp = 99999;
        atk = 500;
        spd = 40; //"Flying faster than the speed of sound~"
        def = 100;
        rof = 3;
        range = 600; 
        slime? = False;
    }
    
}
