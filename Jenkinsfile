pipeline {
		agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false,
							  extensions: [], submoduleCfg: [],
							  userRemoteConfigs: [[credentialsId: 'jenkins-github-pats',
									       url: 'https://github.com/Project-Management-SCE/PM2022_TEAM_28.git']]])
					}
				}
				stage('Build') {
    					steps {
						stage('App_Build'){ steps{ tool name: 'MsBuild', type: 'msbuild' bat ""${tool 'MsBuild'}"HolyWebi.sln /t:Rebuild /p:Configuration=Release" } }        					} 
    					}
			
			}
}
