# Nightmare Modules
Nightmare Modules for hacking Fire Emblem: Three Houses

## Extracting contents

Those are nightmare modules used before the release of the hacking toolkit.

If you are using QuickBMS with the Arslan script you can use them with `000000000000000c.dat`.

Otherwise you could open Data1, go to offset `10EA800` and copy a block with the length of `83580C` to extract that file manually.

After making changes you just replace the area with the changed data.

### character_skills.nmm

This module is for editing the skills that are bound to characters. Characters have an individual list of skills that they can learn once they reach a certain level in a category. You can change the categories as well as the level requirements and the associated skills. Each character possesses a personal skill as well, but not necessarily a timeskip skill. Timeskip skills are personal skills that will replace the personal skill once this point of the story was reached.

### character_stats.nmm

This module is for editing base stats, max stats, growths, crests and some additional data. Pretty much self-explanatory. There is however a little bit of data stored within character blocks that I haven't deciphered yet.

### character_spells.nmm

This module is for editing spell lists of characters. Still have to figure out how to change the necessary ranks as well though.
