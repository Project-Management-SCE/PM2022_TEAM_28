pipeline {
  agent { 
  }
  stages {
    stage('Build') {
      steps {
        script {
          def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
          bat "${msbuild} WebHoly/WebHoly.sln"
        } 
      } 
    } 
  } 
} 
