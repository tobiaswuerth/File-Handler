# FileHandler
A program for plugin based file handling written in C# with .NET Framework 4.6.x.

**Goal?**
> Modify files based on their extension type.

## Plugins
- [x] Remove files *(configurable, \*.\*)*
- [X] UnZip, unzips non-password protected archives *(\*.zip)*
- [X] UnRar, extract WinRAR archives *(\*.rar)*
- [ ] Music Tagging, tag music files with [AcoustID](https://acoustid.org/) *(\*.mp3, ..)*
- [ ] Music Tag Sorting, sort files by their tags, e.g. `\<genre>\<album>\<artist>\<tracknr> - <track>` *(\*.mp3, ..)*
- [ ] FLAC to MP3, file conversion *(\*.flac)*
- [ ] Sorter, sort files into folders according to their type *(configurable, \*.\*)*

As you can see, I still got some ideas what plugins might be useful. **Any suggestions and submissions are welcome!**

## Settings
When you start the executable, you have the following options you can configure:

* Root directory
* Threads (up to 25)
* Plugins (only one per file extension, e.g. you cannot have two plugins handling \*.txt files)
* Recursion (directory crawler)
* Configuration for each enabled plugin
* Logging (Information, Warning, Error)
