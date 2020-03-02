# LibAtem

This is the library for wokring with Blackmagic Design ATEM devices.

It is written for .Net Core 2.1 and has been tested on Windows and Linux (including Raspberry Pi)

Note: this is not yet complete, but existing functionality is stable and unlikely to undergo massive changes.

### Device support
This is known to work well with ATEM firmware 7.2 & 8.0, and is likely to work with others.

It has been primarily tested against the ATEM 2ME, with some additional testing against ATEM 1ME, ATEM 2ME 4K and TV Studio HD.

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


