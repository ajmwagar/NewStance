This section covers  
* Setting up the suit in its entirety
* Common troubleshooting

## NullSpace Service
### Step 1: Ensure the NullSpace Service is up to date and running

* If you were specified to use a specific version, use that one, otherwise use the most up to date.  
* The service does not yet automatically update. You can check the version by right clicking the trap icon and selecting the [Version Info] option.  
* For more information on the service: check the [**Readme**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/blob/master/README.md).

### Step 2: Enable the Service.
* The service does not automatically run or automatically enable. This is temporary while we ensure stability of the service before we make it run and enable on boot.
* Right click the tray icon and select the [Enable Suit] option to enable the Service. The icon will be white while the service is not enabled and green while it is enabled.

### Step 3: Plug and Power the Suit
Current versions of the suit require 2 things:  

1. Power
2. Data

You have been provided with:  

1. An extension cord  
2. A power adapter for the suit (5V/.5A Adapter)  
3. A USB to Micro USB data cable  
4. A USB to USB data cable extender (male-female ends)  

### Step 3A: Powering the Suit  

* Plug the power adapter into the extension cord.  
* Plug the extension cord into an outlet.  
* Plug the round end of the power adapter into the back & bottom of the suit.  
* Wait for the wake-up routine as it activates each pad in turn on the suit.

### Step 3B: Data for the Suit  

* Plug the data extender into the USB to Micro USB data cable.  
* Plug the large USB end into the computer.  
* Plug the micro USB end into the back & bottom of the suit.  

**Note**: You must plug the power in before you plug in the data for software to work. This is a temporary issue and will be resolved in the future.

### Step 4: Test the Suit using Software  
There are many ways to test the suit.  
The tray icon has an option [Test Suit]. This will play a simple effect on each pad.
You can also use the [**HapticExplorer**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/Haptic-Explorer).

* The source for the HapticExplorer is included in the Unity SDK .unitypackage.  
* A standalone built version of the HapticExplorer is included in the Unreal SDK.  

Once you have confirmed the suit works, feel free to begin your application.

## ====Troubleshooting====

### The tray icon is green but it isn't detecting the suit/working.
This is likely a Tray Icon/Service problem.  
This assumes you have properly set up the data & power cables as they can cause this problem.
  

* Press Ctrl+Shift+Esc to open the task manager.  
* Navigate to the Processes Tab. Click More Details on the bottom (Don't click Fewer Details)  
* Select a process and press 'N' on your keyboard to cycle through Processes that start with N  
* Confirm both NSVRGUI and NSVRService exist.  
* Navigate to the Services Tab.  
* Press 'N' to find 'NullSpace VR Runtime' and confirm it is in the Running status.  

If each of these processes & services are in the appropriate states and you're still having problems, [**contact us**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/Contact-Us).  

Attempt to end the process of NSVRService. This should set the 'NullSpace VR Runtime' to Stopped.

### NullSpace VR Runtime is stuck with a status of 'Stopping'

* This is a fixed bug and shouldn't happen again.  
* If stopping the process fails to fix this issue, [**contact us**](https://github.com/NullSpaceVR/NullSpace-Chimera-SDK/wiki/Contact-Us) and we will help resolve this issue.  
* This was likely a problem caused during installation/uninstallation. Think about when you installed or uninstalled the service last, this information will be helpful to us in fixing your issue.