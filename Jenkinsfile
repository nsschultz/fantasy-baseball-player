pipeline {
  agent { label 'builder' }
  environment {
    def ver = readFile file: 'version.txt'
    VERSION_NUMBER = "${ver}"
    IMAGE_VERSION = "${GIT_BRANCH == "main" ? VERSION_NUMBER : VERSION_NUMBER+"-"+GIT_BRANCH}"
    DOCKER_HUB = credentials("dockerhub-creds")
  }
  stages {
		stage ('build and scan') {
			steps { script { sh  """
				#!/bin/bash
				sh _dev/scripts/ci.sh
			""" } } 
		}
		stage('build and publish release') { 
			steps { script { sh  """
				#!/bin/bash
				docker build -t nschultz/fantasy-baseball-player:${IMAGE_VERSION} .
				docker login -u ${DOCKER_HUB_USR} -p ${DOCKER_HUB_PSW}
				docker push nschultz/fantasy-baseball-player:${IMAGE_VERSION}
				docker logout
			""" } } 
		}
		stage('deploy') { 
			when { branch 'main' }
			agent { label 'manager' }
			steps { script { sh """
				#!/bin/bash
				sed -i "s/{{version}}/${VERSION_NUMBER}/g" ./_deploy/player-deployment.yaml
				kubectl apply -f ./_deploy/player-database-deployment.yaml
				kubectl apply -f ./_deploy/player-database-service.yaml
				kubectl apply -f ./_deploy/player-deployment.yaml
				kubectl apply -f ./_deploy/player-service.yaml
				kubectl apply -f ./_deploy/player-ingress.yaml
			""" } }
		}
	}
}