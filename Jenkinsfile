pipeline {
    agent any
     triggers {
        githubPush()
      }
    stages {
        stage('Restore packages'){
           steps{
               sh 'dotnet restore WebHoly/WebHoly.sln'
            }
         }        
        stage('Clean'){
           steps{
               sh 'dotnet clean WebHoly/WebHoly.sln --configuration Release'
            }
         }
        stage('Build'){
           steps{
               sh 'dotnet build WebHoly/WebHoly.sln --configuration Release --no-restore'
            }
         }
        stage('Test: Unit Test'){
           steps {
                sh 'dotnet test WebHoly.Tests/WebHoly.Tests.csproj --configuration Release --no-restore'
             }
          }
        stage('Publish'){
             steps{
               sh 'dotnet publish WebHoly/WebHoly.csproj --configuration Release --no-restore'
             }
        }
       
        }        
    }
}
