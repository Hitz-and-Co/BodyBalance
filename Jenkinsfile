pipeline {
    agent any

    stages {
        stage('Checkout Main Branch') {
            steps {
                echo 'Checking out code from the main branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'main'
            }
        }

        stage('Checkout Code Branch') {
            steps {
                echo 'Checking out code from the code branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'code'
            }
        }

        stage('Build Application') {
            steps {
                echo 'Building the application...'
                bat 'mvn clean package'
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running tests...'
                bat 'mvn test'
                junit '**/target/surefire-reports/*.xml'
            }
        }

        stage('Deploy Application') {
            steps {
                echo 'Deploying application...'
                bat 'scp target/app.war user@test-server:/path/to/deploy'
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished. Archiving logs and artifacts...'
            archiveArtifacts artifacts: '**/target/*.war', fingerprint: true
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed. Please check the logs for details.'
        }
    }
}
