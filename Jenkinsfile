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

        stage('Checkout Code Branch') {
            steps {
                script {
                    try {
                        echo 'Checking out code from the code branch...'
                        // Git-Befehl, um den Code aus dem 'code'-Branch auszuchecken
                        git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'code'
                    } catch (Exception e) {
                        echo "Git Checkout failed: ${e.getMessage()}"
                        error "Checkout from code branch failed"
                    }
                }
            }
        }

        stage('Build Application') {
            steps {
                echo 'Building the application...'
                // Beispielhafte Build-Logik für die Anwendung
                bat 'echo Build logic here'
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running tests...'
                // Beispielhafte Test-Logik
                bat 'echo Test logic here'
            }
        }

        stage('Deploy Application') {
            steps {
                echo 'Deploying application...'
                // Beispielhafte Deploy-Logik
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
