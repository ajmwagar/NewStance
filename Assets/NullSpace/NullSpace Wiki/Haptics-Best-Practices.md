This page is for conveying some of the knowledge of what makes stronger, more interesting haptic effects.



### Priming

Haptics are a tertiary source of conveyance. Your first two channels are visual and audio. If you want haptics to matter to your user, have visuals and audios that match, drawing attention and focus to that area.

### Repetition

Repetitive effects are bad. Don't do the same thing too much. Change strength, timing and effect a bit to diversify it more.

### Body Location has meaning

Let's say your game has a particular effect that plays on a pad when a specific something occurs. Don't randomize or vary this unless the circumstances are different. The player will only have so much ability to understand that a haptic effect has meaning.

### Sensory Overload

Don't overload the user. It's easy for a lot of things to happen at once and the user to get lost in the noise.  
A temporary solution for forcing attention on the important haptics is to stop all other effects. Use this as as a way to stop any disruptions from the important haptics.

### Dynamic & Runtime Effects

Dynamic effects are often better than file effects. Things like the Unity impulse generator (link coming soon) or slightly randomized effects are good approaches.   
Unreal doesn't have support for code effects quite yet, but you can change have a variable repeat loop while changing the the WHERE input pin. This can create the illusion of a moving effect.

### Processing Time

The human body has some degree of 'haptic processing time'. This is the time it takes the user to recognize that a haptic effect has occurred. It is worth attempting to exaggerate effects at times (similar to animation). If a two strike effect, have the first one occur a bit before the visual/audio of the first strike and the second haptic strike arrive a bit late.  
If the strikes are too close together, the body doesn't process them as separate things and the player interprets it as a bunch of haptics they don't understand.

### Ambient Effect
Ambient effects are hard to do. Don't do it too much or too frequently or they'll stop paying attention to other effects you care more about.
