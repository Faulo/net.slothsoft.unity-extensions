pipeline {
	agent {
		label 'npm'
	}
	environment {
		BRANCH_NAME = 'main'
		UNITY_EMPTY_MANIFEST = '.jenkins/manifest.json'
	}
	stages {
		stage('Linux') {
			steps {
				script {
					unityPackage(
							// Define Unity package location relative to repository.
							PACKAGE_LOCATION : '',
							UNITY_NODE : 'unity && linux',

							// Assert that CHANGELOG.md has been updated.
							TEST_CHANGELOG : '1',
							CHANGELOG_LOCATION : 'CHANGELOG.md',

							// Assert Unity's Test Runner tests.
							TEST_UNITY : '1',
							TEST_MODES : 'EditMode PlayMode',

							// Assert that the C# code of the package matches the .editorconfig.
							TEST_FORMATTING : '1',
							EDITORCONFIG_LOCATION : '.jenkins/.editorconfig',

							// Deploy the package to a Verdaccio server.
							DEPLOY_TO_VERDACCIO : '0',
							VERDACCIO_URL : 'http://verdaccio',
							VERDACCIO_CREDENTIALS : 'Slothsoft-Verdaccio',
							)
				}
			}
		}
		stage('Windows') {
			steps {
				script {
					unityPackage(
							// Define Unity package location relative to repository.
							PACKAGE_LOCATION : '',
							UNITY_NODE : 'unity && windows',

							// Assert that CHANGELOG.md has been updated.
							TEST_CHANGELOG : '1',
							CHANGELOG_LOCATION : 'CHANGELOG.md',

							// Assert Unity's Test Runner tests.
							TEST_UNITY : '1',
							TEST_MODES : 'EditMode PlayMode',

							// Assert that the C# code of the package matches the .editorconfig.
							TEST_FORMATTING : '1',
							EDITORCONFIG_LOCATION : '.jenkins/.editorconfig',

							// Deploy the package to a Verdaccio server.
							DEPLOY_TO_VERDACCIO : '1',
							VERDACCIO_URL : 'http://verdaccio',
							VERDACCIO_CREDENTIALS : 'Slothsoft-Verdaccio',
							)
				}
			}
		}
	}
}