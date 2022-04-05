pipeline {
			agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], 
							  doGenerateSubmoduleConfigurations: false, extensions: [],
							  submoduleCfg: [], userRemoteConfigs:[[url: 'https://github.com/Project-Management-SCE/PM2022_TEAM_28.git]]])
					}
				}
				stage('Build') {
    					steps {
    					    bat "\"${tool 'MSBuild'}\" HolyWebi.sln /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:SkipInvalidConfigurations=true /t:build /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DeleteExistingFiles=True "
    					}
				}
			}
}
