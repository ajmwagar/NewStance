#ImpulseGenerator

In C# we have an Impulse Generator. We'll be re-implementing a similar system into Unreal as we get our Editor tools into a better state.  
To understand it, first we'll talk about an Impulse is.


#What is an Impulse 

An Impulse is a solved haptic effect that happens in multiple stages across multiple areas. Think of it like a Unity prefab that you instantiate, or an Unreal Blueprint. It is the basis for a complex effect that will change based on runtime.

**Example**: The player gets shot in Chest_Left. We want to have that location play a haptic, but we also want it to emanate to nearby pads. This is because real impact effects result in the applied forces getting distributed to the connected areas. Any substantial impact is not an isolated effect.

Impulses offer our developers a way to deliver on that higher fidelity haptic effect.

##Type of Impulse - Emanation

Emanation is the most basic type of Impulse. It occurs in one location and the emanates to a certain depth of N stages away.  

### Emanation Options  
**Effect**: Takes a [basic effect](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/haptic-effects) or a CodeSequence.  
**Start Location**: A single starting AreaFlag (do not provide Chest_Left|Chest_Right or Left_All or other multiple Area Flags)  
**Depth**: The number of stages that this will create. Max is currently 7 for the default Graph Engine connections.  
**Effect Duration**: An extrapolation of the created CodeSequence for the HapticsExplorer. The idea is how long the individual effect plays when the Impulse reaches that pad.  
**Impulse Duration**: The total duration the impulse takes to reach every pad at every stage.  


### Impulse Example  
The player was shot in the middle ab on their right side. I want it to emanate out one pad. I want the entire emanation to take .25 seconds. I want each step of it to last for .25 more seconds.  

````
int depth = 1;
float totalImpulseDuration = .25f;
float effectDuration = .25f;
float effectStrength = 1;
//Create the Impulse object (which can be told to play, which instantiates what it 'is')
ImpulseGenerator.Impulse myImpulse = ImpulseGenerator.BeginEmanatingEffect(AreaFlag.Mid_Abs_Right, depth);

// This sets the duration to be .25 seconds
myImpulse.WithDuration(totalImpulseDuration); 

//This defines the base effect (needs an effect name, a strength and a duration. 0.0 defaults to the effects natural duration)`
myImpulse.WithEffect("buzz", effectDuration, effectStrength);

//Finally, don't forget to play the effect.
myImpulse.Play();
````

##Type of Impulse - Traversal  

Traversal is a more controlled type of impulse. It is about a moving effect going from a start point to an end point.  

### Traversal Options  
Effect: Takes a [basic effect](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/haptic-effects) or a CodeSequence.    
Start Location: A single starting AreaFlag (again, do not provide a multi AreaFlag value). This is where the effect will first start playing.   
End Location: A single ending AreaFlag (no multi-AreaFlag values). This is where the effect will path-find towards taking the most 'direct' route. For more information on how this works, look at the source of GraphEngine.cs.  
Effect Duration: An extrapolation of the created CodeSequence for the HapticsExplorer. The idea is how long the individual effect plays when the Impulse reaches that pad.  
Impulse Duration: The total duration the impulse takes to reach every pad at every stage.  

### Examples

The player reached out and touched an electrical source.  
They receive an haptic effect that mimics the electric shock to their heart. This means our start location will be Forearm_Right and the end will be Chest_Left.  
Because it is an electrical shock, we will conceptualize that the impulse will be re-run multiple times while the player is touching the electrical source. However, we only want to do the more expensive operation of calculating the impulse once.

````
using UnityEngine;
using System.Collections;
public class LightningExample : MonoBehaviour
{
  //Should we start a shock.
  public bool ShouldShock = true;
  
  //Set to False to disrupt the current shock
  public bool CurrentlyShocking = true;
  
  //The Shock Impulse we want to make. We save this to only pay the more expensive cost
  ImpulseGenerator.Impulse shockImpulse;
  
  private void Start()
  {
    string whichEffect = "pulse";           //What's more electrical than pulses.
    float totalImpulseDuration = .35f;      //How long does the shock take to traverse to the heart.
    float effectDuration = 0.0f;            //0.0 defaults to the natural duration of the pulse effect.
    float effectStrength = 1;               //How strong is the pulse effect
  
    //Create the Impulse object (which can be told to play, which instantiates what it 'is')
    shockImpulse = ImpulseGenerator.BeginTraversingImpulse(AreaFlag.Forearm_Right, AreaFlag.Chest_Left);
  
    // This sets the duration to be .25 seconds
    shockImpulse.WithDuration(totalImpulseDuration);
  
    //This defines the base effect (which needs an effect name, a strength and a duration)
    shockImpulse.WithEffect(whichEffect, effectDuration, effectStrength);
  }
  
  void Update()
  {
    //IF we should shock and we aren't currently
    if (ShouldShock && !CurrentlyShocking)
    {
      //Start the coroutine!
      StartCoroutine(ShockPlayer());
      ShouldShock = false;
    }
  }
  
  //
  IEnumerator ShockPlayer()
  {
    //This serves as the 'Is Coroutine Running' variable
    CurrentlyShocking = true;
  
    //This is a construct for our repetition of the traversal effect.
    float delay = .4f;                      
  
    //Prevent the loop/effect from running forever.
    int breakout = 0;
  
    //A handle for canceling the shock when the condition is no longer true.
    HapticHandle shockHandle = null;
  
    //This is the loop that will re-start the impulse
    //Remember that CurrentShocking is a bool from outside this function. Meaning it can be turned off and then we leave the loop.
    while (CurrentlyShocking && breakout < 25)
    {
      //Finally, don't forget to play the effect.
      shockHandle = shockImpulse.Play();
  
      //Wait before the next zap
      yield return new WaitForSeconds(delay);
  
      //Max of X Zaps.
      breakout++;
    }
  
    //If we stop shocking the player, we want to clean up the last effect played. This means when the player stops touching the outlet, they stop getting shocked.
    shockHandle.Reset();
  
    //Mark that we aren't shocking the player.
    CurrentlyShocking = false;
  }
}
````

## Graph Engine

The current implementation of the ImpulseGenerator works closely with a temporary class called GraphEngine.  
The purpose of the GraphEngine is to construct a simple graph representing the suit and perform searches on it to evaluate adjacency, optimal paths and other pathfinding like behaviors.

We aim to integrate a similar functionality into the lower layers in the future. We are exposing the GraphEngine for the time being in the event you want to modify it or reimplement your own.

For the source: check out the included source of the .unitypackage - if this fails, email devs@nullSpacevr.com 

## Unfinished Features

### Strength & Attenuation 

Much like File-defined haptics, code defined haptics intend to support strength and inherited strength for components of haptics. However, strength and attenuation aren't yet implemented in the ImpulseGenerator.

The Attenuation feature will behave like an Impulse Modification function letting you change the intended strength of future components of the impulse.

#### Attenuation Examples  

````
    Default Attenuation
Attenuation 1  
Strength 1 -> 1 -> 1 -> 1  
Strength .5 -> .5 -> .5 -> .5  

    Decaying  
Attenuation .75  
Strength 1 -> .75 -> .56 -> .42 -> etc  

    Growing  
Attenuation 1.5    
Strength .2 -> .3 -> .45 -> .675 -> 1.00  

    Inverting  
Attenuation -1 (I don't know if this will work, but crazy ideas are sometimes good - like the internet)  
Strength 1 -> 0 (clamped from -1) -> 1 -> 0 (clamped from -1) -> 1  

````

### File Sequence Support

Code and file defined haptics are not capable of cross use quite yet.

This means you'll have to use CodeSequences to instead of file sequences for more complicated Impulse created haptics.


### Unreal Impulse Generator

The ImpulseGenerator is not on the short list of features for Unreal. We aim to reimplement it in the future. You have access to the ImpulseGenerator and GraphEngine source so you could create a C++ or Blueprint implementation yourself.  
If this feature is important to you - please reach out to us so we know to prioritize it more. We legitimately care about your game and want to do our best to help you.