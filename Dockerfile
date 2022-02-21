FROM nschultz/base-nginx-runner:1.21.6
COPY nginx.conf /etc/nginx/nginx.conf
COPY default.conf /etc/nginx/conf.d/
COPY njs/ /etc/nginx/njs/