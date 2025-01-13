pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'lb324'
        DOCKER_TAG = 'latest'
        KUBE_NAMESPACE = 'monitoring'
    }

    stages {
        stage('Checkout Code') {
            steps {
                git branch: 'main', url: 'https://github.com/Hitz-and-Co/BodyBalance'
            }
        }

        stage('Build Backend') {
            steps {
                dir('Backend') {
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Run Tests') {
            steps {
                dir('Backend') {
                    bat 'dotnet test'
                }
            }
        }

        stage('Docker Build') {
            steps {
                dir('Backend') {
                    bat 'docker build -t %DOCKER_IMAGE%:%DOCKER_TAG% .'
                }
            }
        }

        stage('Deploy to Kubernetes') {
            steps {
                script {
                    // Docker-Image in Kubernetes registrieren
                    sh "kubectl apply -f deployment.yaml"

                    // Wenn Prometheus-Operator und ServiceMonitor verwendet werden:
                    sh "kubectl apply -f service-monitor.yaml"

                    // Die Anwendung deployen
                    sh "kubectl apply -f service.yaml"
                }
            }
        }
    }

    post {
        success {
            echo 'Pipeline erfolgreich abgeschlossen!'
        }
        failure {
            echo 'Pipeline fehlgeschlagen!'
        }
    }
}
