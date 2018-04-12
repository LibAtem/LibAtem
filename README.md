# LibAtem

[![Build Status](https://travis-ci.org/LibAtem/LibAtem.svg?branch=master)](https://travis-ci.org/LibAtem/LibAtem)

This is the library for connecting with Blackmagic Design ATEM devices.

It is written for .Net Core 2.0 and has been tested on Windows and Linux (including Raspberry Pi)

Note: this is not yet complete, but existing functionality is stable and unlikely to undergo massive changes.

### Device support
This is known to work well with ATEM firmware 7.2, and is likely to work with others.

It has been primarily tested against the ATEM 1ME, with some additional testing against ATEM 2ME 4K and TV Studio HD.

### Download
Coming soon


### Usage
Coming soon

#### Missing functionality
* Media pool commands
* Some MacroOperations (ones without a value in [LibAtem/Common/MacroOperationType.cs] )
* Much of audio mixer
* Camera control
* More...

### Related Projects
* ATEM Client XML Parsing [LibAtem.XmlState](https://github.com/LibAtem/LibAtem.XmlState)
* ATEM Client profile helper [LibAtem.DeviceProfile](https://github.com/LibAtem/LibAtem.DeviceProfile)
* ATEM Client comparison tests [LibAtem.ComparisonTests](https://github.com/LibAtem/LibAtem.ComparisonTests)

### Credits
This builds on the work done by the following projects:
* http://skaarhoj.com/fileadmin/BMDPROTOCOL.html
* https://github.com/peschuster/wireshark-atem-dissector

### License

LibAtem is distributed under the GNU Lesser General Public License LGPLv3 or higher, see the file LICENSE.md for details.


