FROM nschultz/base-nginx-runner:1.18.0
COPY nginx.conf /etc/nginx/nginx.conf
COPY default.conf /etc/nginx/conf.d/