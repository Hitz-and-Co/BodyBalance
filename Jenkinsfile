pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                echo 'Checking out code from the main branch...'
                git url: 'https://github.com/Hitz-and-Co/BodyBalance', branch: 'main'
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
