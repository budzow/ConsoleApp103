Simple repo to show how custom configuration of SAST engine allows to raise injection rule on private/custom method. Under _Project Settings/General Settings/SAST Engine_ of SonarQube project:
```
{
    "S3649": {
        "sources": [
            {
                "methodId": "Test.UnknownAPI.getCategory()"
            }
        ]
    }
}
```
according to doc: https://docs.sonarsource.com/sonarqube-server/latest/analyzing-source-code/security-engine-custom-configuration/
