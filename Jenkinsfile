pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'github-credentials', branch: 'main', url: 'https://github.com/Hitz-and-Co/BodyBalance.git'
            }
        }
    }
}
