pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                echo 'Checking out code from the code branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'code'
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
                echo 'Deploying application...'
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
