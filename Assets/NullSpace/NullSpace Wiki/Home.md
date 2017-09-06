# NullSpace Quickstart

Current requirements:
- Windows (7, 8, 8.1, 10)


###  Verify that the hardware is working 
1. Plug the suit into its power source.
2. Plug one end of the Micro USB into the suit, and the other end into a free USB port on your computer.
3. Around 10 seconds after connecting to the computer or connecting power, the suit should play a startup routine, activating all motors.

Make sure you power the suit before connecting the USB data cable. 

### Install the service
1. See the README.md in this repo

### Unity SDK
The minimum required version of Unity is Unity 5.3.4f1
#### Run the test scene
1. Import the NullSpace SDK into Unity (*Assets → Import Package → Custom Package*), or
double click the `.unitypackage` provided in this repo
2. Open the scene `NullSpace SDK/Suit.unity` in the Unity Editor
3. Hit play, and then click on the grey pads to verify that the suit is working. The pads should play a five second long hum. 

***

#### Further reading
- Try out the `Haptics Explorer` scene, which has a bunch of haptic effects
- Creating your own [haptics](simple-example)!
- See the *Troubleshooting* articles in the sidebar if you experience problems