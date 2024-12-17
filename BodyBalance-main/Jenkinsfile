pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'LB324'
        DOCKER_TAG = 'latest'
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

        stage('Build Frontend') {
            steps {
                dir('Frontend') {
                    bat 'npm install'
                    bat 'npm run build'
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
                bat 'docker build -t ${DOCKER_IMAGE}:${DOCKER_TAG} .'
            }
        }

        stage('Deploy to Test') {
            steps {
                bat 'docker run -d -p 8080:80 ${DOCKER_IMAGE}:${DOCKER_TAG}'
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
