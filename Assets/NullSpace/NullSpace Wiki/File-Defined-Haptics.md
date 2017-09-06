Note: **all haptics must be within the StreamingAssets folder**. 

[Click here](#use-in-unity) to jump to use of file-defined haptics in C#.
***


For examples of file-defined haptics, see the `StreamingAssets/NS Core` and `StreamingAssets/NS Demos` directories in the SDK. 

Haptic files come in three flavors: [sequences](#sequences), [patterns](#patterns), and [experiences](#experiences). Haptics are defined in files using the JSON format. This allows haptic effects to be distributed and shared.



### Sequences
A sequence is a list of *one or more [effects](haptic-effects)* that play on a single area. 
A sequence may map directly onto a single effect as is the case in `NS Core`, but this is not necessary.

```json
    {"sequence": [	{"time" : 0.0, "effect" : "bump", "strength" : 1.0, "duration" : 0.0}	]}
```

This sequence contains one effect, at time offset `0.0`, playing at full strength. Any effect with a duration of `0.0` will play for its natural duration, which is about 1/10 of a second. 

### Patterns
One step up from sequences, patterns are the bread and butter of a haptic artist. A pattern is a collection of sequences on one or more areas. 
Think a gunshot, a punch, a teleportation effect, or a shockwave. 

```json
      {
	"pattern" : [
		{"time" : 0.0, "sequence" : "ns.demos.click_click_click", "area": "Lower_Ab_Left"},
		{"time" : 3.8, "sequence" : "ns.demos.click_click_click", "area": "Mid_Ab_Left"},
		{"time" : 7.6, "sequence" : "ns.demos.click_click_click", "area": "Upper_Ab_Left"}
	]
}

```

This pattern contains three sequences, each within the `ns.demos` namespace. Your patterns and experiences can reference ours by using the relevant namespace, which can be found in the `config.json` file in a haptic asset folder. 

Areas can be specified using the same names as the `AreaFlag` enum in the SDK, and can be combined using the `|` operator. For example, you could write `"area" : "Mid_Ab_Left|Right_All"`. See [Using Area Flags](area-flags).

**Note: The `|` operator is the ONLY operator supported in files.**

### Experiences
An experience is best thought of as a collection of time indexed patterns, and is suitable for long running (think movie-like, on-rails) haptic experiences. 

```json
    {
	"experience" : [
		{"time" : 0.0, "pattern" : "ns.demos.test"}
 		{"time" : 5.0, "pattern" : "ns.demos.test"}

	]
}

```
This experience contains two patterns. The first will play immediately, while the second will begin playing after five seconds. 

***

### Use in Unity
After you save your file with the correct extensions (`.pattern`, `.pat`, `.experience`, `.exp`, `.sequence`, `.seq`), it can be used through the SDK.

Sequences, Patterns, and Experiences can be created by calling their constructors with a namespaced name as the argument. 

`new Sequence("ns.click")`

`new Pattern("yourcompany.gunshot")`

`new Experience("yourcompany.movie")`

The act of calling the constructor represents acquiring an asset. If you have a gigantic haptic file, it would not be a good idea to call `new Experience()` in a tight loop, but rather in your setup code. 

Then, call the `CreateHandle(..)` method:

`new Sequence("ns.click").CreateHandle(AreaFlag.Chest_Left)`

`new Pattern("ns.test").CreateHandle()`

The `CreateHandle` method returns a `HapticHandle` which can be used to manipulate the haptic effect. 
The methods available on `HapticHandle` are `Play`, `Pause`, and `Reset`. 

`Play` will play the effect until completion. 
- Calling `Play` after the effect is already playing has no effect
- If the effect finishes, calling `Play` will restart the effect

`Pause` will pause the effect.

`Reset` will "seek" the effect to the beginning, allowing it to be played again.

Additionally, `Dispose` will release the haptic handle, allowing the haptics engine to reclaim resources. 