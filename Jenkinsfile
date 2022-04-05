pipeline {
    agent any

    environment {
        MSBUILD = 'C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe'
        NUGET = 'C:\\Program Files (x86)\\NuGet\\nuget.exe'
        CONFIG = 'Release'
        PLATFORM = 'Any CPU'
        SLN_NAME = 'HolyWebi.sln'
    }

    stages {
        stage('Build') {
            steps {
                bat "\"${NUGET}\" restore ${SLN_NAME}"
                bat "\"${MSBUILD}\" ${SLN_NAME} /p:Configuration=${env.CONFIG};Platform=\"${env.PLATFORM}\" /maxcpucount:%NUMBER_OF_PROCESSORS% /nodeReuse:false"
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }

        }
    }
}
