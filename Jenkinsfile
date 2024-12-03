pipeline {
    agent any

    triggers {
        // Automatisches Auslösen eines Builds bei jedem Push in das Repository
        githubPush()
    }

    environment {
        // Umgebungsvariablen für den Build-Prozess, z. B. für Maven
        MAVEN_HOME = tool name: 'Maven 3.6.3', type: 'ToolLocation'
    }

    stages {
        stage('Checkout Main Branch') {
            steps {
                script {
                    try {
                        echo 'Checking out code from the main branch...'
                        // Git-Checkout vom 'main'-Branch
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
                        // Maven Build-Befehl
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
                        // Maven-Test-Befehl
                        bat "${MAVEN_HOME}/bin/mvn test"
                        // JUnit-Bericht sammeln
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
                        // Beispiel für das Deployment (nehmen wir an, es wird eine WAR-Datei verwendet)
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
            // Log-Dateien und Artefakte archivieren
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

// Beispiel für eine Benachrichtigungsfunktion bei Erfolg
def notifySuccess() {
    echo "Notifying success to Slack/Email/Other..."
    // Hier könnte z.B. eine Benachrichtigung an Slack gesendet werden
    // Beispiel für Slack-Benachrichtigung:
    // slackSend channel: '#build-status', color: 'good', message: 'Build succeeded!'
}

// Beispiel für eine Benachrichtigungsfunktion bei Fehlern
def notifyFailure() {
    echo "Notifying failure to Slack/Email/Other..."
    // Hier könnte z.B. eine Benachrichtigung an Slack gesendet werden
    // Beispiel für Slack-Benachrichtigung:
    // slackSend channel: '#build-status', color: 'danger', message: 'Build failed!'
}
