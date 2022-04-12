node {
    stage("Checkout") {
        deleteDir()
        checkout scm
    }
    stage("Build") {
        bat "\"${tool 'MSBuild'}\" ${params.Solution}/${params.Solution}.sln /m /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        archiveArtifacts "**/bin/Release/*.*"              
    }
}
