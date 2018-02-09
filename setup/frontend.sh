DOCKERPULL=`docker pull ivanpaulovich/acerola:latest-frontend`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
	docker stop acerola-frontend
	docker rm acerola-frontend
	docker run -p 8001:80 -d \
		--name acerola-frontend \
		ivanpaulovich/acerola:latest-frontend
fi