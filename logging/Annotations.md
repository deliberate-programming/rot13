# Annotations
## Analysis
### Log
#### Commit [8db7a8f](https://github.com/deliberate-programming/rot13/commit/8db7a8f5aed6d77587782824bbccb6d6a03c92e0)

Created a solution for a console applicationn w/o much thinking. Seemed to make the task more tangible.

#### [3f2ae9f](https://github.com/deliberate-programming/rot13/commit/3f2ae9f2f5190e1766032aada439ac3e04fead4d), [a7ab7f4](https://github.com/deliberate-programming/rot13/commit/a7ab7f4dd629fbf074c1f09b143650477255b78a)
Started drawing pretty late. First tried to wrap my head around the problem by writing something. But it then felt more natural and easier to quickly draw "the situation".

#### [c8e1d59](https://github.com/deliberate-programming/rot13/commit/c8e1d5966b727653da4a191b94d70f7dc2da44fb)
I decided to "not play dumb". The exercise is not about "re-inventing" ROT13, but "to get the job done", i.e. the whole program to run. Hence I used Wikipedia to tell me how ROT13 can be most easily: with a map.

#### [8a842ec](https://github.com/deliberate-programming/rot13/commit/8a842ec7f88c036309e3919b42db6f0fca344888)
Even though it's easy to do I put an example of encrypting a text and then decrypting the encrypted text in the analysis. Just to be sure I understood the algorithm correctly.

First I thought encryption meant mapping Input to Output, and decryption meant mapping Output to Input. But for both en/decryption it's the same: Input -> Output.

#### [fbde3b5](https://github.com/deliberate-programming/rot13/commit/fbde3b504c6131773972b6e71f513b1b9cb76425)
Non-map characters are not en/decrypted. Good to know. But it made me wonder about the value of this kind of encryption.

But I expect this fact to make it easier to process file content by just sucking in all text and doing a character-by-character mapping.

#### [8b8ca90](https://github.com/deliberate-programming/rot13/commit/8b8ca90a57cf5722c77580dab9e4334a9ccabb64), [bdff37f](https://github.com/deliberate-programming/rot13/commit/bdff37f4015c803181ddbb745bd5f9f76b5a2c0c)
It's good there are samples provided! Less work for me to get a test off the ground.

#### [f4464c0](https://github.com/deliberate-programming/rot13/commit/f4464c05a2d1bb52290f94b73f1e87e3e2f584cf)
For a moment I hesitated how to make the filenames accessible to the outside of the core functionality. But that was because I tried to come up with function signatures before doing a proper slicing.

#### [4c09991](https://github.com/deliberate-programming/rot13/commit/4c0999192a1050c6befe5b21bc4fa1ffe699cc4a)
Finally I remember to do real slices. The dialogs and interactions are obvious so I jump right to the message handling.

While drawing the output for `encrypt` I realize that passing out the number of processed files should be easier and looks natural. The filenames are delivered through a stream as "expected" earlier when I wrote up the signatures.

But the signatures have to be adapted to the slice now: an `int` is returned by the functions.

## Design
I decide that I want to design and implement incrementally because:

* encrypt and decrypt look very similar/symmetric, i.e. if I get one right the other one will be very easy
* I want to move more quickly through all phases to get feedback more quickly

### Increment 1: Encrypt
#### [22f4bdb](https://github.com/deliberate-programming/rot13/commit/22f4bdbd4bade2cb77a0951d8fa683f0e81b8b11)
I'm hesitating a moment whether to start designing with text or graphics.

I also realize some anxiousness because I'm being watched by the auto-committer and the screen snapper. I want to do it right the first time... :-/

#### [5bdf4e9](https://github.com/deliberate-programming/rot13/commit/5bdf4e984e6990a01b15973f08366e336764c043)
First writing down steps that come to my mind as bullet points instead of as a data flow is easier. It's less fixed, less effort.

#### [52b588b](https://github.com/deliberate-programming/rot13/commit/52b588bea928b5185f69899b1e6cda05569f089d)
The problem is simple so I come up with the steps in the right order right away.

Numbering the steps is almost not necessary. But I want to use shortcuts during visual refinement.

#### [6267809](https://github.com/deliberate-programming/rot13/commit/6267809cc31006b0bab35ddc30732dd0f547c77b)
I'm not absolutely sure that letting the filename stream flow out of the delete step is the best thing to do. Maybe I'm gonna push the loop up one level and do encryption and deletion both on single filenames.

Counting at the end in the ∑ step seems to be ok. It's so easy.

#### [61fe78d](https://github.com/deliberate-programming/rot13/commit/61fe78d3912de0d900d4eb64d21f528b3942fd4e)
A lot of work is done in the `FileSystemProvider`. But that's easy, I guess. Good abstractions provided by the .NET Fx.

The core domain logic is nicely sitting in just one functional unit. That will be easy to test.

### Increment 2: Decrypt
#### [ea5](https://github.com/deliberate-programming/rot13/commit/ea5b93e0e8b4d8f361bcb21bd338c8d82b7c49e0)
I realize that decryption is like encryption. It just takes other files as input: encrypted files.

This realization I first document textually. It seems easier to write it down.

#### [f7b](https://github.com/deliberate-programming/rot13/commit/f7b343f84479e4bfb23a753833422a9a85e04dd3)
Only then I visualize this equivalence. I focus the drawing on just the differences regarding increment 1.

Mostly just the selection of the relevant files needs to be adapted by passing in the file extensions to focus on.

Nevertheless on the top level I introduce a `Decrypt` function to the `RequestHandler`. I don't want to leak the symmetry to the outside. And I don't want to require a client to pass in some parameters to select between encryption and decryption. On the outside encryption and decryption are two different operations. All else is a detail.

## Implementation
### Increment 1: Encrypt
##### [2747bb4](https://github.com/deliberate-programming/rot13/commit/2747bb4bd37382f0c5b4a87b8099c3a9b36cd71d), [02c6b55](https://github.com/deliberate-programming/rot13/commit/02c6b55b32d9fa0f38a90d12929a414dacf3ea2a)
Setting up test project and acceptance test skeleton.

#### [573091b](https://github.com/deliberate-programming/rot13/commit/573091b07f3b9e43dd24a2e0babb6826b3b9ae34)
Setting up test data. I copy them from the requirements.

#### [22ccb1c](https://github.com/deliberate-programming/rot13/commit/22ccb1c128f4f3cda550d8b778cb071b83e6c732), [315](https://github.com/deliberate-programming/rot13/commit/315aff2dec55292a069b734154de1dfefcd516ef), [b7f](https://github.com/deliberate-programming/rot13/commit/b7f7cdebf396642de2ff298c00fee6aa673dc272), [dd2ee4b](https://github.com/deliberate-programming/rot13/commit/dd2ee4b8a233e783e3d8dfb7797118936b00fda4)
Create a utility function to copy a whole folder tree as test data.

I run into a misunderstanding with `File.Copy`: I think it creates directories if any are given in a filename.

Not true, so I have to create the folders myself. Getting the loop right takes a little longer than expected.

#### [73a7899](https://github.com/deliberate-programming/rot13/commit/73a78999efdfb6014b7790260ec07bbe46dfbb7d), [7f7](https://github.com/deliberate-programming/rot13/commit/7f7d8deed080fe6160f373c0452a732370fbeb73), [3b8](https://github.com/deliberate-programming/rot13/commit/3b87be1c9c27c20d78130041a4a7c7223b6a97b7), [833](https://github.com/deliberate-programming/rot13/commit/833d1a649e5fe59919635d5a93c9af96e371fdc5)
Fleshing out the acceptance test.

This is straightforward.

I decide to check for checking only filenames reported as processed (not whole paths) to make the assert easier.

#### [f9e5492](https://github.com/deliberate-programming/rot13/commit/f9e5492fdb99a4dd1c86c7ae959bb730fbdf7978), [cb5](https://github.com/deliberate-programming/rot13/commit/cb566d275043900b93801f9b0ec8ed271d21155a), [b0582a2](https://github.com/deliberate-programming/rot13/commit/b0582a2b4aa2e2e7b55d059f6739d7edfc90ed5d)
Setting up a test for ROT13. I decide to go straight for the domain logic. That should be simple - and fun. (I kind of shy away from dealing with resources.)

A list a couple of test cases for whole strings to encrypt.

#### [c844cb4](https://github.com/deliberate-programming/rot13/commit/c844cb48469664c4a611ff82ba765c23c5039131), [6578b84](https://github.com/deliberate-programming/rot13/commit/6578b845fd465da4bb4171f468d0364917f781cf)
Implementing the ROT13 algo is simple (with a little bit of help from Wikipedia for the char map).

Since encryption maps Input -> Output I call the function `EncryptDecrypt`. I don't expect to touch any again in a future increment to decrypt data.

#### [deaf838](https://github.com/deliberate-programming/rot13/commit/deaf8384cf98c9e12fc75d90f5f1f386c1b8aa25), [141](https://github.com/deliberate-programming/rot13/commit/141ec04d0fd6c2e241ccf334d5a58dbfcb98ec26), [b21](https://github.com/deliberate-programming/rot13/commit/b215af6fd3463510704be3e53322cbf776790905), [e58](https://github.com/deliberate-programming/rot13/commit/e58c13834e67c856d6a824eedd2c74b4e5892d72), [7b5](https://github.com/deliberate-programming/rot13/commit/7b5aa7d0e59e79f9d30f8b2b84fb320331934aed), [b0a0859](https://github.com/deliberate-programming/rot13/commit/b0a0859a52d962979d29201efd156afd32f79ca0)
Implementing the `FileSystemProvider`. I go for an implementation w/o test. It all seems very easy. Some methods are just mapping to a .NET Fx function.

The signatures are there from the design.

In [7b5aa7d](https://github.com/deliberate-programming/rot13/commit/7b5aa7d0e59e79f9d30f8b2b84fb320331934aed) I finally decide to deviate from the design: I merge storing and deleting of files into a replace operation: `ReplaceOriginalWithProcessed`. That way deleting the original file (the unencrypted one) is structurally not optional anymore. It also makes the FileSystemProvider truely specific to the solution: it keeps the file system in a consistent state. There always is just one file: unencrypted or encrypted. Sounds like a persistent ADT to me.

#### [4c4efa6](https://github.com/deliberate-programming/rot13/commit/4c4efa6dd246f34adb1bbf7ae6ce4c7a2830a838), [9bb0d97](https://github.com/deliberate-programming/rot13/commit/9bb0d974b184c29b3f60de107dd2f5169ee5b99a)
My feeling is right: the FileSystemProvider is so simple, I get it right the first time.

After filling it and ROT13 into the RequestHandler the acceptance test goes green!

#### [8135808](https://github.com/deliberate-programming/rot13/commit/81358084acd7eeb59deb84b2cba9f4dc1e5b225d)
However I realize that the acceptance test has a flaw: it does not check if encryption results in only .encrypted files. I amend the test.

#### [4b7033e](https://github.com/deliberate-programming/rot13/commit/4b7033e349f740958f72fe7aa244cf45fb407554), [fd9](https://github.com/deliberate-programming/rot13/commit/fd93b36df9b1579fdbec11fcda981f898417089a), [a88](https://github.com/deliberate-programming/rot13/commit/a88bfb5bdaae4ca8c931992cc1c3a5af62d65432), [20a](https://github.com/deliberate-programming/rot13/commit/20a6d72b64bb468d4aadec72f1d844a4ec200658), [bbca863](https://github.com/deliberate-programming/rot13/commit/bbca8637b40d4b6a56986033ea0af10955362e41)
I set up the Display adapter. Very easy.

I set up the Config adapter. Also quite easy. I decide to return an enum from `Parse` to tell the command specified on the command line (instead of using an event). Using tuples that easy.

In [20a6d72](https://github.com/deliberate-programming/rot13/commit/20a6d72b64bb468d4aadec72f1d844a4ec200658)/[bbca863](https://github.com/deliberate-programming/rot13/commit/bbca8637b40d4b6a56986033ea0af10955362e41) I decide to introduce an `App` class for addition integration. (Forgot that during design.)

The App makes the whole program runnable. It actually works :-)

#### [de331ba](https://github.com/deliberate-programming/rot13/commit/de331ba41447a2385e39b9c0929528c976854058), [918cba1](https://github.com/deliberate-programming/rot13/commit/918cba107f72d4b8fcff081d2729bbca6cb509fd)
Finally some refactoring/clean-up.

### Increment 2: Decrypt
#### [160](https://github.com/deliberate-programming/rot13/commit/160d05236d1b4788a199c83ab3ba9fd79d823ab9), [3e4](https://github.com/deliberate-programming/rot13/commit/3e4791ce26e2c4a62b65f6d69a520b6ecb19278a)
First I implement an acceptance test for decryption. It just looks slightly different at the end for checking the files expected to be created.

The `CopyFiles` function is of great help here.

#### [9e7](https://github.com/deliberate-programming/rot13/commit/9e74c34bb5c0f7130addba7392ead3f828883d9b), [28c](https://github.com/deliberate-programming/rot13/commit/28cc2fdfc8d224ab9099d0b2bee047bd28cc4315)
I implement the changes necessary to `RequestHandler` and `FileSystemProvider`.

In passing I change a couple of non-public function names to better document the symmetry between encryption and decryption.

How to check the extensions in `SelectRelevantFiles` takes me a short, but noticable moment to decide:

* Pass in the extensions with a dot (".txt") or without ("txt")?
* Require them to be in lower case?
* Where to use an array for that vs a `HashSet`?

In the end I hide all these details in `SelectRelevantFiles` to burden its clients less.

#### [a03](https://github.com/deliberate-programming/rot13/commit/a0a3a34d4adb5e4fd02f0e39019498e1e1b92d2d)
After my changes to the `FileSystemProvider` I'm optimistic that decryption now works. But the acceptance test for encryption fails first.

I don't want to go down a debugging rabbit hole so I set up addition tests to narrow down on the reason.

####  [70e](https://github.com/deliberate-programming/rot13/commit/70e30cb7490afbaa614c1eea51b0b94e1e46d944)
First I single out source file enumeration. It fails.

#### [51e](https://github.com/deliberate-programming/rot13/commit/51e644501f98472a5cc715d00b056df04fa3b153)
I sense something is wrong with `SelectRelevantFiles` so I devise a scaffolding test for it.

In passing I set some methods to `static`. There is not state involved and they become easier to test.

#### [5fe](https://github.com/deliberate-programming/rot13/commit/5fe6b5b0b4d8afc8e506c78c1ca7558eb5a7910d)
The obvious error is that I'm checking the whole filename against relevant extensions. I need to extract just the extension from it.

Now finally I extract the details of how extensions are needed for comparion to its own function: `Normalize`. A local functionn is sufficient for that.

#### [fd1](https://github.com/deliberate-programming/rot13/commit/fd19b9d7bde3b8f9f1dfe50c485e4dcf7e75b78e), [6ad](https://github.com/deliberate-programming/rot13/commit/6ad3e2b21b12eca3c98499a909b09e91cf6d87b0) 
Yet more testing is needed. Something is still wrong.

#### [4b1](https://github.com/deliberate-programming/rot13/commit/4b1169dd1131615f75658d46da12bd21cec421ce)
Only after a while I realize I don't use `Path.GetExtension` correctly. It returns the extension with a leading dot - and I thought it was stripping it.

#### [a74](https://github.com/deliberate-programming/rot13/commit/a74e80e78b0592d6da234aec9c6a60b033712be3)
Still the acceptance test fails. I wrongly assumed the encrypted file samples were already at the place where I expected them, in the test project.

#### [931](https://github.com/deliberate-programming/rot13/commit/931ea5625fd9b5581326249e529e2205b2ae4f2a), [c52](https://github.com/deliberate-programming/rot13/commit/c52ffdf9e22e1d44206f07a416c694f393f66577)
Still, the decryption acceptance test fails. No files are generated, it seems.

The reason lies with `ReplaceTxtWithEncrypted` I suspect. Maybe the files get generated but then are wrongly deleted. I set up tests for the function.

#### [7a0](https://github.com/deliberate-programming/rot13/commit/7a098992e96dc5088f97b5136502909d488b93b8)
It turns out the function was incorrect all along. I just did not realize it incidentally during the acceptance test for encryption. The test did not check the full filenames reported.

The name of the file to store the en/decrypted text in needs to be explicitly built from the path of the source filename and its filename without the *.encrypted* extension.

#### [fcd](https://github.com/deliberate-programming/rot13/commit/fcd04db2928105ef2ab254b7009aa0d9b44c2e00)
Fixing the acceptance test for decrypt.

#### [9ed](https://github.com/deliberate-programming/rot13/commit/9edea3eefd01f4d4dcca5a46a7d6f1eb6cd10030), [1b1](https://github.com/deliberate-programming/rot13/commit/1b18029ad676e6ae410402e99ac8442f38ed4bc8)
Made decryption available from the command line.





