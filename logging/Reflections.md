# Relection
## Assessment
### Analysis
#### Blocks
Started drawing late. Why? I guess it was because of the special situation of "being watched" by the logging tools. And there was a bit of awkwardness on the iPad because I could not use Notability. The Miro board being mirrored to my Mac felt a bit strange.

Yes, "being watched" krept up later again. It kind of pushes to make decisions more quickly; I feel less relaxed, less happy to explore alternatives.

But also I trusted the logging of text changes more than that of screenshots. With texts Git records deltas/changes, but with screenshots it's just always complete images.

I did not use drawing consistently. After some hesitation I did a system-context diagram. But then I did not stay with it and continued down the slicing hierarchy. That made it a bit more difficult to come up with a function signature in the end.

#### Flow
Looking up the ROT13 algo instead of inventing a solution myself definitely let me go faster.

Event though writing down an example took some time it made me feel better; I was able to go faster later because I was sure to have understood the algo.

Proper requirements with sample data are really helpful. Coming up with samples myself would have cost additional time - without knowing if they are correct.

### Design
#### Blocks
The first increment was pretty large. I should have looked for ways to further decompose its "big problem" into smaller, incremental ones with test cases to be applied at the "bottleneck" `Encrypt`.

Again I hesitate to start drawing.

Here and there during design I hesitate because I'm thinking about whether the design is good enough or clean enough for publich viewing. But then... this isn't about perfection.

#### Flow
Moving forward in increments (independently/after analysis) was of great help.

Once I started designing visually it all works out just fine.

I feel relieved once I decide that I don't need to come up with a perfect design. If I gain new insights during implementation that's fine, too. I can tweak the solution at any time - as long as the code stays clean.

During increment 2 it feels good to just focus on differences in the drawing.  No need to carry over a lot; this is just a design I need  to be able to understand ;-) Still, though, doing it visually makes designing easier.

### Implementation
#### Blocks
Not knowing API calls definitely caused some hesitation and repetition: `File.Copy`, `Path.*`. I was overconfident.

Implementation of increment 1 went smoothly with just an addition test for the domain logic. But I guess I was a bit lucky there. Not having tests for the file system provider bit me during increment 2. And I guess I could have avoided some hesitation had I tested it earlier.

A more fine grained incremental approach to implementation could have helped to be more correct in the first place, too.

Merging storing and deleting files created a function with larger reponsibility. I guess that abetted the bug in it.

I was very surprised when the acceptance test for `Encrypt` did not run anymore after I had made the changes for increment 2 :-(

#### Flow
Implementing under above the "safety net" of an an acceptance test definitely felt good.

Going straight for the domain logic after the acceptance test was motivating.

Merging storing and deleting files was a good idea to represent the ROT13 paradigm (symmetric encryption) in code.

To have the IODA architecture "in my fingertips" helps to find a nice structure for the code beyond the design. Adding adapters and even an `App` class is easy.

Implementing the second increment was easy in general due to the design which showned me exactly where changes were needed.

I was tempted to start debugging after the disappointment of failed tests during increment 2. But I'm glad I stuck to first writing more detailed tests. Debugging might have let me find a problem more quickly - but it would have left no trace.

Code structured according to the IOSP made it easy to add tests later.

## Evaluation
### Patterns
My understanding of basic API calls failed me several times. I knew the API calls, I had a rough understanding - but did not know I didn't know them really well.

Tests were insufficient several times. Not necessarily incorrect, but at least not as sound as I thought.

I hesitated several times visualizing my thinking with Flow-Design.

During analysis and design I should have looked more often for ways to further decompose the problem into increments.

### Insights
Doing a proper analysis and a design before implementation definitely was of great benefit! It did not slow me down. Rather it made me confident in what I would do during implementation.

Being even more incremental in progressing through the implementation of the solution helps even if my basic approach is to implement complementary parts separately.

Designing visually definitely does not need to be perfect. "Just enough fidelity and consistency" is needed :-) Rooted in IOSP/PoMO/IODA I feel confident to make refining decisions on the fly during implementation.

More tests of logic-laden functions are in order and avoid nasty debugging sessions.

## Conclusion
### Resolutions
1. Start drawing earlier
2. Decompose into smaller increments
3. Write more (scaffolding) tests for operations to make sure I undertstand APIs and get the logic right.
4. Shed the anxiety of "being watched" ;-)

### Summary
A great exercise! Very focussing and unexpectatly tiring. Deliberate programming is quite demanding - but also rewarding.

Flow-Design made it easy - but I must not be overconfident
