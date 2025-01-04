pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'lb324'
        DOCKER_TAG = 'latest'
        DOCKER_REGISTRY = 'docker.io'  // Beispiel für Docker Hub, anpassen je nach Registry
        DOCKER_USERNAME = 'damianmu07'
        DOCKER_PASSWORD = credentials('docker-hub-credentials')  // Docker Hub Credentials aus Jenkins-Settings
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
                    bat 'dotnet restore'
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Run Tests') {
            steps {
                dir('Backend') {
                    bat 'dotnet test --collect:"XPlat Code Coverage"'
                }
            }
        }

        stage('Docker Build') {
            steps {
                dir('Backend') {
                    bat 'docker build -t %DOCKER_REGISTRY%/%DOCKER_IMAGE%:%DOCKER_TAG% -f Backend/Dockerfile Backend'
                }
            }
        }

        stage('Push Docker Image') {
            steps {
                script {
                    // Login in Docker Hub
                    bat "echo %DOCKER_PASSWORD% | docker login --username %DOCKER_USERNAME% --password-stdin"

                    // Push Docker Image to Docker Hub
                    bat 'docker push %DOCKER_REGISTRY%/%DOCKER_IMAGE%:%DOCKER_TAG%'
                }
            }
        }

        stage('Deploy to Test') {
            steps {
                bat 'docker run -d -p 8081:80 %DOCKER_REGISTRY%/%DOCKER_IMAGE%:%DOCKER_TAG%'
            }
        }

        stage('Deploy to Kubernetes') {
            steps {
                script {
                    // Kubernetes Deployment und Service anwenden
                    bat 'kubectl apply -f k8s/deployment.yaml'
                    bat 'kubectl apply -f k8s/service.yaml'
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
