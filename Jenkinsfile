pipeline {
  agent any
    stage('Build') {
      steps {
        bat 'HolyWebi build HolyWebi.sln'
      }
    }
    stage('Test') {
      steps {
	      bat 'HolyWebi test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover ./HolyWebiTest/HolyWebiTest.csproj --logger "trx;LogFileName=TestResult.trx"'
        bat 'reportgenerator "-reports:./HolyWebiTest/coverage.opencover.xml" "-targetdir:CoverageReport"'
	    }     
    }
    stage('Publish') {
      steps {
        bat 'dotnet publish ./HolyWebi/HolyWebi.csproj -c Release -o C:/JenkinsBuilds/'+env.JOB_NAME+'/'+env.BUILD_NUMBER
      }
    }
  }
  post { 
    success {
      publishHTML (target: [allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: './CoverageReport', reportFiles: 'index.htm', reportTitles: "CodeCoverageReport", reportName: "Code Coverage Report", includes: '**/*', escapeUnderscores: true])
      step([$class: 'MSTestPublisher', testResultsFile:'**/TestResult.trx', failOnError: true, keepLongStdio: true])
      cleanWs()
    }
  }
}
