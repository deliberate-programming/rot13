# ROT13 Encryptor
## Analysis (ca. 30min)
A program needs to be written. A console application.

![](images/system-context.png)

Technologies are simple.

### ROT13
A simple mapping algorithm: a source character is mapped to/replaced by another character.

![](images/rot13.png)

(from [Wikipedia](https://en.wikipedia.org/wiki/ROT13))

Both encryption and decryption map an *input* character to an *output* character in the above table. Example:

```
a.txt: Hello!

H->U
e->r
l->y
o->b

a.txt.encrypted: Uryyb!

U -> H
r -> e
y -> l
b -> o
```

Characters not found in the map are not en/decrypted, e.g. `CR`, `LF`, `TAB`, special characters like `.`, `!`. That means the basic structure of a source file is retained.

### Acceptance test
A much as possible should be tested automatically. Sample files are provided. They can be used as sources and gold masters for an acceptance test.

![](images/samples.png)

![](images/samples2.png)

Functions to test:

```
int Encrypt(IEnumerable<string> sources, Action<string> onProcessed)
int Decrypt(IEnumerable<string> sources, Action<string> onProcessed)
```

These functions cover the main work to do. The file/folder names given on the command line are passed in as `sources`. And the name of each file processed is pushed to the continuation `onProcessed`.

Displaying the names of the processed files should be easy "to wrap around". The number of files processed is returned as the result of executing these "commands".

![](images/message_handling.png)

