pipeline {
    agent any

    environment {
        PROJECT_REPO = 'https://github.com/Hitz-and-Co/BodyBalance'
        BRANCH = 'main'
        ARTIFACT_DIR = 'target'
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out the project...'
                git url: env.PROJECT_REPO, branch: env.BRANCH
            }
        }

        stage('Install Dependencies') {
            steps {
                echo 'Installing project dependencies...'
                // Beispiel: Falls ein Node.js-Frontend und ein Java-Backend verwendet wird:
                bat '''
                    cd frontend && npm install
                    cd ../backend && mvn clean install
                '''
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running automated tests...'
                // Beispiel: Frontend- und Backend-Tests ausführen
                bat '''
                    cd frontend && npm test
                    cd ../backend && mvn test
                '''
            }
        }

        stage('Build Application') {
            steps {
                echo 'Building the application...'
                // Beispiel: Build für Frontend und Backend
                bat '''
                    cd frontend && npm run build
                    cd ../backend && mvn package
                '''
            }
        }

        stage('Static Code Analysis') {
            steps {
                echo 'Running static code analysis...'
                // Beispiel: Verwendung von Tools wie SonarQube oder ESLint
                bat '''
                    cd frontend && npm run lint
                    cd ../backend && mvn sonar:sonar
                '''
            }
        }

        stage('Deploy to Test Environment') {
            steps {
                echo 'Deploying application to the test environment...'
                // Beispiel: Deployment in ein Docker-Container-basiertes Testsystem
                bat '''
                    docker-compose -f docker-compose-test.yml up -d
                '''
            }
        }
    }

    post {
        always {
            echo 'Archiving build artifacts...'
            archiveArtifacts artifacts: "${ARTIFACT_DIR}/**/*.jar", allowEmptyArchive: true
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed. Check the logs for more details.'
        }
    }
}
