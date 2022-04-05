pipeline {
			agent any
			stages {
				stage('Build') {
    					steps {
    					    bat "\"${tool 'MSBuild'}\" HolyWebi.sln /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:SkipInvalidConfigurations=true /t:build /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DeleteExistingFiles=True "
    					}
				}
			}
}
