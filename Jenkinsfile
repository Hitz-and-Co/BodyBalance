pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'github-credentials', branch: 'main', url: 'https://github.com/benutzer/repository.git'
            }
        }
    }
}
