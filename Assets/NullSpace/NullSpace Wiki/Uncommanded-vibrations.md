Did a location (perhaps a shoulder pad) on the suit play an unwanted effect?

More likely - did a pad seem to stay on after the effect should've ended?

This is a well known issue and we're working on the inner level workings to fix this. It is most often caused by lots of effects playing in the same pad/pads.

If you experience this to an excessive degree, send an email to casey@nullspacevr.com or message him in Slack.

##Fixes
These are all temporary holdover fixes.

* Play another effect (which will end and that ending will likely not get ignored, ceasing the overall effect).  
* Call a Halt All Effects command to the lower level APIs.