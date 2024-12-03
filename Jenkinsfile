pipeline {
    agent any

    stages {
        stage('Checkout Main Branch') {
            steps {
                script {
                    try {
                        echo 'Checking out code from the main branch...'
                        // Git-Befehl, um den Code aus dem 'main'-Branch auszuchecken
                        git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'main'
                    } catch (Exception e) {
                        echo "Git Checkout failed: ${e.getMessage()}"
                        error "Checkout from main branch failed"
                    }
                }
            }
        }

       

        stage('Build Application') {
            steps {
                echo 'Building the application...'
                bat 'echo Build logic here'

            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running tests...'
                bat 'echo Test logic here'
            }
        }

        stage('Deploy Application') {
            steps {
                echo 'Deploying application...'
                 bat 'echo Deploy logic here'
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished. Archiving logs and artifacts...'
            
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed. Please check the logs for details.'
        }
    }
}
