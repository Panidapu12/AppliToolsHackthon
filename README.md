# AppliToolsHackthon
Please follow below steps for a successfull execution of the suite.
1. Resolve all nuget pacakage dependencies
2. If you are using visual studio, install latest version of Nunit addon
3. Build the solution
4. You should see list of tests available in Test Explorer
5. Run tests from TraditionalTests.cs for traditional test case validation
6. Run tests from VisualAITests.cs to validate tests with applitools
7. Default the tests are configured to run on V2 version of applications
8. To run in "V1", change the hardcoded value under Setup folder -> Setup Class -> beforeTest method
    modify below steps
     configuration.configureEnvForTests("V2"); ->  configuration.configureEnvForTests("V1");
     configuration.configureEnvForTests("AddV2"); -> configuration.configureEnvForTests("AddV1");
     and rebuild the solution.
9. You can follow from step no - 4 to rerun the tests.
