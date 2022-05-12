pipeline {
       agent none
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        }
    triggers {
    	 pollSCM 'H * * * *'
        githubPush()
    }
    stages {                  
        stage('Restore packages'){
            agent{
                docker{
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                }
            }      
            steps{
                sh 'dotnet restore ./WebHoly/WebHoly.sln'
            }
        }
        stage('Clean'){
            agent{
                docker{
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                    }
               }      
            steps{
                sh 'dotnet clean ./WebHoly/WebHoly.sln --configuration Release'
            }   
        }
        stage('Build'){ 
            agent{
                docker{
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                    }
               }                  
            steps{
                 sh 'dotnet build ./WebHoly/WebHoly.sln --configuration Release --no-restore'
            }
        }
        stage('Tests: xUnit Test'){     
            agent{
                docker{
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                    }
            }           
            steps {
                sh 'dotnet test ./WebHoly.Tests/WebHoly.Tests.csproj --configuration Release --no-restore'
            }
       }
    }
}
