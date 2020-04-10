# LibAtem

This is the library for working with Blackmagic Design ATEM devices.

It is written for .Net Core 3.0 and has been tested on Windows and Linux (including Raspberry Pi)

Note: this is not yet complete, but existing functionality is stable and unlikely to undergo massive changes.

### Device support
The primary focus is to support 8.0+ fully. Older versions may work, but are no longer recommended.
7.2 should work pretty well, but is not feature complete.

It has been primarily tested against the ATEM 2ME and Mini, with some additional testing against ATEM 1ME, ATEM 2ME 4K, TV Studio HD and Constellation.

Note: In order to properly support multiple versions, some versions introduce newer versions of some command classes.

### Download
Coming soon


### Usage
Coming soon

#### Missing functionality
* Some MacroOperations (ones without a value in [LibAtem/Common/MacroOperationType.cs] )
* Much of audio mixer
* Camera control
* More...

### Related Projects
* ATEM Client comparison tests [LibAtem.ComparisonTests](https://github.com/LibAtem/LibAtem.ComparisonTests)

### Credits
This builds on the work done by the following projects:
* http://skaarhoj.com/fileadmin/BMDPROTOCOL.html
* https://github.com/peschuster/wireshark-atem-dissector

### License

LibAtem is distributed under the GNU Lesser General Public License LGPLv3 or higher, see the file LICENSE for details.


