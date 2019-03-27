# Annotations
## Analysis
### Log
#### Commit 8db7a8f
Created a solution for a console applicationn w/o much thinking. Seemed make the task more tangible.

#### 3f2ae9f, a7ab7f4
Started drawing pretty late. First tried to wrap my head around the problem by writing something. But it then felt more natural and easier to quickly draw "the situation".

#### c8e1d59
I decided to "not play dumb". The exercise is not about "re-inventing" ROT13, but "to get the job done", i.e. the whole program to run. Hence I used Wikipedia to tell me how ROT13 can be most easily: with a map.

#### 8a842ec
Even though it's easy to do I put an example of encrypting a text and then decrypting the encrypted text in the analysis. Just to be sure I understood the algorithm correctly.

First I though encryption meant mapping Input to Output, and decryption meant mapping Output to Input. But for both en/decryption it's the same: Input -> Output.

#### fbde3b5
Non-map characters are not en/decrypted. Good to know. But it made me wonder about the value of this kind of encryption.

But I expect this fact to make it easier to process file content by just sucking in all text and doing a character-by-character mapping.

#### 8b8ca90, bdff37f
It's good there are samples provided! Less work for me to get a test off the ground.

#### f4464c0
For a moment I hesitated how to make the filenames accessible to the outside of the core functionality. But that was because I tried to come up with function signatures before doing a proper slicing.

#### 4c09991
Finally I remember to do real slices. The dialogs and interactions are obvious so I jump right to the message handling.

While drawing the output for `encrypt` I realize that passing out the number of processed files should be easier and looks natural. The filenames are delivered through a stream as "expected" earlier when I wrote up the signatures.

But the signatures have to be adapted to the slice now: an `int` is returned by the functions.
