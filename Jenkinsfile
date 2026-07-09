pipeline {
    agent any
    environment {
        DOTNET_CLI_HOME="C:\\Program Files\\dotnet"
    }
    stages {
        stage("Checkout") {
         steps {
               checkout scm
         }
        }
        stage("Restore") {
            steps {
                bat "dotnet restore"
            }
        }
        stage("Build") {
            steps {
                bat "dotnet build --configuration Release"
            }
        }
//         stage('SQL Test') {
//     steps {
//         bat 'whoami'
//         bat 'sqlcmd -S ABHIJEET-PC\\SQLEXPRESS -E -Q "SELECT DB_NAME()"'
//     }
// }
//         stage('Check SQL Connection') {
//     steps {
//         bat 'whoami'
//         bat 'sqlcmd -S ABHIJEET-PC\\SQLEXPRESS -E -Q "SELECT @@VERSION"'
//     }
// }
        stage("Test") {
            steps {
                bat "dotnet test --no-restore --configuration Release"
            }

        }
        
        stage("Publish") {
            steps {
                script {
                    bat "dotnet publish --no-restore --configuration Release --output .\\publish"
                }
            }
        }
        stage("Deployment") {
            steps {
                bat "del /q /s C:\\inetpub\\wwwroot\\WebAPIPipeline\\*"
                bat "xcopy /E /Y /I publish\\* C:\\inetpub\\wwwroot\\WebAPIPipeline\\"
            }
        }
    }
    post {
        success {
            echo "Build, Test and Publish stages completed successfully."
        }
    }
}