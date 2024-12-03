pipeline {
    agent any
    tools {
        maven 'maven'  // Der Name, den Sie in der Konfiguration vergeben haben
    }
    stages {
        stage('Build') {
            steps {
                bat 'mvn clean install'  // Ein Beispiel für den Maven-Befehl
            }
        }
    }
}
