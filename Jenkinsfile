pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                echo 'Checking out code from the main branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'main'
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
                echo 'Deploying application to the test environment...'
                bat 'echo Deploy logic here'
            }
        }
    }

    post {
        always {
            echo 'Archiving build artifacts...'
            archiveArtifacts artifacts: '**/*', allowEmptyArchive: true
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed. Check the logs for more details.'
        }
    }
}
