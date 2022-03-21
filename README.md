# PresenceBridge
Controlls LED-Light through serial port and synchronizes with Teams Status.
The serial protocol is very simple and a Light such as the
[LyncDisplayLight](https://github.com/grafmar/LyncDisplayLight) can easily
be build up.


## Installation
* Download the latest zipped setup directory from the [Releases](https://github.com/grafmar/PresenceBridge/releases).
  * Unzip the file
  * Uninstall previous installed versions of PresenceBridge from within "Add or remove programs"
  * Execute setup.exe which installs it as application
* Plug the LyncDisplayLight device in.
* Start the PresenceBridge application from start menu
* In Taskbar look for the PresenceBridge-Symbol. Right-Click -> Settings -> set the device listed with `USB-SERIAL CH340` on the drop-down of the "PresenceLight's Serial Port". If no such device is available, check the next steps
  * Open *Device Manager* to check which serial port it uses (`USB-SERIAL CH340` in *Ports* section)
    * If the device is not recognized correctely you have to install the driver from http://www.arduined.eu/ch340-windows-8-driver-download/
* It should be possible to set the colors now by setting the states directly. To show active state choose SyncToTeams at the end.
* Click on Login to connect to your Teams
* To automatically start the application on windows startup:
  * From the start menu type LyncPresenceBridge and right-click on it. Choose *More* -> *Open File Location*
  * Copy the Application-Link-File
  * Type "Win"+R  and enter "shell:startup". This should open the Startup folder.
  * Paste the previous copied Application-Link-File to this Startup folder


## Connecting HW
The HW it is designed for is the [LyncDisplayLight](https://github.com/grafmar/LyncDisplayLight).
This is a RGB-LED with a display which can be controlled by the virtual serial port on its USB
connection.

The serial connection is configrued with 115200baud, 1 stop-bit, no parity. The commands used to
control the light are:

`rgb:255,255,0\n`

`callerid:John Doe\n`


## Configuration
<img src="Documentation/PresenceBridge_Configuration.png" alt="Configuration of PresenceBridge" width="30%"/> 

Any configuration made is directly active. To save the configuration for the next time starting the
application the save button has to be pressed. The stored configuration can be reload using the
reload button. This sets the configuration again from the config file.

### Serial Port
Everytime the dropdown list is shown the available ports are scaned and displayed. When selecting
another port it is directly used.

### LED colors
The colors shown on the LED-Light can be configured. To do so click on the color of the Availability
to configure.

### Brightness
withe the brightness slider the brightness of the LED-Light can be adapted for all colors from 0%
to 100%.

### Teams Connection
To connect to your Teams account click on `Login`. This will open a browser window to log in. To
logout click on `Logout`

## Author
[Marco Graf](https://github.com/grafmar)

## Credits / Attribution
* Partially used code from [Isaac Levin](https://github.com/isaacrlevin); [presencelight](https://github.com/isaacrlevin/presencelight)
