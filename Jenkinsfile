pipeline {
    agent any

    environment {
        FRONTEND_REPO = 'https://github.com/Hitz-and-Co/BodyBalance/tree/Frontend'
        FRONTEND_BRANCH = 'frontend-branch'
        BACKEND_REPO = 'https://github.com/Hitz-and-Co/BodyBalance/tree/Backend'
        BACKEND_BRANCH = 'backend-branch'
    }

 stage('Checkout Frontend') {
    steps {
        echo 'Checking out the frontend branch...'
        dir('frontend') { // Separates Arbeitsverzeichnis für das Frontend
            git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'Frontend'
        }
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

        stage('Checkout Backend') {
    steps {
        echo 'Checking out the backend branch...'
        dir('backend') { // Separates Arbeitsverzeichnis für das Backend
            git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'Backend'
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
