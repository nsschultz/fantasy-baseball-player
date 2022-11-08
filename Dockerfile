# syntax=docker/dockerfile:1
FROM nschultz/base-nginx-runner:1.23.2
COPY nginx.conf /etc/nginx/nginx.conf
COPY default.conf /etc/nginx/conf.d/
COPY njs/ /etc/nginx/njs/