pipeline {
			agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: []])
					}
				}
				stage('Build') {
    					steps {
    					    sh "'C:\Windows\Microsoft.NET\Framework\v2.0.50727/MSBuild.exe' WebHoly/WebHoly.sln /noautorsp /ds /nologo /t:clean,rebuild /p:Configuration=Debug /v:m /p:VisualStudioVersion=14.0 /clp:Summary;ErrorsOnly;WarningsOnly "
						//bat "\"${tool 'MSBuild'}\" WebHoly/WebHoly.sln /p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:SkipInvalidConfigurations=true /t:build /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DeleteExistingFiles=True /p:publishUrl=c:\\inetpub\\wwwroot"
    					}
				}
			}
}
