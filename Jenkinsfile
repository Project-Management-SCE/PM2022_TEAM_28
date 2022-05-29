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
        stage('Main Stage'){
               agent{
                      docker{
                             image 'mcr.microsoft.com/dotnet/sdk:5.0'
                      }
               }              
               stages{ 
                       stage('Restore'){
                         steps{
                             sh 'dotnet restore ./WebHoly/WebHoly.sln'
                          }
                       }
                      stage('Clean'){
                       steps{
                             sh 'dotnet clean ./WebHoly/WebHoly.sln --configuration Release'
                       }   
                      }
                      stage('Build'){             
                         steps{
                             sh 'dotnet build ./WebHoly/WebHoly.sln --configuration Release --no-restore'
                          }
                       }
                     stage('xUnit Test'){      
                         steps {
                              sh 'dotnet test ./WebHoly.Tests/WebHoly.Tests.csproj --configuration Release --no-restore'
                           }
                        }
                      stage('line&branches-covered'){
                               steps {
                                      sh 'cat WebHoly.Tests/TestResults/b3b05e96-f3bf-49a1-9b65-98dd17071d9d/coverage.cobertura.xml
                               }
                      }
               }
        }          
        stage('Deploy to Heroku') { 
               agent{
                      docker{
                            image 'cimg/base:stable'
                             args '-u root'
                      }
               }
           steps {
               sh '''
                   curl https://cli-assets.heroku.com/install.sh | sh;
                   heroku container:login
                   heroku container:push web --app web-holy
                   heroku container:release web --app web-holy
               '''
           }
       }
    }
} 
