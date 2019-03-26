# ROT13 Encryptor
Write a program to encrypt (and decrypt) files with the ROT 13 algorithm.

The program will be run from the command line, e.g.

```
$ rot13 encrypt /a /b/x.txt /c/d/y.md z.txt
/a/f.txt
/a/g.txt
/a/a1/h.txt
/b/x.txt
/c/d/y.md
z.txt
6 files encrypted
$
```

Whether to `encrypt` or `decrypt` is stated by the first parameter, the command.

Which files to encrypt is specified by listing filenames or folder names. Folders are recursively processed. All relevant files are encrypted in a folder tree.

Relevant files for `encrypt` are those with the extension *.txt* or *.md*.

The names of the files encrypted are logged to stdout. And at the end the number of files processed is written.

Encrypted files are placed next to their source files and retain their name, but the extension *.encrypted* is added, e.g. *a.txt* becomes *a.txt.encrypted*.

Relevant files for `decrypt` are those with the extension *.encrytped*

Source files will be deleted after encryption.

Decrypted files overwrite existing files with the same name.

The *sample* folder provides both unencrypted as well as encrypted files as expected to be produced by the program.

## References

* Wikipedia, ROT13, [https://en.wikipedia.org/wiki/ROT13](https://en.wikipedia.org/wiki/ROT13)
* ROT13 online service, [http://decode.org](http://decode.org)