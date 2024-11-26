pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                echo 'Checking out code from the main branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'main'
            }
        }

        stage('Install Frontend Dependencies') {
            steps {
                echo 'Installing frontend dependencies...'
                dir('frontend') {
                    bat 'npm install'
                }
            }
        }

        stage('Build Frontend') {
            steps {
                echo 'Building the frontend...'
                dir('frontend') {
                    bat 'npm run build'
                }
            }
        }

        stage('Install Backend Dependencies') {
            steps {
                echo 'Installing backend dependencies...'
                dir('backend') {
                    bat 'mvn clean install'
                }
            }
        }

        stage('Run Backend Tests') {
            steps {
                echo 'Running backend tests...'
                dir('backend') {
                    bat 'mvn test'
                }
            }
        }

        stage('Build Backend') {
            steps {
                echo 'Building the backend...'
                dir('backend') {
                    bat 'mvn package'
                }
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
            dir('backend') {
                archiveArtifacts artifacts: 'target/**/*.jar', allowEmptyArchive: true
            }
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed. Check the logs for more details.'
        }
    }
}
