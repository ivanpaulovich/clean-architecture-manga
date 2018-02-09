DOCKERPULL=`docker pull ivanpaulovich/acerola:latest`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
	docker stop acerola-backend
	docker rm acerola-backend
	docker run -p 8000:80 \
		-e modules__0__properties__ConnectionString=mongodb://172.17.0.1:27017 \
		-e modules__1__properties__ConnectionString=mongodb://172.17.0.1:27017 \
		-d \
		--name acerola-backend \
		ivanpaulovich/acerola:latest
fi