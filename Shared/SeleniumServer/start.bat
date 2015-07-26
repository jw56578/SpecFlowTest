REM Step 1 - Start selenium server as a hub with settings contained in hub.json.
START java -jar selenium-server-standalone-2.39.0.jar -role hub -hubConfig hub.json

REM Step 2 - Start selenium server as a node.  We pass in the driver paths for chrome, ie, and firefox. These can also be PATH entries on each node.
REM The node.json config has the settings for connecting to the hub, and can reside on an entirely different machine.
START java -jar selenium-server-standalone-2.39.0.jar -role node -nodeConfig node.json -Dwebdriver.chrome.driver="C:\Projects\Self Serve\Website\WebDrivers\chromedriver.exe" -Dwebdriver.ie.driver="C:\Projects\Self Serve\Website\WebDrivers\IEDriverServer32.exe" -Dwebdriver.firefox.bin="C:\Program Files (x86)\Mozilla Firefox\firefox.exe"