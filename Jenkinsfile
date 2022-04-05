pipeline {
			agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], 
							  doGenerateSubmoduleConfigurations: false, extensions: [],
							  submoduleCfg: [], userRemoteConfigs:[[url: 'http://147.234.32.36/job/Team_28/job/https/']] ])
					}
				}
				stage('Build') {
    					steps {
    					    bat "\"${tool 'MSBuild'}\" HolyWebi.sln /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:SkipInvalidConfigurations=true /t:build /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DeleteExistingFiles=True "
    					}
				}
			}
}
