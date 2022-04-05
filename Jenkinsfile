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
						script {
          						def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
         					 	bat "${msbuild} HolyWebi.sln"
        } 
    					}
				}
			}
}
