FROM nschultz/base-nginx-runner:0.5.3
COPY nginx.conf /etc/nginx/nginx.conf
COPY default.conf /etc/nginx/conf.d/