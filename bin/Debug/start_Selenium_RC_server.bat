@ECHO OFF

SET SELENIUM_RC=%CD%
DEL selenium.log
ECHO.
ECHO.
ECHO.
ECHO.
ECHO.
ECHO. -------------------START THE SELENIUM RC SERVER-------------------
ECHO.
ECHO.
ECHO.
ECHO.
ECHO.

IF "%browser%"=="IE" GOTO IE_Settings
IF "%browser%"=="FF" GOTO FireFox_Settings

:IE_Settings
ECHO.
java -jar %SELENIUM_RC%\selenium-server.jar -forcedBrowserMode *iehta -trustAllSSLCertificates -log selenium.log
ECHO. DONE.

:FireFox_Settings
CD..
SET dir=%CD%
ECHO. %dir%
java -jar %SELENIUM_RC%\selenium-server.jar -singleWindow -forcedBrowserMode *chrome -firefoxProfileTemplate %dir%\Selenium_Firefox_Profile2  -log selenium.log
ECHO. DONE.

EXIT