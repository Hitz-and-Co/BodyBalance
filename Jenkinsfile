pipeline {
    agent any

    environment {
        GIT_REPO = 'https://github.com/Hitz-and-Co/BodyBalance'
        GIT_BRANCH = 'main'
        BUILD_SCRIPT = 'build_script.bat' // Beispiel für ein externes Build-Skript
        TEST_SCRIPT = 'test_script.bat'  // Beispiel für ein externes Test-Skript
    }

    stages {
        stage('Checkout Code') {
            steps {
                script {
                    try {
                        echo 'Checking out code from branch: ${GIT_BRANCH}...'
                        git url: GIT_REPO, branch: GIT_BRANCH
                    } catch (Exception e) {
                        error "Failed to checkout code: ${e.getMessage()}"
                    }
                }
            }
        }

        stage('Build Application') {
            steps {
                script {
                    try {
                        echo 'Building the application...'
                        bat "${BUILD_SCRIPT}" // External build script for better separation
                    } catch (Exception e) {
                        error "Build failed: ${e.getMessage()}"
                    }
                }
            }
        }

        stage('Run Tests') {
            steps {
                script {
                    try {
                        echo 'Running tests...'
                        bat "${TEST_SCRIPT}" // External test script for flexibility
                    } catch (Exception e) {
                        error "Tests failed: ${e.getMessage()}"
                    }
                }
            }
        }

        stage('Deploy Application') {
            steps {
                script {
                    try {
                        echo 'Deploying application...'
                        bat 'deploy_script.bat' // Beispiel für ein externes Deployment-Skript
                    } catch (Exception e) {
                        error "Deployment failed: ${e.getMessage()}"
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Cleaning up resources...'
            // Beispiel: Aufräumen von temporären Dateien oder Logs
        }
        success {
            echo 'Pipeline completed successfully!'
            // Optional: Benachrichtigung bei Erfolg
            script {
                notify("Pipeline successful: ${env.JOB_NAME} #${env.BUILD_NUMBER}")
            }
        }
        failure {
            echo 'Pipeline failed. Please check the logs for more information.'
            // Optional: Benachrichtigung bei Fehler
            script {
                notify("Pipeline failed: ${env.JOB_NAME} #${env.BUILD_NUMBER}")
            }
        }
    }
}

// Benachrichtigungsfunktion
def notify(String message) {
    // Beispiel für E-Mail- oder Chat-Benachrichtigung
    echo "Sending notification: ${message}"
    // Hier könnten Schritte wie 'mail' oder 'slackSend' eingebaut werden
}
