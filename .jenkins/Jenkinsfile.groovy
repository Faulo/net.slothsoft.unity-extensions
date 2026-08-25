unityPackagePipeline {
    PUBLISH_AGENT = 'Mörkö'
    
    TEST_CHANGELOG = true
	
    TEST_FORMATTING = true
    FORMATTING_LOCATION = '.jenkins/.editorconfig'
	
    TEST_UNITY = true
    UNITY_AGENTS = [Linux: 'linux && compose-unity', Windows: 'windows && compose-unity']
    UNITY_MANIFEST_LOCATION = '.jenkins/manifest.json'
    UNITY_CREDENTIALS = 'Slothsoft-Unity'
    EMAIL_CREDENTIALS = 'Slothsoft-Google'
	
    BUILD_DOCUMENTATION = true
	
    PUBLISH_TO_VERDACCIO = true
	VERDACCIO_CREDENTIALS = 'Slothsoft-Verdaccio'
    
    REPORT_TO_DISCORD = true
    DISCORD_WEBHOOK = 'https://discord.com/api/webhooks/1373701986595242065/7wrfu3LC2PdnwE0J3AvgD8YNYV6IirB6WZZZ2sNZLdmZ6iIcO66gQDg2WqHL4lKmw4S3'
}