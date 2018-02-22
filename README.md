# speakops-be
[![Build Status](https://travis-ci.org/wordshaker/speakops-be.svg?branch=master)](https://travis-ci.org/wordshaker/speakops-be)

Useful docker commands
----------------------
To build (where X.X.X is a version):
```bash
docker build -t speakops-be:vX.X.X .
```
To view latest two docker images:
```bash
docker images | head -n2
```
To run:
```bash
docker run -d -t -p 5000:5000 --name speakops-be speakops-be:vX.X.X
```
To check logs:
```bash
docker logs speakops-be
```
To remove:
```bash
docker rm speakops-be
```

Postman collection for use with a running local docker image
------------------------------------------------------------
[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/9615b79e8be22a762c81)