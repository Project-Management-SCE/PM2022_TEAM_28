pipeline {
			agent any
			stages {
				stage('Source'){
					steps{
						checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false,
							  extensions: [], submoduleCfg: [],
							  userRemoteConfigs: [[credentialsId: 'jenkins-github-pats', url: 'https://github.com/Project-Management-SCE/PM2022_TEAM_28.git']]])
					}
				}
				stage('Build') {
    					steps {
						bat "\"${tool '15.0'}\" solution.sln /p:Configuration=Release /p:Platform=\"x86\"
        					} 
    					}
			}
}
