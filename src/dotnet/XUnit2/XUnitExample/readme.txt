# Overview

An XUnit2 project that contains a single passing test.

# Run from command-line

using the xunit.runner.console package

```
$xunitrunner = $env:UserProfile\.nuget\packages\xunit.runner.console\2.9.3\tools\net6.0
. $xunitrunner\xunit.console bin\Debug\net6.0\XUnitExample.dll -xml testresults.xml
```