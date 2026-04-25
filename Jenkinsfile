pipeline {
    agent { label 'windows' }

    environment {
        DOCKERHUB_USER  = 'your-dockerhub-username'
        IMAGE_NAME      = "${DOCKERHUB_USER}/dotnetapp"
        IMAGE_TAG       = "${BUILD_NUMBER}"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                dir('dotnetapp') {
                    bat 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('dotnetapp') {
                    bat 'dotnet build -c Release --no-restore'
                }
            }
        }

        stage('Publish') {
            steps {
                dir('dotnetapp') {
                    bat 'dotnet publish -c Release --no-build -o publish'
                }
            }
        }

        stage('Docker Build') {
            steps {
                dir('dotnetapp') {
                    bat "docker build -t %IMAGE_NAME%:%IMAGE_TAG% ."
                }
            }
        }

        stage('Docker Push') {
            steps {
                withCredentials([usernamePassword(
                    credentialsId: 'dockerhub-credentials',
                    usernameVariable: 'DOCKER_USER',
                    passwordVariable: 'DOCKER_PASS'
                )]) {
                    bat 'docker login -u %DOCKER_USER% -p %DOCKER_PASS%'
                    bat "docker push %IMAGE_NAME%:%IMAGE_TAG%"
                    bat "docker tag %IMAGE_NAME%:%IMAGE_TAG% %IMAGE_NAME%:latest"
                    bat "docker push %IMAGE_NAME%:latest"
                }
            }
        }
    }

    post {
        success {
            echo "Build ${BUILD_NUMBER} succeeded. Image: ${IMAGE_NAME}:${IMAGE_TAG}"
        }
        failure {
            echo "Build ${BUILD_NUMBER} failed."
        }
        cleanup {
            cleanWs()
        }
    }
}
