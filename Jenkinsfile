pipeline {
    agent any  // Dies stellt sicher, dass die gesamte Pipeline auf einem beliebigen verfügbaren Agenten ausgeführt wird

    stages {
        stage('Checkout Main Branch') {
            steps {
                script {
                    try {
                        echo 'Checking out code from the main branch...'
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
                script {
                    try {
                        echo 'Building the application with Maven...'
                        bat "${MAVEN_HOME}/bin/mvn clean package -DskipTests"
                    } catch (Exception e) {
                        echo "Build failed: ${e.getMessage()}"
                        error "Build failed"
                    }
                }
            }
        }

        stage('Run Tests') {
            steps {
                script {
                    try {
                        echo 'Running tests...'
                        bat "${MAVEN_HOME}/bin/mvn test"
                        junit '**/target/surefire-reports/*.xml'
                    } catch (Exception e) {
                        echo "Tests failed: ${e.getMessage()}"
                        error "Tests failed"
                    }
                }
            }
        }

        stage('Deploy Application') {
            steps {
                script {
                    try {
                        echo 'Deploying application to the test server...'
                        bat 'scp target/app.war user@test-server:/path/to/deploy'
                    } catch (Exception e) {
                        echo "Deployment failed: ${e.getMessage()}"
                        error "Deployment failed"
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished. Archiving logs and artifacts...'
            archiveArtifacts artifacts: '**/target/*.war', fingerprint: true
            junit '**/target/surefire-reports/*.xml'
        }

        success {
            echo 'Pipeline completed successfully.'
            // Beispiel für Benachrichtigung bei Erfolg (z.B. Slack, Email)
            notifySuccess()
        }

        failure {
            echo 'Pipeline failed. Please check the logs for details.'
            // Benachrichtigung bei Fehlschlägen (z.B. Slack, Email)
            notifyFailure()
        }
    }
}
