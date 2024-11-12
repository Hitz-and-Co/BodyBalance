pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                // Code aus dem Git-Repository abrufen
                git url: 'https://github.com/Hitz-and-Co/BodyBalance.git', branch: 'main'
            }
        }
        
        stage('Test') {
            steps {
                // Beispiel: Test-Suite ausführen
                bat 'echo "Running tests..."'
                // Zum Beispiel: bat 'mvn test' für ein Maven-basiertes Projekt
            }
        }
        
        stage('Build') {
            steps {
                // Beispiel: Build-Befehl ausführen
                bat 'echo "Building project..."'
                // Zum Beispiel: bat 'mvn package' für ein Maven-basiertes Projekt
            }
        }
        
        stage('Deploy') {
            steps {
                // Beispiel: Bereitstellungsskript ausführen
                bat 'echo "Deploying to test environment..."'
                // Hier könnte ein Deploy-Skript aufgerufen werden, z. B. bat './deploy.bat'
            }
        }
    }
    
    post {
        always {
            // Log speicher und Berichterstellung
            archiveArtifacts artifacts: '**/target/*.jar', allowEmptyArchive: true
        }
        success {
            echo 'Pipeline completed successfully.'
        }
        failure {
            echo 'Pipeline failed.'
        }
    }
}
