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

## Design
I decide that I want to design and implement incrementally because:

* encrypt and decrypt look very similar/symmetric, i.e. if I get one right the other one will be very easy
* I want to move more quickly through all phases to get feedback more quickly

### Increment 1: Encrypt
#### 22f4bdb
I'm hesitating a moment whether to start designing with text or graphics.

I also realize some anxiousness because I'm being watched by the auto-committer and the screen snapper. I want to do it right the first time... :-/

#### 5bdf4e9
First writing down steps that come to my mind as bullet points instead of as a data flow is easier. It's less fixed, less effort.

#### 52b588b
The problem is simple so I come up with the steps in the right order right away.

Numbering the steps is almost not necessary. But I want to use shortcuts during visual refinement.

#### 6267809
I'm not absolutely sure that letting the filename stream flow out of the delete step is the best thing to do. Maybe I'm gonna push the loop up one level and do encryption and deletion both on single filenames.

Counting at the end in the ∑ step seems to be ok. It's so easy.

#### 61fe78d
A lot of work is done in the `FileSystemProvider`. But that's easy, I guess. Good abstractions provided by the .NET Fx.

The core domain logic is nicely sitting in just one functional unit. That will be easy to test.

## Implementation
### Increment 1: Encrypt
##### 2747bb4, 02c6b55
Setting up test project and acceptance test skeleton.

#### 573091b
Setting up test data. I copy them from the requirements.

#### 22ccb1c .. dd2ee4b (4)
Create a utility function to copy a whole folder tree as test data.

I run into a misunderstanding with `File.Copy`: I think it creates directories if any are given in a filename.

Not true, so I have to create the folders myself. Getting the loop right takes a little longer than expected.

#### 73a7899 .. 833d1a6 (4)
Fleshing out the acceptance test.

This is straightforward.

I decide to check for checking only filenames reported as processed (not whole paths) to make the assert easier.

#### f9e5492 .. b0582a2 (3)
Setting up a test for ROT13. I decide to go straight for the domain logic. That should be simple - and fun. (I kind of shy away from dealing with resources.)

A list a couple of test cases for whole strings to encrypt.

#### c844cb4 .. 6578b84
Implementing the ROT13 algo is simple (with a little bit of help from Wikipedia for the char map).

Since encryption maps Input -> Output I call the function `EncryptDecrypt`. I don't expect to touch any again in a future increment to decrypt data.

#### deaf838 .. b0a0859 (6)
Implementing the `FileSystemProvider`. I go for an implementation w/o test. It all seems very easy. Some methods are just mapping to a .NET Fx function.

The signatures are there from the design.

In 7b5aa7d I finally decide to deviate from the design: I merge storing and deleting of files into a replace operation: `ReplaceOriginalWithProcessed`. That way deleting the original file (the unencrypted one) is structurally not optional anymore. It also makes the FileSystemProvider truely specific to the solution: it keeps the file system in a consistent state. There always is just one file: unencrypted or encrypted. Sounds like a persistent ADT to me.

#### 4c4efa6, 9bb0d97
My feeling is right: the FileSystemProvider is so simple, I get it right the first time.

After filling it and ROT13 into the RequestHandler the acceptance test goes green!

#### 8135808
However I realize that the acceptance test has a flaw: it does not check if encryption results in only .encrypted files. I amend the test.

#### 4b7033e .. bbca863 (5)
I set up the Display adapter. Very easy.

I set up the Config adapter. Also quite easy. I decide to return an enum from `Parse` to tell the command specified on the command line (instead of using an event). Using tuples that easy.

In 20a6d72/bbca863 I decide to introduce an `App` class for addition integration. (Forgot that during design.)

#### de331ba, 918cba1
Finally some refactoring/clean-up.


