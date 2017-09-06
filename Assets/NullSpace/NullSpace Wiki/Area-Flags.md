#### Area
An area on the suit refers to a set of physical feedback zones.  

Although there are 16 physical zones, there are more than 16 areas: for example, `Back_Both` refers to the two back zones, and `Left_All` refers to all zones on the left side of the body. Areas can be combined using bitwise operations, such as `Left_All | Right_All`, or `Chest_Left | Forearm_Left`.

![A picture of the 16 haptic feedback zones on the suit](images/suit.png)

**Operators**  

Through the use of bitwise operations, you can create a specific AreaFlag value that only activates just the zones you want.

**Bitwise OR**  

`AreaFlags.Left_All | AreaFlags.Right_All` is equivalent to `AreaFlags.All_Areas`
`AreaFlags.Upper_Arm_Right | AreaFlags.Shoulder_Right` would only activate those two areas.

**Bitwise XOR**  
You can also select a large variety of areas, and remove out specific ones you do not want using the bitwise xor operator `^`.  
`AreaFlags.All_Areas ^ AreaFlags.Chest_Left` is equivalent to all areas without the left chest case.

**Example**  

```c#
string file = "ns.click";
AreaFlag allAbs = AreaFlag.None;
allAbs = allAbs | AreaFlag.Lower_Ab_Both;
allAbs = allAbs | AreaFlag.Mid_Ab_Both;
allAbs = allAbs | AreaFlag.Upper_Ab_Both;
new Sequence(file).CreateHandle(allAbs).Play();
```


## All Area Flags

This is a list of all current area flags.

```c#
None
Left_All
Right_All
All_Areas

Forearm_Left
Upper_Arm_Left
Shoulder_Left
Back_Left
Chest_Left
Upper_Ab_Left
Mid_Ab_Left
Lower_Ab_Left

Forearm_Right
Upper_Arm_Right
Shoulder_Right
Back_Right
Chest_Right
Upper_Ab_Right
Mid_Ab_Right
Lower_Ab_Right

Forearm_Both
Upper_Arm_Both
Shoulder_Both
Back_Both
Chest_Both
Upper_Ab_Both
Mid_Ab_Both
Lower_Ab_Both
```