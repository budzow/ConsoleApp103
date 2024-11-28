SonarScanner.MSBuild.exe begin /k:"ConsoleApp103" /d:sonar.host.url="http://localhost:10000"  /d:sonar.verbose=true
MsBuild.exe /t:Rebuild /p:reportanalyzer=true /v:d
SonarScanner.MSBuild.exe end 
