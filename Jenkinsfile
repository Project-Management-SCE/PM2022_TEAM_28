node('win-slave-node') {
  def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'

  stage('Checkout') {
    checkout scm
  }

  stage('Build') {
    bat "${msbuild} WebHoly/WebHoly.sln"
  }
}
