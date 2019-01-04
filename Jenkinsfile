pipeline {
    agent none
    parameters {
        string(name: 'PROJECT_KEY', defaultValue: 'AzureFunction.DI', description: 'ProjectKey for sonarqube.')
    }
    stages {
        stage('Build') {
            agent { label 'dotnetslave' }
            environment { 
                SONAR_LOGIN = credentials('sonarqube_login') 
            }
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh 'dotnet test ./AzureFunction.DI.Spec/AzureFunction.DI.Spec.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover --logger "nunit;LogFileName=AzureFunction.DI.Spec.xml" --results-directory ./testReports'
                    sh "dotnet sonarscanner begin /k:\"${params.PROJECT_KEY}\" /d:sonar.host.url=\"http://sonarqube:9000\" /d:sonar.login=\"${SONAR_LOGIN}\" /d:sonar.cs.opencover.reportsPaths=\"AzureFunction.DI.Spec/coverage.opencover.xml\" /d:sonar.coverage.exclusions=\"**Spec*.cs\""
                    sh 'dotnet build -c Release ./DI.sln'
                    sh "dotnet sonarscanner end /d:sonar.login=\"${SONAR_LOGIN}\""
                    nunit testResultsPattern: 'AzureFunction.DI.Spec/testReports/*.xml'
                    sh "dotnet pack AzureFunction.DI/AzureFunction.DI.csproj -c Release"
                    archiveArtifacts artifacts: 'AzureFunction.DI/bin/Release/AzureFunction.DI.*.nupkg', fingerprint: true
                }
            }
        }
    }
}