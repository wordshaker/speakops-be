# speakops-be
[![Build Status](https://travis-ci.org/wordshaker/speakops-be.svg?branch=master)](https://travis-ci.org/wordshaker/speakops-be)

Useful docker commands
----------------------
To build:
```bash
docker build -t moretonb/speakops-be:lastest .
```
To view latest two docker images:
```bash
docker images | head -n2
```
To run:
```bash
docker run -d -t -p 5000:5000 --name speakops-be speakops-be:lastest
```
To check logs:
```bash
docker logs speakops-be
```
To remove:
```bash
docker rm speakops-be
```
To login:
```bash
docker login
```
To push image up to docker hub (kicks off a deployment if tagged as latest):
```bash
docker push moretonb/speakops-be:latest
```

Azure Web App for Containers
----------------------
Gotchas:
* Make sure the appsetting WEBSITES_PORT hooks up the right port on the container (WEBSITES_PORT=5000)

Postman collection for use with a running local docker image
------------------------------------------------------------
[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/9615b79e8be22a762c81)