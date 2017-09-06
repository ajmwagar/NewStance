The Haptic Explorer is intended as a standalone test bench for playing and testing haptics.

[**Download Link to Built Explorer**](https://drive.google.com/drive/u/0/folders/0BzDLhj68fxxvM1VNcmhRejhkN1k)

# Quick Explanation
**Top Left**: Haptic Packages. Groups of different haptics. Click the folder icon to open the directory.  
**Right Half**: All the files in the selected. Green = sequence, Blue = pattern, Yellow = experience. Click the icon to open the file. Reload scene to test changes.  
**Bottom Left**: Testing options and buttons.  

* Green box plays its haptic on pads it touches (control with arrows)
* You can click pads to toggle them from being played when a Sequence button is played

The full source of the Haptic Explorer is provided in the NullSpace Unity SDK.

# Packages
The top left area of the Haptic Explorer shows the different Haptic Packages accessible in the StreamingAssets.

Click on one of these to open that package. The Haptic Explorer will remember the last package opened and will return to that if possible.
You can click on the folder button to directly open that directory.

# Package Contents
The right half of the Haptic Explorer is dedicated to individual files within the selected package.

There are three types of files included - Experiences, Patterns and Sequence. To learn more about Sequences, Patterns and Experiences [**check out the terminology page**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/terminology)

* Experience - Yellow buttons, galaxy icon  
* Pattern - Blue buttons, 3 stars icon  
* Sequence - Green buttons, single star icon  

You can click on each file to play it on the connected suit.  
Sequence files will play on all of the selected pads (configurable in the bottom left area)  

You can also open the source of a file by pressing the star, stars or galaxy icon.  


## Validity Checking  
A haptic file representation will turn red when played if the file is invalid.  

# Suit Panel  
The bottom left half is dedicated to suit display and testing options.  
  
## Testing Options   
  
### Mode: Select Pads  

* Select All Areas - Selects each area on the suit. Selected areas control which pads a played Sequence (green button) is play. (Faster than clicking each pad individually)  
* Select No Areas - Unselect each area on the suit. Great for testing if a specific pad is working. (Faster than clicking each pad individually)  

### Mode: Emanation Impulses  
Opens configuration options:  

* Effect - which of the base Effects is used for the Impulse. This can only support CodeSequences and not file sequences (for the time being).  
* Depth - How many neighbors the impulse will traverse before ending.  
* Effect Duration - How long to play each individual effect for.  
* Impulse Duration - The duration of the total impulse. The time between each stage is ImpulseDur/Depth.  

Then click on a pad to create an emanating impulse with the selected parameters.  
You can spam click to start multiple impulses.  
  
### Mode: Traversal Impulses  
Opens configuration options:  

* Effect - which of the base Effects is used for the Impulse. This can only support CodeSequences and not file sequences (for the time being).  
* Effect Duration - How long to play each individual effect for.  
* Impulse Duration - The duration of the total impulse. The time between each stage is ImpulseDur/Depth.  

Click on a first pad to select an origin.   
Click on a second pad to set a destination.   
Click on the first pad to clear the origin.  
You can spam click to start multiple impulses.  
  
### Mode: CodeSequence Emanation  
Opens configuration options:  

* CodeSequence - The first field is a slider for selecting one of eleven different CodeSequences. The source for these can be found in ImpulseCodeSequenceSamples.cs  
How many neighbors the impulse will traverse before ending.  
* Impulse Duration - The duration of the total impulse. The time between each stage is ImpulseDur/Depth.  

Note: The last three CodeSequence samples use randomization, so the impulse will have a different effect from usage to usage. This is most noticeable with the last VeryRandomEffect option. This is to demonstrate that it is possible and one way of doing it rather than stating it is the best possible haptic.
  

### Mode: Tracking [Incomplete]  
This is a stub for the mode when stable & robust source is released later.  
Currently in development.
  
### Option: Massage  
Starts or Stops the green collider box from massaging up and down on the suit.  
Will play the last selected haptic sequence.  

### Option: Stop All Haptics  
Stops all haptics that are currently playing. Good if you accidentally set a duration for like 5 hours... Not speaking from personal experience or anything.  

### Option: Quit Explorer  
Self explanatory - this surrenders your creativity and freedom as you settle into a life in the suburbs full of longing for what could have been.

### Green Haptic Collider  
Can be moved around using the arrow keys (or Massage button). When it collides with a pad, it will play the sequence listed on the green box.

### Suit Status Indicator  
This will update whether or not the suit is currently connected.  
A new approach to handling this is coming in the future. This would come with better ability to directly query the state of actively playing haptics  
