# th-hack-tools
Tools for hacking Fire Emblem: Three Houses

## Extracting contents

As of August 9 of 2019 there is no way of extracting contents of DATA1.bin with keeping the file structure intact - you will only get chunks but those are quite helpful to have at least some sort of structure. You can use QuickBMS and a script made for Musou Switch games for now.

Most of the interesting data is stored in `000000000000000c.dat` as this chunk stores a lot of tables with character data, skill data etc.

It's offset within Data0 is `10EA800` and the initial length is `83580C` - keep that in mind since this is the file my current modules will be compatible with. Once you are done you can just replace this giant block of data.

### character_skills.nmm

This module is for editing the skills that are bound to characters. Characters have an individual list of skills that they can learn once they reach a certain level in a category. You can change the categories as well as the level requirements and the associated skills. Each character possesses a personal skill as well, but not necessarily a timeskip skill. Timeskip skills are personal skills that will replace the personal skill once this point of the story was reached.

### character_stats.nmm

This module is for editing base stats, max stats, growths, crests and some additional data. Pretty much self-explanatory. There is however a little bit of data stored within character blocks that I haven't deciphered yet.
