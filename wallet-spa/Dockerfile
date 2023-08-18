FROM node:18-alpine

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app

ARG ENV
ENV ENV ${ENV}

# --no-cache: download package index on-the-fly, no need to cleanup afterwards
# --virtual: bundle packages, remove whole bundle at once, when done
RUN apk --no-cache --virtual build-dependencies add \
    py3-pip \
    make \
    g++ \
    && npm install \
    && apk del build-dependencies

EXPOSE 3000
CMD npm run start-${ENV}