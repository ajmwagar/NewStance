This page is for taking apart several provided samples as well as talking about the thoughts behind their creation.

## Experience: MECH STOMP

Mech Stomp is made up of many Left-Right-Repeat individual stomps at decreasing intervals.

**Mech_stomp.experience component**

		{"time" : 0.0, "pattern" : "ns.demos.mech_stomp_left"},  
		{"time" : 1.2, "pattern" : "ns.demos.mech_stomp_right"},  
		[Repeated stomps at decreasing intervals]

It is then followed by an intense segment and a light haptic effect.

**Mech_stomp.experience ending component**

		{"time" : 11.2, "pattern" : "ns.demos.intense"},  
		{"time" : 13.0, "pattern" : "ns.demos.on_fire"},  
		{"time" : 15.0, "pattern" : "ns.demos.on_fire"}  

Let's look at one of the stomps (Left and Right only differ in their area flags)

**Mech_stomp_left.pattern**

		{"time" : 0.00, "sequence" : "ns.demos.HeavyBuzz", "area": "Lower_Ab_Left"},  
		{"time" : 0.05, "sequence" : "ns.demos.HeavyBuzz", "area": "Mid_Ab_Left"},  
		{"time" : 0.1, "sequence"  : "ns.demos.HeavyBuzz", "area": "Upper_Ab_Left"},  
		{"time" : 0.15, "sequence" : "ns.demos.HeavyBuzz", "area": "Chest_Left"},  
		{"time" : 0.2, "sequence"  : "ns.demos.HeavyBuzz", "area": "Shoulder_Left"},  
		{"time" : 0.2, "sequence"  : "ns.demos.HeavyBuzz", "area": "Shoulder_Left"},  
		{"time" : 0.3, "sequence"  : "ns.sharp_tick",      "area": "Shoulder_Left"},  
		{"time" : 0.4, "sequence"  : "ns.sharp_tick",      "area": "Upper_Arm_Left"},  
		{"time" : 0.5, "sequence"  : "ns.sharp_tick",      "area": "Back_Left"},  
		{"time" : 0.5, "sequence"  : "ns.demos.HeavyBuzz", "area": "Back_Left|Upper_Arm_Left|Chest_Left"}  

The general idea here is that it begins in the lower sections and moves up the body. Due to the greater delays the farther the feet, the more it feels like a movement going up the user's body. Due to the use of **ns.sharp_tick** instead of continued **HeavyBuzz**, this causes the effect to feel like it is falling off.  
Finally, a **HeavyBuzz** on three locations (see **[Area Flags](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/Area-Flags)** for that last line syntax) makes it feel like a 'Stomp finished shudder' across the upper section of the user's body.

Looking back at **mech_stomp.experience** we can see the times of each stomp decrease every couple stomps.


0.0  ->  1.2  
1.2  ->  2.4  
2.4  ->  3.4  
3.4  ->  4.4  
4.4  ->  5.2   
5.2  ->  6.0   
6.0  ->  6.6   
6.6  ->  7.2   
7.2  ->  7.8   
7.8  ->  8.4   
8.4  ->  9.0   
9.0  ->  9.6   
9.6  ->  10.2  
10.2 ->  10.8  
10.8 ->  11.2  

This decreasing timing is to give the user the feeling they are speeding up.  
This accomplishes a second goal however. After the first few steps, the user understands the haptics that are taking place (we aren't varying the effects/patterns used) but by accelerating the pace of the haptics, the effects still feel new.

Lets look at the ending haptics:

**intense.pattern**

		{"time" : 0.0, "sequence" : "ns.buzz", "area": "All_Areas"},  
		{"time" : 0.1, "sequence" : "ns.buzz", "area": "All_Areas"},  
		[Repeated ns.buzz on all areas every 0.1 seconds]  

This is about giving the user a strong ending to the effect to simulate flight, tackling something or taking damage. The effect however follows up with a light effect.

**on_fire.pattern**

		{"time" : 0.00, "sequence" : "ns.buzz", "area": "Lower_Ab_Both", "strength" : 0.2},  
		{"time" : 0.10, "sequence" : "ns.buzz", "area": "Mid_Ab_Both", "strength" : 0.2},  
		{"time" : 0.20, "sequence" : "ns.buzz", "area": "Upper_Ab_Both", "strength" : 0.2},  
		{"time" : 0.30, "sequence" : "ns.buzz", "area": "Chest_Both|Back_Both", "strength" : 0.2},  
		{"time" : 0.40, "sequence" : "ns.buzz", "area": "Shoulder_Both", "strength" : 0.2},  
		{"time" : 0.50, "sequence" : "ns.buzz", "area": "Mid_Ab_Both|Upper_Arm_Left", "strength" : 0.2},  
		{"time" : 0.60, "sequence" : "ns.buzz", "area": "Upper_Ab_Both|Upper_Arm_Left|Forearm_Left", "strength" : 0.2},  
		[Many areas with ns.buzz played on low strengths]

This ending is physically very mild through the use of the strength parameter. Part of the reason for this is to taper out off of the intensity of the majority of **mech_stomp.experience**. We don't want to suddenly stop the **HeavyBuzz**, as that sudden absence would 'feel' like an effect tacked onto the end of the experience.

##Mech Stomp Lessons

So what did we learn from mech_stomp.experience?

1. Changing timing does a good job at preventing effects from becoming stale or repetitive.  
2. **[Area Flags](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/Area-Flags)** rock. Look at the files and how much more complex they'd have to be without Area Flags.  
3. This experience wouldn't be a very valuable in-game asset. Instead, it's component parts could be utilized effective. For instance, you could connect each side of stomp to the animation rig for when the foot touches down. That way the effect would dynamically adjust depending on the player's input.
4. The strength parameter is a necessary part of accessing lower strength members of each [**effect family**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/haptic-effects)
5. Sudden stopping of strong effects can feel like something on their own. This is a topic we aim to spend a bit of time researching.

[FLEXING PECTORALS]
## Pattern: FLEXING PECTORALS  

Flexing Pectorals is a simple pattern made up of two different sequences.  

Let's dig in  

**FlexingPectorals.pattern (part 1 of 2)**



		{"time" : 0.0, "sequence" : "ns.demos.ClickStorm"	, "area": "Chest_Right"},   
		{"time" : 0.5, "sequence" : "ns.demos.ClickStorm"	, "area": "Chest_Left"},   
		{"time" : 1.0, "sequence" : "ns.demos.ClickStorm"	, "area": "Shoulder_Right"},  
		{"time" : 1.5, "sequence" : "ns.demos.ClickStorm"	, "area": "Shoulder_Left"},  
		{"time" : 2.0, "sequence" : "ns.demos.ClickStorm"	, "area": "Upper_Arm_Right"},  
		{"time" : 2.5, "sequence" : "ns.demos.ClickStorm"	, "area": "Upper_Arm_Left"},  


The time appears to have every component about half a second after the previous.  
The area starts in the chest and moves out to the shoulder. One of the (upper body) strengths of this pattern is that it isn't mirroring itself which draws the users attention to focus on the pattern as its playing.  
Note that on the Right side of the body it steps from 0.0s to 1.0s to 2.0s. The Left side is 0.5 to 1.5 to 2.5s.  

Before we look at the ending, we'll look at ClickStorm and HeavyBuzz:

**ClickStorm.sequence**

		{"time" : 0.0, "effect" : "double_click", 				"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.1, "effect" : "click", 						"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.2, "effect" : "long_double_sharp_tick", 	"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.3, "effect" : "sharp_click", 				"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.4, "effect" : "sharp_tick", 				"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.5, "effect" : "short_double_click", 		"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.6, "effect" : "short_double_sharp_tick", 	"strength" : 1.0, 	"duration" : 0.0},  
		{"time" : 0.7, "effect" : "triple_click", 				"strength" : 1.0, 	"duration" : 0.0}  


ClickStorm is all over the place.  

It features the 8 different click effects. This is probably overkill but it does create a unique combination. Note the total duration of ~.8 seconds.  

Recall how the FlexingPectorals, each side offset the motion down the arms by 1s.   
This means that per side, the previous effect had ended before the next one began. Additionally, the left side will start playing a bit before the right finishes. This creates the effect of pulling the user attention in multiple directions maintaining novelty of the effect despite constant timing and sequence choice.  

**FlexingPectorals.pattern (part 2 of 2)**



		{"time" : 3.4, "sequence" : "ns.demos.HeavyBuzz"	, "area": "Chest_Both"},   
		{"time" : 3.9, "sequence" : "ns.demos.HeavyBuzz"	, "area": "Chest_Both"},   
		{"time" : 4.4, "sequence" : "ns.demos.HeavyBuzz"	, "area": "All_Areas"},   
		{"time" : 4.9, "sequence" : "ns.demos.HeavyBuzz"	, "area": "Chest_Both"}   



The second half of FlexingPectorals uses HeavyBuzz. This is partially to shake up the experience around the time the user starts to get used to ClickStorm as well as to increase the intensity of the haptics as the Pattern reaches it's conclusion.  

**HeavyBuzz.sequence components**


		{"time" : 0.00, "effect" : "buzz", "strength" : 1.0, "duration" : 0.0},  
		[6 total buzzes, each .04 seconds apart]  


HeavyBuzz is very simple but there is a point to it.  
Lots of haptics close together is usually a bit stronger than the base buzz for .25 seconds. The reason for this is this starts and stops the motor in atypical ways which creates a more changing and therefore more noticeable haptic.  

Lets look back at the area in the second half of FlexingPectorals. It plays on Chest_Both twice, then on all areas of the suit and then back on Chest_Both.  
Playing on Chest_Both twice changes the experience up from the first half of moving ClickStorm. Then right as the user expects a third HeavyBuzz on Chest_Both, we play it on All_Areas to surprise them.  
Finally, we play the third HeavyBuzz on Chest_Both as they expected, but we have subverted their expectations yeilding a positive experience. This third HeavyBuzz also serves to tone them down after HeavyBuzz being played on every pad.  

##Flexing Pectorals Lessons

So what did we learn from FlexingPectorals.pattern?

1. Sequences don't need to be perfect to create great effects.
2. Set up the users expectations but also subvert them. Guide their focus in a direction and then do something different than what they expected.
3. Using only a few areas at any given time makes using all areas more surprising
4. Overlapping haptics with other haptics playing can make it difficult to focus, but this can create a textured feeling rather than overload.
5. Try out the different effects (effect families) that exist, they have subtle differences that add up over time


[BUMP SPAM]



[CHEST WASHER]

